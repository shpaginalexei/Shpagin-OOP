#include "shpaginwindow.h"
#include <QStyleHints>
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
#if QT_VERSION >= 0x060800
    a.styleHints()->setColorScheme(Qt::ColorScheme::Light);
#endif
    ShpaginWindow w;
    w.show();
    return a.exec();
}
