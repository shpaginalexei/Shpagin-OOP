using System;
using System.Xml.Serialization;

namespace CSharp
{
    internal class ShpaginCompany
    {
        protected List<ShpaginEmployee> employees;

        protected bool changed;
        protected string fileName;
        protected const string extention = ".xml";
        protected string directory;

        public ShpaginCompany()
        {
            employees = [];
            changed = false;
            fileName = "";
            directory = "";
        }

        public void add_employee()
        {
            ShpaginEmployee e = new();
            e.console_input();
            employees.Add(e);
            changed = true;
        }

        public void add_developer()
        {
            ShpaginDeveloper d = new();
            d.console_input();
            employees.Add(d);
            changed = true;
        }

        public void console_output()
        {
            if (employees.Count > 0)
            {
                foreach (var e in employees)
                {
                    e.console_output();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("*Пусто");
            }
        }

        public bool empty()
        {
            return employees.Count == 0;
        }
        public bool has_saved_file()
        {
            return fileName != "";
        }

        public bool saved()
        {
            return !changed;
        }

        public void set_filename(string fn)
        {
            fileName = fn;
        }

        public void set_directory(string dir)
        {
            directory = dir;
        }

        protected void clear()
        {
            employees.Clear();
            ShpaginEmployee.reset_max_id();
            changed = false;
        }

        public void clear_company()
        {
            clear();
            Console.WriteLine("Все данные удалены.");
        }

        public void save_to_file()
        {
            var xs = new XmlSerializer(typeof(List<ShpaginEmployee>), new[] { typeof(ShpaginEmployee), typeof(ShpaginDeveloper) });
            using (Stream fs = new FileStream(directory + fileName + extention, FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, employees);
            }
            changed = false;
        }

        public bool show_saves()
        {
            var files = Directory.GetFiles(directory, "*" + extention);
            Console.WriteLine("Существующие сохранения:");

            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    Console.WriteLine(" > " + fileNameWithoutExtension);
                }
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("*Пусто");
                return false;
            }
        }

        public void load_from_file()
        {
            var xs = new XmlSerializer(typeof(List<ShpaginEmployee>), new[] { typeof(ShpaginEmployee), typeof(ShpaginDeveloper) });
            using (Stream fs = new FileStream(directory + fileName + extention, FileMode.Open))
            {
                employees = (xs.Deserialize(fs) as List<ShpaginEmployee>)!;
            }
            changed = false;
        }
    }
}
