#pragma once

#include "company.h"

#include <QDialog>
#include <QBoxLayout>

namespace Ui {
class ShpaginDialog;
}

class ShpaginDialog : public QDialog
{
    Q_OBJECT

public:
    explicit ShpaginDialog(QWidget *parent, const ShpaginCompany& company);
    ~ShpaginDialog();

    ShpaginCompany company;

private:
    Ui::ShpaginDialog *ui;
    void setControlsVisible(QBoxLayout* layout, bool visible);

private slots:
    void on_listWidget_currentRowChanged(int currentRow);
    void on_lineEdit_Name_editingFinished();
    void on_spinBox_Age_valueChanged(int age);
    void on_spinBox_Experience_valueChanged(int experience);
    void on_lineEdit_Salary_editingFinished();
    void on_comboBox_MainLanguage_currentTextChanged(const QString &language);
    void on_checkBox_IsFullStack_checkStateChanged(const Qt::CheckState &state);
    void on_lineEdit_CurrentProjectName_editingFinished();
    void on_addEmployeeButton_clicked();
    void on_addDeveloperButton_clicked();
    void on_deleteButton_clicked();
};
