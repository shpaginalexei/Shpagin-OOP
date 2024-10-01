#include "Menu.h"
#include "Utils.h"
#include <conio.h>


void Print(const std::string menu[], const int size) {
    for (size_t i{}; i < size; i++) {
        std::cout << menu[i] << std::endl;
    }
    std::cout << "\n";
}

void BackToMenu() {
    std::cout << "\n\nПожалуйста, нажмите Enter, чтобы вернуться в меню...";
    while (_getch() != 13) { continue; }
    system("cls");
}

void MainMenu(ShpaginCompany& company) {
    static const int main_menu_size = 7;
    static const std::string main_menu[main_menu_size] = {
    "1. Добавить сотрудника",
    "2. Добавить разработчика",
    "3. Просмотреть всех",
    "4. Сохранить",
    "5. Загрузить",
    "6. Очистить",
    "0. Выход",
    };
    Print(main_menu, main_menu_size);
    int menu = GetCorrectNumber(std::cin, 0, 6, ">> ", "");
    system("cls");
    switch (menu) {
    case 1:
    {
        std::cout << "-> Добавить сотрудника" << std::endl;
        company.add_employee();
        BackToMenu();
        break;
    }
    case 2:
    {
        std::cout << "-> Добавить разработчика" << std::endl;
        company.add_developer();
        BackToMenu();
        break;
    }
    case 3:
    {
        std::cout << "-> Просмотреть всех" << std::endl;
        std::cout << company;
        BackToMenu();
        break;
    }
    case 4:
    {
        std::cout << "-> Сохранить" << std::endl;
        if (CheckBeforeSave(company)) {
            company.save_to_file();
        }
        BackToMenu();
        break;
    }
    case 5:
    {
        std::cout << "-> Загрузить" << std::endl;
        CheckBeforeLoad(company);
        company.load_from_file();
        BackToMenu();
        break;
    }
    case 6:
    {
        std::cout << "-> Очистить" << std::endl;
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

void InputFileName(ShpaginCompany& c) {
    c.show_saves();
    std::cout << "Введите имя файла: ";
    std::string fn;
    getline(std::cin >> std::ws, fn);
    c.set_filename(fn);
}

bool CheckBeforeSave(ShpaginCompany& c) {
    if (c.saved()) {
        if (c.has_saved_file()) {
            std::cout << "*В компании нет несохраненных изменений.\n";
            return false;
        }
        else if (c.empty()) {
            std::cout << "*Компания пуста\n";
            if (GetCorrectNumber(std::cin, 0, 1, "Хотите сохранить пустой файл? (1 - да, 0 - нет): ", "") == 0) {
                return false;
            }
        }
    }
    else if (c.has_saved_file()) {
        int choice = GetCorrectNumber(std::cin, 0, 2, "Хотите сохранить в том же файле? (0 - тот же, 1 - другой, 2 - не сохранять): ", "");
        if (choice == 2) {
            std::cout << "*Изменения были утеряны\n";
            return false;
        }
        if (choice == 1) {
            InputFileName(c);
        }
        return true;
    }
    else if (c.empty()) {
        std::cout << "*Компания пуста\n";
        if (GetCorrectNumber(std::cin, 0, 1, "Хотите сохранить пустой файл? (1 - да, 0 - нет): ", "") == 0) {
            return false;
        }
    }
    InputFileName(c);
    return true;
}

void CheckBeforeExit(ShpaginCompany& c) {
    if (!c.saved()) {
        if (c.has_saved_file()) {
            std::cout << "*В компании есть несохраненные изменения\n";
            int choice = GetCorrectNumber(std::cin, 0, 2, "Хотите сохранить в том же файле? (0 - тот же, 1 - другой, 2 - не сохранять): ", "");
            if (choice == 2) {
                std::cout << "*Изменения были утеряны\n";
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
            std::cout << "*Внесенные изменения являются новыми и не сохранены.\n";
            if (GetCorrectNumber(std::cin, 0, 1, "Хотите сохранить изменения в файле? (1 - да, 0 - нет): ", "") == 0) {
                std::cout << "*Данные были утеряны\n";
            }
            else {
                InputFileName(c);
                c.save_to_file();
            }
        }
    }
}

void CheckBeforeLoad(ShpaginCompany& pts) {
    CheckBeforeExit(pts);
    InputFileName(pts);
}
