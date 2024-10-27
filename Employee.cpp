#include "Employee.h"
#include "Utils.h"


int ShpaginEmployee::max_id = 0;

void ShpaginEmployee::reset_max_id()
{
	max_id = 0;
}

ShpaginEmployee::ShpaginEmployee()
{
	id = ++max_id;
	name = L"";
	age = 0;
	experience = 0;
	salary = 0;
}

void ShpaginEmployee::console_input()
{
    std::wcout << L"фамилия и имя: ";
	std::getline(std::wcin >> std::ws, name);
	age = GetCorrectNumber(std::cin, 18, 100, L"возраст: ");
	experience = GetCorrectNumber(std::cin, 0, age, L"стаж работы: ");
	salary = GetCorrectNumber(std::cin, 0, INT_MAX, L"зарпата (в месяц): ");
}

void ShpaginEmployee::console_output() const
{
	std::wcout << L"Сотрудник id_" << id << std::endl
			   << L"имя - " << name << std::endl
			   << L"возраст - " << age << std::endl
			   << L"стаж работы - " << experience << L" год/года/лет" << std::endl
			   << L"зарплата - " << salary << L" руб/мес" << std::endl;
}
