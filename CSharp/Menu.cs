using System;

namespace CSharp
{
    internal static class Menu
    {
        private static void BackToMenu()
        {
            Console.Write("\n\nПожалуйста, нажмите Enter, чтобы вернуться в меню...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                continue;
            }
            Console.Clear();
        }

        public static void MainMenu(ShpaginCompany company)
        {
            string main_menu = $"1. Добавить сотрудника\n" +
                                "2. Добавить разработчика\n" +
                                "3. Просмотреть всех\n" +
                                "4. Сохранить\n" +
                                "5. Загрузить\n" +
                                "6. Очистить\n" +
                                "0. Выход";
            Console.WriteLine(main_menu);
            int menu = Utils.GetCorrectIntNumber(">> ", 0, 6);
            Console.Clear();
            switch (menu)
            {
                case 1:
                    {
                        Console.WriteLine("-> Добавить сотрудника");
                        company.add_employee();
                        BackToMenu();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("-> Добавить разработчика");
                        company.add_developer();
                        BackToMenu();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("-> Просмотреть всех");
                        company.console_output();
                        BackToMenu();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("-> Сохранить");
                        try
                        {
                            if (CheckBeforeSave(company))
                            {
                                company.save_to_file();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("**Ошибка сохранения файла");
                        }
                        BackToMenu();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("-> Загрузить");
                        try
                        {
                            CheckBeforeLoad(company);
                            company.load_from_file();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("**Ошибка загрузки файла");
                        }
                        BackToMenu();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("-> Очистить");
                        company.clear_company();
                        BackToMenu();
                        break;
                    }
                case 0:
                default:
                    {
                        CheckBeforeExit(company);
                        Environment.Exit(0);
                        break;
                    }
            }
        }
        private static void InputFileName(ShpaginCompany c)
        {
            if (c.show_saves())
            {
                string fn = Utils.GetCorrectString("Введите имя файла: ");
                c.set_filename(fn);
            }
            else
            {
                throw new TaskCanceledException();
            }
        }

        private static bool CheckBeforeSave(ShpaginCompany c)
        {
            if (c.saved())
            {
                if (c.has_saved_file())
                {
                    Console.WriteLine("*В компании нет несохраненных изменений");
                    return false;
                }
                else if (c.empty())
                {
                    Console.WriteLine("*Компания пуста");
                    if (Utils.GetCorrectIntNumber("Хотите сохранить пустой файл? (1 - да, 0 - нет): ", 0, 1) == 0)
                    {
                        return false;
                    }
                }
            }
            else if (c.has_saved_file())
            {
                int choice = Utils.GetCorrectIntNumber("Хотите сохранить в том же файле? (0 - тот же, 1 - другой, 2 - не сохранять): ", 0, 2);
                if (choice == 2)
                {
                    Console.WriteLine("*Изменения были утеряны");
                    return false;
                }
                if (choice == 1)
                {
                    InputFileName(c);
                }
                return true;
            }
            else if (c.empty())
            {
                Console.WriteLine("*Компания пуста");
                if (Utils.GetCorrectIntNumber("Хотите сохранить пустой файл? (1 - да, 0 - нет): ", 0, 1) == 0)
                {
                    return false;
                }
            }
            InputFileName(c);
            return true;
        }
        private static void CheckBeforeExit(ShpaginCompany c)
        {
            if (!c.saved())
            {
                if (c.has_saved_file())
                {
                    Console.WriteLine("*В компании есть несохраненные изменения");
                    int choice = Utils.GetCorrectIntNumber("Хотите сохранить в том же файле? (0 - тот же, 1 - другой, 2 - не сохранять): ", 0, 2);
                    if (choice == 2)
                    {
                        Console.WriteLine("*Изменения были утеряны");
                    }
                    else if (choice == 1)
                    {
                        InputFileName(c);
                        c.save_to_file();
                    }
                    else if (choice == 0)
                    {
                        c.save_to_file();
                    }
                }
                else
                {
                    Console.WriteLine("*Внесенные изменения являются новыми и не сохранены");
                    if (Utils.GetCorrectIntNumber("Хотите сохранить изменения в файле? (1 - да, 0 - нет): ", 0, 1) == 0)
                    {
                        Console.WriteLine("*Данные были утеряны");
                    }
                    else
                    {
                        InputFileName(c);
                        c.save_to_file();
                    }
                }
            }
        }

        private static void CheckBeforeLoad(ShpaginCompany c)
        {
            CheckBeforeExit(c);
            InputFileName(c);
        }
    }
}
