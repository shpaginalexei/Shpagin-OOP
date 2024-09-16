#pragma once
#include <string>
#include "Utils.h"


class ShpaginEmployee
{
public:

	ShpaginEmployee();
	~ShpaginEmployee() {};

	static void reset_max_id();

	friend std::istream& operator>> (std::istream&, ShpaginEmployee&);
	friend std::ostream& operator<< (std::ostream&, const ShpaginEmployee&);

	friend std::ifstream& operator>> (std::ifstream&, ShpaginEmployee&);
	friend std::ofstream& operator<< (std::ofstream&, const ShpaginEmployee&);

private:
	static int max_id;
	int id;
	std::string name = "";
	int age = 0;
	Departament departament = Departament::Other;
	int salary = 0;
};
