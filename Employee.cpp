#include "Employee.h"
#include "Utils.h"
#include <iostream>
#include <fstream>
#include <limits>


int ShpaginEmployee::max_id = 0;

void ShpaginEmployee::reset_max_id() {
	max_id = 0;
}

ShpaginEmployee::ShpaginEmployee() {
	id = ++max_id;
	name = "";
	age = 0;
	experience = 0;
	salary = 0;
}

void ShpaginEmployee::console_input(std::istream& in) {
    std::cout << "фамилия и имя: ";
	std::getline(in >> std::ws, name);
	age = GetCorrectNumber(in, 18, 100, "возраст: ");
	experience = GetCorrectNumber(in, 0, age, "стаж работы: ");
	salary = GetCorrectNumber(in, 0, INT_MAX, "зарпата (в месяц): ");
}

void ShpaginEmployee::console_output(std::ostream& out) const {
	out << "Сотрудник id_" << id << std::endl
		<< "имя - " << name << std::endl
		<< "возраст - " << age << std::endl
		<< "стаж работы - " << experience << " год/года/лет" << std::endl
		<< "зарплата - " << salary << " руб/мес" << std::endl;
}
