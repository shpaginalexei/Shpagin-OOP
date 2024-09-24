#include "Developer.h"
#include "Utils.h"
#include <iostream>
#include <fstream>


ShpaginDeveloper::ShpaginDeveloper() : ShpaginEmployee() {
	main_language = "";
	is_full_stack = false;
	current_project_name = "";
}

void ShpaginDeveloper::console_input(std::istream& in) {
	ShpaginEmployee::console_input(in);
	std::cout << "основной язык программирования: ";
	std::getline(in >> std::ws, main_language);
	is_full_stack = GetCorrectNumber(in, 0, 1, "Full Stack разработчик (1 - да, 0 - нет)?: ");
	std::cout << "название текущего проекта: ";
	std::getline(in >> std::ws, current_project_name);
}

void ShpaginDeveloper::console_output(std::ostream& out) const {
	ShpaginEmployee::console_output(out);
	out	<< "основной язык программирования - " << main_language << std::endl
		<< "Full Stack разработчик - " << (is_full_stack ? "да" : "нет") << std::endl
		<< "название текущего проекта - " << current_project_name << std::endl;
}
