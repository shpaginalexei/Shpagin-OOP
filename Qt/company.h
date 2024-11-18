#pragma once
#include "pch.h"
#include "employee.h"

class ShpaginCompany
{
public:
    void addEmployee();
    void addDeveloper();
    void deleteEmployee(int idx);

    std::shared_ptr<ShpaginEmployee> getEmployee(int idx) const;

    QStringList getColumnNames() const;

    QList<QSize> calculateCellSizes(const QFontMetrics& metrics, int padding) const;
    QSize calculateTableSize(const QFontMetrics& metrics,int padx, int pady, int padding) const;
    void draw(QPainter& painter, const QFontMetrics& metrics, int padx, int pady, int padding);

    void load(const std::wstring& path);
    void save(const std::wstring& path);

    void clear();
    bool empty() const;
    int size() const;
    bool changed = false;

private:
	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& employees;
	}

    std::vector<std::shared_ptr<ShpaginEmployee>> employees = {};

};
