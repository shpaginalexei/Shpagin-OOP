#include "employee.h"


int ShpaginEmployee::max_id = 0;

void ShpaginEmployee::reset_max_id()
{
	max_id = 0;
}

ShpaginEmployee::ShpaginEmployee()
{
	id = ++max_id;
    name = L"";
	age = 0;
	experience = 0;
	salary = 0;
}

QStringList ShpaginEmployee::getColumnNames() const
{
    return QStringList({
        "ID",
        "Имя",
        "Возраст, лет",
        "Стаж работы, лет",
        "Зарплата, руб/мес",
    });
}

QStringList ShpaginEmployee::getData() const
{
    return QStringList({
        QString::number(id),
        QString::fromStdWString(name),
        QString::number(age),
        QString::number(experience),
        QString::number(salary),
    });
}

void ShpaginEmployee::draw(QPainter& painter, const QList<QSize>& cellSizes, const int& x, int& y) const
{
    QStringList rowData = getData();

    if (cellSizes.size() < rowData.size()) {
        return;
    }

    int dx = 0;
    for (int i = 0; i < cellSizes.size(); ++i) {
        QRect cellRect(x + dx, y, cellSizes[i].width(), cellSizes[i].height());
        if (i < rowData.size()) {
            painter.drawText(cellRect, Qt::AlignCenter, rowData[i]);
        }
        painter.drawRect(cellRect);
        dx += cellSizes[i].width();
    }
    y += cellSizes[0].height();
}

QList<QSize> ShpaginEmployee::calculateCellSizes(const QFontMetrics& metrics, const int& padding) const
{
    QStringList data = getData();
    int rowHeight = metrics.height();

    QList<QSize> cellSizes(data.size());
    for (int i = 0; i < cellSizes.size(); ++i) {
        cellSizes[i] = QSize(metrics.horizontalAdvance(data[i]) + 2 * padding, rowHeight + 2 * padding);
    }

    return cellSizes;
}
