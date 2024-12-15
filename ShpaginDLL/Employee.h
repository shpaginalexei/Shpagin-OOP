#pragma once
#include "pch.h"

struct ShpaginEmployeeStruct
{
	int id;
	wchar_t name[100];
	int age;
	int experience;
	int salary;
};

struct ShpaginEmployeeOrDeveloperStruct
{
	bool is_developer = false;
	ShpaginEmployeeStruct employee_data;
	wchar_t main_language[100] = {};
	bool is_full_stack = false;
	wchar_t current_project_name[100] = {};
};

class ShpaginEmployee
{
public:
	ShpaginEmployee()
	{
		id = 0;
		name = L"";
		age = 0;
		experience = 0;
		salary = 0;
	};

	ShpaginEmployee(const ShpaginEmployeeOrDeveloperStruct& data)
	{
		id = data.employee_data.id;
		name = data.employee_data.name;
		age = data.employee_data.age;
		experience = data.employee_data.experience;
		salary = data.employee_data.salary;
	};

	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version) {
		ar& id;
		ar& name;
		ar& age;
		ar& experience;
		ar& salary;
	}

	virtual ShpaginEmployeeOrDeveloperStruct getStruct() const
	{
		ShpaginEmployeeStruct employeeStruct;
		employeeStruct.id = id;
		wcscpy(employeeStruct.name, name.c_str());
		employeeStruct.age = age;
		employeeStruct.experience = experience;
		employeeStruct.salary = salary;

		ShpaginEmployeeOrDeveloperStruct result;
		result.employee_data = employeeStruct;
		return result;
	};

protected:
	int id;
	std::wstring name;
	int age;
	int experience;
	int salary;
};
