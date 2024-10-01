#include "pch.h"
#include "Utils.h"
#include "Menu.h"
#include "Company.h"
#include <Windows.h>



int main() {

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    ShpaginCompany company;

    std::filesystem::create_directory("saves\\");
    company.set_directory("saves\\");

    while (true) {
        MainMenu(company);
    }

}
