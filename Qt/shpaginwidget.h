#pragma once

#include "company.h"
#include <QWidget>

class ShpaginWidget : public QWidget
{
    Q_OBJECT
public:
    explicit ShpaginWidget(QWidget *parent = nullptr);

    QFont font;
    int padx, pady, padding;

    void paintEvent(QPaintEvent *event) override;
    QSize minimumSizeHint() const override;
    void drawTable(QPainter& painter);
    void load(const QString& path);
    // void save(const QString& path);
    void update();
    void clean();

private:
    ShpaginCompany company;

signals:

};
