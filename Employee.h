#pragma once
#include "pch.h"


class ShpaginEmployee
{
public:

	ShpaginEmployee();

	static void reset_max_id();

	virtual void console_input();
	virtual void console_output() const;

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
