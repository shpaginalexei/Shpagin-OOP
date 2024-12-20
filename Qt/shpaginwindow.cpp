#include "shpaginwindow.h"
#include "./ui_shpaginwindow.h"
#include "shpagindialog.h"
#include <sstream>

#include <QFileDialog>

ShpaginWindow::ShpaginWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::ShpaginWindow)
{
    ui->setupUi(this);
    fileName = "";
}

ShpaginWindow::~ShpaginWindow()
{
    delete ui;
}

void ShpaginWindow::load()
{
    try {
        ui->shpaginWidget->load(fileName);
        ui->statusbar->showMessage(QString("Файл открыт (%1)").arg(fileName));
    }
    catch (...) {
        ui->statusbar->showMessage("Ошибка открытия файла");
    }
}

void ShpaginWindow::save()
{
    try {
        ui->shpaginWidget->save(fileName);
        ui->statusbar->showMessage(QString("Файл сохранен (%1)").arg(fileName));
    }
    catch (...) {
        ui->statusbar->showMessage("Ошибка сохранения файла");
    }
}

void ShpaginWindow::on_actionNew_triggered()
{
    ui->statusbar->showMessage("Новый файл");
    ui->shpaginWidget->clean();
    fileName = "";
}

void ShpaginWindow::on_actionOpen_triggered()
{
    ui->statusbar->showMessage("Открытие...");
    fileName = QFileDialog::getOpenFileName(this, "Открыть", "../../saves", "Текстовый документ (*.txt)");
    if (!fileName.isEmpty()) {
        load();
    }
    else {
        ui->statusbar->showMessage("");
    }
}

void ShpaginWindow::on_actionSave_triggered()
{
    ui->statusbar->showMessage("Сохранение...");
    if(fileName.isEmpty()) {
        on_actionSaveAs_triggered();
    }
    else {
        save();
    }
}

void ShpaginWindow::on_actionSaveAs_triggered()
{
    ui->statusbar->showMessage("Сохранение как...");
    fileName = QFileDialog::getSaveFileName(this, "Сохранить как...", "../../saves", "Текстовый документ (*.txt)");
    if (!fileName.isEmpty()) {
        save();
    }
    else {
        ui->statusbar->showMessage("");
    }
}

template<class T>
void clone(T& src, T& trg)
{
    std::stringstream stream;
    boost::archive::binary_oarchive out(stream);
    out << src;
    boost::archive::binary_iarchive in(stream);
    in >> trg;
}

void ShpaginWindow::on_actionEditEmployees_triggered()
{
    int last_max_id = ShpaginEmployee::get_max_id();
    ShpaginCompany temp;
    clone(ui->shpaginWidget->company, temp);
    ShpaginEmployee::set_max_id(last_max_id);

    ShpaginDialog dlg(this, temp);

    int res = dlg.exec();
    if (res == QDialog::Accepted) {
        ui->shpaginWidget->company = dlg.company;
        ui->shpaginWidget->update();
    } else if (res == QDialog::Rejected) {
        ShpaginEmployee::set_max_id(last_max_id);
    }
}

