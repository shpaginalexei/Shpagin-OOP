#include "Menu.h"
#include "Utils.h"
#include <conio.h>


void Print(const std::wstring menu[], const int size)
{
    for (int i = 0; i < size; i++) {
        std::wcout << menu[i] << std::endl;
    }
    std::wcout << L"\n";
}

void BackToMenu()
{
    std::wcout << L"\n\nПожалуйста, нажмите Enter, чтобы вернуться в меню...";
    while (_getch() != 13) { continue; }
    system("cls");
}

void MainMenu(ShpaginCompany& company)
{
    static const int main_menu_size = 7;
    static const std::wstring main_menu[main_menu_size] = {
        L"1. Добавить сотрудника",
        L"2. Добавить разработчика",
        L"3. Просмотреть всех",
        L"4. Сохранить",
        L"5. Загрузить",
        L"6. Очистить",
        L"0. Выход",
    };
    Print(main_menu, main_menu_size);
    int menu = GetCorrectNumber(std::cin, 0, 6, L">> ");
    system("cls");
    switch (menu) {
    case 1:
    {
        std::wcout << L"-> Добавить сотрудника" << std::endl;
        company.add_employee();
        BackToMenu();
        break;
    }
    case 2:
    {
        std::wcout << L"-> Добавить разработчика" << std::endl;
        company.add_developer();
        BackToMenu();
        break;
    }
    case 3:
    {
        std::wcout << L"-> Просмотреть всех" << std::endl;
        std::wcout << company;
        BackToMenu();
        break;
    }
    case 4:
    {
        std::wcout << L"-> Сохранить" << std::endl;
        if (CheckBeforeSave(company)) {
            company.save_to_file();
        }
        BackToMenu();
        break;
    }
    case 5:
    {
        std::wcout << L"-> Загрузить" << std::endl;
        CheckBeforeLoad(company);
        company.load_from_file();
        BackToMenu();
        break;
    }
    case 6:
    {
        std::wcout << L"-> Очистить" << std::endl;
        company.clear_company();
        BackToMenu();
        break;
    }
    case 0:
    default:
    {
        CheckBeforeExit(company);
        exit(0);
    }
    }
}

void InputFileName(ShpaginCompany& c)
{
    c.show_saves();
    std::wcout << L"Введите имя файла: ";
    std::wstring fn;
    getline(std::wcin >> std::ws, fn);
    c.set_filename(fn);
}

bool CheckBeforeSave(ShpaginCompany& c)
{
    if (c.saved()) {
        if (c.has_saved_file()) {
            std::wcout << L"*В компании нет несохраненных изменений.\n";
            return false;
        }
        else if (c.empty()) {
            std::wcout << L"*Компания пуста\n";
            if (GetCorrectNumber(std::cin, 0, 1, L"Хотите сохранить пустой файл? (1 - да, 0 - нет): ") == 0) {
                return false;
            }
        }
    }
    else if (c.has_saved_file()) {
        int choice = GetCorrectNumber(std::cin, 0, 2, L"Хотите сохранить в том же файле? (0 - тот же, 1 - другой, 2 - не сохранять): ");
        if (choice == 2) {
            std::wcout << L"*Изменения были утеряны\n";
            return false;
        }
        if (choice == 1) {
            InputFileName(c);
        }
        return true;
    }
    else if (c.empty()) {
        std::wcout << L"*Компания пуста\n";
        if (GetCorrectNumber(std::cin, 0, 1, L"Хотите сохранить пустой файл? (1 - да, 0 - нет): ") == 0) {
            return false;
        }
    }
    InputFileName(c);
    return true;
}

void CheckBeforeExit(ShpaginCompany& c)
{
    if (!c.saved()) {
        if (c.has_saved_file()) {
            std::wcout << L"*В компании есть несохраненные изменения\n";
            int choice = GetCorrectNumber(std::cin, 0, 2, L"Хотите сохранить в том же файле? (0 - тот же, 1 - другой, 2 - не сохранять): ");
            if (choice == 2) {
                std::wcout << L"*Изменения были утеряны\n";
            }
            else if (choice == 1) {
                InputFileName(c);
                c.save_to_file();
            }
            else if (choice == 0) {
                c.save_to_file();
            }
        }
        else {
            std::wcout << L"*Внесенные изменения являются новыми и не сохранены.\n";
            if (GetCorrectNumber(std::cin, 0, 1, L"Хотите сохранить изменения в файле? (1 - да, 0 - нет): ") == 0) {
                std::cout << "*Данные были утеряны\n";
            }
            else {
                InputFileName(c);
                c.save_to_file();
            }
        }
    }
}

void CheckBeforeLoad(ShpaginCompany& pts)
{
    CheckBeforeExit(pts);
    InputFileName(pts);
}
