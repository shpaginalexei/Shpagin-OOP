#include "shpaginwidget.h"


ShpaginWidget::ShpaginWidget(QWidget *parent)
    : QWidget{parent}
{
    font = QFont("Segoe UI", 9);
    padx = 10, pady = 10;
    padding = 10;
}

void ShpaginWidget::paintEvent(QPaintEvent *event)
{
    if (company.empty()) {
        return;
    }
    QPainter painter(this);
    painter.setFont(font);
    painter.setRenderHint(QPainter::Antialiasing, true);
    drawTable(painter);
}

QSize ShpaginWidget::minimumSizeHint() const
{
    QFontMetrics metrics(font);
    return company.calculateTableSize(metrics, padx, pady, padding);
}

void ShpaginWidget::drawTable(QPainter& painter)
{
    QFontMetrics metrics(font);
    company.draw(painter, metrics, padx, pady, padding);
}

void ShpaginWidget::load(const QString& path)
{
    clean();
    company.load(path.toStdWString());
    update();
}

// void ShpaginWidget::save(const QString& path)
// {
//     company.save(path.toStdWString());
// }

void ShpaginWidget::update()
{
    QWidget::resize(minimumSizeHint());
    QWidget::update();
}

void ShpaginWidget::clean()
{
    company.clear();
    update();
}
