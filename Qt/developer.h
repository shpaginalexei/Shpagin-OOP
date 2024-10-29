#pragma once
#include "pch.h"
#include "employee.h"


class ShpaginDeveloper : public ShpaginEmployee
{
public:
	ShpaginDeveloper();

    QStringList getColumnNames() const override;
    QStringList getData() const override;

private:
	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& boost::serialization::base_object<ShpaginEmployee>(*this);
		ar& main_language;
		ar& is_full_stack;
		ar& current_project_name;
	}

protected:
    std::wstring main_language;
	bool is_full_stack;
    std::wstring current_project_name;

};
