#include "shpaginwindow.h"
#include "./ui_shpaginwindow.h"
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

// void ShpaginWindow::save()
// {
//     try {
//         ui->shpaginWidget->save(fileName);
//         ui->statusbar->showMessage(QString("Файл сохранен (%1)").arg(fileName));
//     }
//     catch (...) {
//         ui->statusbar->showMessage("Ошибка сохранения файла");
//     }
// }

void ShpaginWindow::on_actionNew_triggered()
{
    ui->statusbar->showMessage("Здесь будет \"Новый файл\"");
    // ui->shpaginWidget->clean();
    // fileName = "";
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
    ui->statusbar->showMessage("Здесь будет \"Сохранение...\"");
    // if(fileName.isEmpty()) {
    //     on_actionSaveAs_triggered();
    // }
    // else {
    //     save();
    // }
}

void ShpaginWindow::on_actionSaveAs_triggered()
{
    ui->statusbar->showMessage("Здесь будет \"Сохранение как...\"");
    // fileName = QFileDialog::getSaveFileName(this, "Сохранить как...", QDir::homePath(), "Текстовый документ (*.txt)");
    // if (!fileName.isEmpty()) {
    //     save();
    // }
    // else {
    //     ui->statusbar->showMessage("");
    // }
}
