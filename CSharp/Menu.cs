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
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("-> Добавить разработчика");
                        company.add_developer();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("-> Просмотреть всех");
                        company.console_output();
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
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("-> Очистить");
                        company.clear_company();
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
            BackToMenu();
        }
        private static void InputFileName(ShpaginCompany c)
        {
            if (c.show_saves())
            {
                string fn = Utils.GetCorrectString("Введите имя файла: ");
                c.FileName = fn;
            }
            else
            {
                throw new TaskCanceledException();
            }
        }

        private static bool CheckBeforeSave(ShpaginCompany c)
        {
            bool HandleSaved()
            {
                Console.WriteLine("*В компании нет несохраненных изменений");
                return false;
            }

            bool HandleEmpty()
            {
                Console.WriteLine("*В компании нечего сохранять");
                return false;
            }

            bool HandleUnsavedWithFile()
            {
                switch (Utils.GetCorrectIntNumber("Хотите сохранить в том же файле? (0 - тот же, 1 - другой, 2 - не сохранять): ", 0, 2))
                {
                    case 2:
                        Console.WriteLine("*Изменения были утеряны");
                        return false;
                    case 1:
                        InputFileName(c);
                        break;
                }
                return true;
            }

            bool HandleUnsavedWithoutFile()
            {
                if (c.Empty)
                {
                    return HandleEmpty();
                }
                InputFileName(c);
                return true;
            }

            if (c.Saved)
            {
                return c.Empty ? HandleEmpty() : HandleSaved();
            }
            return c.HasSavedFile ? HandleUnsavedWithFile() : HandleUnsavedWithoutFile();
        }
        private static void CheckBeforeExit(ShpaginCompany c)
        {
            if (!c.Saved)
            {
                if (Utils.GetCorrectIntNumber("Хотите сохранить изменения в файле? (0 - нет, 1 - да): ", 0, 1) == 1)
                {
                    c.save_to_file();
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
