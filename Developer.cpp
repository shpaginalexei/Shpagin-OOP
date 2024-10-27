#include "Developer.h"
#include "Utils.h"


BOOST_CLASS_EXPORT(ShpaginDeveloper)

ShpaginDeveloper::ShpaginDeveloper() : ShpaginEmployee() 
{
	main_language = L"";
	is_full_stack = false;
	current_project_name = L"";
}

void ShpaginDeveloper::console_input()
{
	ShpaginEmployee::console_input();
	std::wcout << L"основной язык программирования: ";
	std::getline(std::wcin >> std::ws, main_language);
	is_full_stack = GetCorrectNumber(std::cin, 0, 1, L"Full Stack разработчик (1 - да, 0 - нет)?: ");
	std::wcout << L"название текущего проекта: ";
	std::getline(std::wcin >> std::ws, current_project_name);
}

void ShpaginDeveloper::console_output() const
{
	ShpaginEmployee::console_output();
	std::wcout	<< L"основной язык программирования - " << main_language << std::endl
				<< L"Full Stack разработчик - " << (is_full_stack ? L"да" : L"нет") << std::endl
				<< L"название текущего проекта - " << current_project_name << std::endl;
}
