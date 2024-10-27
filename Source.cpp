#include "pch.h"
#include "Menu.h"
#include "Company.h"


int main()
{
#ifdef _WIN32
    std::wcin.imbue(std::locale("rus_rus.866"));
    std::wcout.imbue(std::locale("rus_rus.866"));
#else
    std::wcin.imbue(std::locale("ru_RU.UTF-8"));
    std::wcout.imbue(std::locale("ru_RU.UTF-8"));
#endif

    ShpaginCompany company;

    std::filesystem::create_directory("saves\\");
    company.set_directory(L"saves\\");

    while (true) {
        MainMenu(company);
    }

}
