#pragma once
#include "pch.h"
#include "employee.h"


class ShpaginCompany
{
public:
    ~ShpaginCompany() { clear(); }; // clear() ????

    QStringList getColumnNames() const;
    QList<QSize> calculateCellSizes(const QFontMetrics& metrics, int padding) const;
    QSize calculateTableSize(const QFontMetrics& metrics,int padx, int pady, int padding) const;
    void draw(QPainter& painter, const QFontMetrics& metrics, int padx, int pady, int padding);

    void load(const std::wstring& path);
    // void save(const std::wstring& path);
    void clear();
    bool empty() const;

	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& employees;
	}

private:
    std::vector<std::shared_ptr<ShpaginEmployee>> employees = {};

};
