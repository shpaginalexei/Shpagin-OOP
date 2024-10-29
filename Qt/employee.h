#pragma once
#include "pch.h"


class ShpaginEmployee
{
public:
	ShpaginEmployee();

    static void reset_max_id();

    virtual QStringList getColumnNames() const;
    virtual QStringList getData() const;

    QList<QSize> calculateCellSizes(const QFontMetrics& metrics, const int& padding) const;
    void draw(QPainter& painter, const QList<QSize>& cellSizes, const int& x, int& y) const;

private:
	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version) {
		ar& id;
        ar& name;
		ar& age;
		ar& experience;
		ar& salary;
	}

protected:
	static int max_id;
	int id;
    std::wstring name;
	int age;
	int experience;
    int salary;

};
