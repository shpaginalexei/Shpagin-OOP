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
}

std::istream& operator>> (std::istream& in, ShpaginEmployee& e) {
    std::cout << "фамилия и имя: ";
	std::getline(in >> std::ws, e.name);
	e.age = GetCorrectNumber(in, 18, 100, "возраст: ");
	std::string departament_message = "отдел (" + enumToString() + "): ";
	e.departament = static_cast<Departament>(GetCorrectNumber<int>(in, 
		Departament::MIN, Departament::MAX, departament_message));
	e.salary = GetCorrectNumber(in, 0, INT_MAX, "зарпата (в месяц): ");
    return in;
}

std::ostream& operator<< (std::ostream& out, const ShpaginEmployee& e) {
	out << "Сотрудник id_" << e.id << std::endl
		<< "имя - " << e.name << std::endl
		<< "возраст - " << e.age << std::endl
		<< "отдел - " << enumToString(e.departament) << std::endl
		<< "зарплата - " << e.salary << " руб/мес" << std::endl;
    return out;
}

std::ifstream& operator>> (std::ifstream& fin, ShpaginEmployee& e) {
	fin >> e.id;
	std::getline(fin >> std::ws, e.name);
	fin >> e.age;
	int departament;
	fin >> departament;
	e.departament = static_cast<Departament>(departament);
	fin >> e.salary;
    return fin;
}

std::ofstream& operator<< (std::ofstream& fout, const ShpaginEmployee& e) {
	fout << e.id << std::endl
		 << e.name << std::endl
		 << e.age << std::endl
		 << static_cast<int>(e.departament) << std::endl
		 << e.salary << std::endl;
    return fout;
}