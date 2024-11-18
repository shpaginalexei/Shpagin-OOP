#pragma once

#include <QMainWindow>

QT_BEGIN_NAMESPACE
namespace Ui {
class ShpaginWindow;
}
QT_END_NAMESPACE

class ShpaginWindow : public QMainWindow
{
    Q_OBJECT
    QString fileName;

public:
    ShpaginWindow(QWidget *parent = nullptr);
    ~ShpaginWindow();

private slots:
    void on_actionNew_triggered();
    void on_actionOpen_triggered();
    void on_actionSave_triggered();
    void on_actionSaveAs_triggered();
    void on_actionEditEmployees_triggered();

    void load();
    void save();

private:
    Ui::ShpaginWindow *ui;
};
