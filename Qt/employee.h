#pragma once

#include "pch.h"

class ShpaginEmployee
{
public:
    ShpaginEmployee();
    virtual ~ShpaginEmployee() = default;

    static void reset_max_id();
    static void set_max_id(int id);
    static int get_max_id();

    QString getNameForList() const;

    virtual QStringList getColumnNames() const;
    virtual QStringList getData() const;

    void setName(std::wstring name);
    void setAge(int age);
    void setExperience(int experience);
    void setSalary(int salary);

    QList<QSize> calculateCellSizes(const QFontMetrics& metrics, int padding) const;
    void draw(QPainter& painter, const QList<QSize>& cellSizes, int x, int& y) const;

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
