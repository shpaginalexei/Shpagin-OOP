#pragma once

#include "company.h"
#include <QWidget>

class ShpaginWidget : public QWidget
{
    Q_OBJECT

public:
    explicit ShpaginWidget(QWidget *parent = nullptr);

    ShpaginCompany company;

    void load(const QString& path);
    void save(const QString& path);
    void clean();
    void update();

// private:
    QFont font;
    int padx, pady, padding;

    void drawTable(QPainter& painter);

    void paintEvent(QPaintEvent *event) override;
    QSize minimumSizeHint() const override;

};
