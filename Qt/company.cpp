﻿#include "company.h"


void ShpaginCompany::draw(QPainter& painter, const QFontMetrics& metrics, int padx, int pady, int padding)
{
    if (employees.empty()) {
        return;
    }

    QList<QSize> cellSizes = calculateCellSizes(metrics, padding);
    QStringList columnNames = getColumnNames();

    int x = padx, y = pady;

    // draw table header
    for (int i = 0; i < columnNames.size(); ++i) {
        QRect cellRect(x, y, cellSizes[i].width(), cellSizes[i].height());
        x += cellSizes[i].width();
        painter.drawRect(cellRect);
        painter.drawText(cellRect, Qt::AlignCenter, columnNames[i]);
    }
    x = padx;
    y += cellSizes[0].height();

    // draw table body
    std::for_each(employees.begin(), employees.end(),
                  std::bind(&ShpaginEmployee::draw,
                            std::placeholders::_1,
                            std::ref(painter),
                            std::cref(cellSizes),
                            x,
                            std::ref(y)));
}

QStringList ShpaginCompany::getColumnNames() const
{
    if (employees.empty()) {
        return QStringList();
    }

    int columnCount = 0;
    QStringList columnNames;
    for (const auto& e : employees) {
        QStringList employeeColumnNames = e->getColumnNames();
        if (employeeColumnNames.size() > columnCount) {
            columnCount = employeeColumnNames.size();
            columnNames = employeeColumnNames;
        }
    }

    return columnNames;
}

QList<QSize> ShpaginCompany::calculateCellSizes(const QFontMetrics& metrics, int padding) const
{
    if (employees.empty()) {
        return QList<QSize>();
    }

    QList<QSize> cellSizes;

    for (const auto& name : getColumnNames()) {
        cellSizes.push_back(QSize(metrics.horizontalAdvance(name) + 2 * padding,
                                  metrics.height() + 2 * padding));
    }

    for (const auto& e : employees) {
        QList<QSize> employeeCellSizes = e->calculateCellSizes(metrics, padding);
        for (int i = 0; i < employeeCellSizes.size(); ++i) {
            if (employeeCellSizes[i].width() > cellSizes[i].width()) {
                cellSizes[i] = employeeCellSizes[i];
            }
        }
    }

    return cellSizes;
}

QSize ShpaginCompany::calculateTableSize(const QFontMetrics& metrics, int padx, int pady, int padding) const
{
    if (employees.empty()) {
        return QSize();
    }

    QList<QSize> cellSizes = calculateCellSizes(metrics, padding);

    int totalHeight = 2 * pady + (employees.size() + 1) * (metrics.height() + 2 * padding);
    int totalWidth = 2 * padx;
    for (const auto& cell : cellSizes) {
        totalWidth += cell.width();
    }

    return QSize(totalWidth, totalHeight);
}

void ShpaginCompany::load(const std::wstring& path)
{
    clear();
    std::ifstream fin(path, std::ios::binary);
    boost::archive::binary_iarchive ia(fin);
    ia& *this;
}

// void ShpaginCompany::save(const std::wstring& path)
// {
//     std::ofstream fout(path, std::ios::binary);
//     boost::archive::binary_oarchive oa(fout);
//     oa& *this;
// }

bool ShpaginCompany::empty() const
{
    return employees.empty();
}

void ShpaginCompany::clear()
{
    employees.clear();
    ShpaginEmployee::reset_max_id();
}