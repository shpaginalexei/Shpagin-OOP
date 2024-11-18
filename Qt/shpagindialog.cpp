#include "shpagindialog.h"
#include "ui_shpagindialog.h"
#include "developer.h"

#include <QIntValidator>

ShpaginDialog::ShpaginDialog(QWidget *parent, const ShpaginCompany& company)
    : QDialog(parent)
    , company(company)
    , ui(new Ui::ShpaginDialog)
{
    ui->setupUi(this);

    ui->lineEdit_Salary->setValidator(new QIntValidator(0, 1000000, this));

    ui->comboBox_MainLanguage->addItems(Language::getAll());

    if (company.empty()) {
        ui->labelHeader->setText(QString("Сотрудник"));
        setControlsVisible(ui->layoutBase, false);
        setControlsVisible(ui->layoutOptional, false);
        ui->deleteButton->setVisible(false);
        return;
    }

    for(int i = 0; i < company.size(); ++i) {
        ui->listWidget->addItem(company.getEmployee(i)->getNameForList());
    }
    ui->listWidget->setCurrentRow(0);
}

ShpaginDialog::~ShpaginDialog()
{
    delete ui;
}

void ShpaginDialog::setControlsVisible(QBoxLayout* layout, bool visible) {
    for (int i = 0; i < layout->count(); ++i) {
        QLayout* innerLayout = layout->itemAt(i)->layout();
        for (int j = 0; j < innerLayout->count(); ++j) {
            QWidget* widget = innerLayout->itemAt(j)->widget();
            if (widget) {
                widget->setVisible(visible);
            }
        }
    }
}

void ShpaginDialog::on_listWidget_currentRowChanged(int currentRow)
{
    if(currentRow < 0 || currentRow >= company.size()) {
        return;
    }

    auto employeeData = company.getEmployee(currentRow)->getData();

    if (employeeData.size() < 5) {
        return;
    }

    ui->labelHeader->setText(QString("Сотрудник #%1").arg(employeeData[0]));
    ui->lineEdit_Name->setText(employeeData[1]);
    ui->spinBox_Age->setValue(employeeData[2].toInt());
    ui->spinBox_Experience->setValue(employeeData[3].toInt());
    ui->lineEdit_Salary->setText(employeeData[4]);

    if (employeeData.size() < 8) {
        setControlsVisible(ui->layoutOptional, false);
        return;
    }
    setControlsVisible(ui->layoutOptional, true);

    int idx = ui->comboBox_MainLanguage->findText(employeeData[5]);
    ui->comboBox_MainLanguage->setCurrentIndex(idx == -1 ? 0 : idx);
    ui->checkBox_IsFullStack->setChecked(employeeData[6] == "Да" ? Qt::Checked : Qt::Unchecked);
    ui->lineEdit_CurrentProjectName->setText(employeeData[7]);
}

void ShpaginDialog::on_lineEdit_Name_editingFinished()
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    company.getEmployee(currentRow)->setName(ui->lineEdit_Name->text().toStdWString());
    ui->listWidget->currentItem()->setText(QString(company.getEmployee(currentRow)->getNameForList()));
}

void ShpaginDialog::on_spinBox_Age_valueChanged(int age)
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    ui->spinBox_Experience->setMaximum(age);
    company.getEmployee(currentRow)->setAge(age);
}

void ShpaginDialog::on_spinBox_Experience_valueChanged(int experience)
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    company.getEmployee(currentRow)->setExperience(experience);
}

void ShpaginDialog::on_lineEdit_Salary_editingFinished()
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    company.getEmployee(currentRow)->setSalary(ui->lineEdit_Salary->text().toInt());
}

void ShpaginDialog::on_comboBox_MainLanguage_currentTextChanged(const QString &language)
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    auto developer = std::dynamic_pointer_cast<ShpaginDeveloper>(company.getEmployee(currentRow));
    if (developer) {
        if (Language::get(Language::Empty) == language) {
            developer->setMainLanguage(L"");
        }
        else {
            developer->setMainLanguage(language.toStdWString());
        }
    }
}

void ShpaginDialog::on_checkBox_IsFullStack_checkStateChanged(const Qt::CheckState &state)
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    auto developer = std::dynamic_pointer_cast<ShpaginDeveloper>(company.getEmployee(currentRow));
    if (developer) {
        developer->setIsFullStack(state == Qt::Checked);
    }
}

void ShpaginDialog::on_lineEdit_CurrentProjectName_editingFinished()
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    auto developer = std::dynamic_pointer_cast<ShpaginDeveloper>(company.getEmployee(currentRow));
    if (developer) {
        developer->setCurrentProjectName(ui->lineEdit_CurrentProjectName->text().toStdWString());;
    }
}

void ShpaginDialog::on_addEmployeeButton_clicked()
{
    company.addEmployee();
    int idx = company.size() - 1;
    ui->listWidget->addItem(QString(company.getEmployee(idx)->getNameForList()));
    ui->listWidget->setCurrentRow(idx);
    setControlsVisible(ui->layoutBase, true);
    ui->deleteButton->setVisible(true);
    ui->lineEdit_Name->setFocus();
}

void ShpaginDialog::on_addDeveloperButton_clicked()
{
    company.addDeveloper();
    int idx = company.size() - 1;
    ui->listWidget->addItem(QString(company.getEmployee(idx)->getNameForList()));
    ui->listWidget->setCurrentRow(idx);
    setControlsVisible(ui->layoutBase, true);
    setControlsVisible(ui->layoutOptional, true);
    ui->deleteButton->setVisible(true);
    ui->lineEdit_Name->setFocus();
}

void ShpaginDialog::on_deleteButton_clicked()
{
    int currentRow = ui->listWidget->currentRow();
    if(currentRow < 0) {
        return;
    }
    int nextRow = currentRow == company.size() - 1 ? currentRow - 1 : currentRow;
    ui->listWidget->takeItem(currentRow);
    company.deleteEmployee(currentRow);

    if (company.empty()) {
        ui->labelHeader->setText(QString("Сотрудник"));
        setControlsVisible(ui->layoutBase, false);
        setControlsVisible(ui->layoutOptional, false);
        ui->deleteButton->setVisible(false);
    }
    else {
        ui->listWidget->setCurrentRow(nextRow);
    }
}
