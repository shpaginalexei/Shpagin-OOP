#pragma once
#include "pch.h"
#include "Employee.h"


class ShpaginCompany
{
public:
	~ShpaginCompany() {};

	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& employees;
	}

	std::vector<std::shared_ptr<ShpaginEmployee>> employees = {};

};
