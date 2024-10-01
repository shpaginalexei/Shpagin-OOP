#pragma once
#include "pch.h"
#include "Employee.h"


class ShpaginDeveloper : public ShpaginEmployee
{
public:

	ShpaginDeveloper();

	void console_input(std::istream&) override;
	void console_output(std::ostream&) const override;

	friend class boost::serialization::access;
	template<class Archive>
	void serialize(Archive& ar, const unsigned int version)
	{
		ar& boost::serialization::base_object<ShpaginEmployee>(*this);
		ar& main_language;
		ar& is_full_stack;
		ar& current_project_name;
	}

private:
	
	std::string main_language;
	bool is_full_stack;
	std::string current_project_name;

};