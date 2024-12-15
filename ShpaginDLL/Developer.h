#pragma once
#include "pch.h"
#include "Employee.h"

class ShpaginDeveloper : public ShpaginEmployee
{
public:
	ShpaginDeveloper() : ShpaginEmployee()
	{
		main_language = L"";
		is_full_stack = false;
		current_project_name = L"";
	};

	ShpaginDeveloper(const ShpaginEmployeeOrDeveloperStruct& data) : ShpaginEmployee(data)
	{
		main_language = data.main_language;
		is_full_stack = data.is_full_stack;
		current_project_name = data.current_project_name;
	};

	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& boost::serialization::base_object<ShpaginEmployee>(*this);
		ar& main_language;
		ar& is_full_stack;
		ar& current_project_name;
	}

	ShpaginEmployeeOrDeveloperStruct getStruct() const override
	{
		ShpaginEmployeeOrDeveloperStruct result = ShpaginEmployee::getStruct();
		result.is_developer = true;
		wcscpy(result.main_language, main_language.c_str());
		result.is_full_stack = is_full_stack;
		wcscpy(result.current_project_name, current_project_name.c_str());
		return result;
	};

private:
	std::wstring main_language;
	bool is_full_stack;
	std::wstring current_project_name;

};
