using System;
using System.Xml.Serialization;

namespace CSharp
{
    internal class ShpaginCompany
    {
        protected List<ShpaginEmployee> employees;

        public bool Changed { get; set; }
        public bool Empty => employees.Count == 0;
        public bool HasSavedFile => FileName != "";
        public bool Saved => !Changed;
        public string FileName { get; set; }
        public string Directory { get; set; }
        protected const string extention = ".xml";

        public ShpaginCompany()
        {
            employees = [];
            Changed = false;
            FileName = "";
            Directory = "";
        }

        public void add_employee()
        {
            ShpaginEmployee e = new();
            e.console_input();
            employees.Add(e);
            Changed = true;
        }

        public void add_developer()
        {
            ShpaginDeveloper d = new();
            d.console_input();
            employees.Add(d);
            Changed = true;
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

        protected void clear()
        {
            employees.Clear();
            ShpaginEmployee.ResetMaxId();
            Changed = false;
        }

        public void clear_company()
        {
            clear();
            Console.WriteLine("Все данные удалены.");
        }

        public void save_to_file()
        {
            var xs = new XmlSerializer(typeof(List<ShpaginEmployee>), new[] { typeof(ShpaginEmployee), typeof(ShpaginDeveloper) });
            using (Stream fs = new FileStream(Directory + FileName + extention, FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, employees);
            }
            Changed = false;
        }

        public bool show_saves()
        {
            var files = System.IO.Directory.GetFiles(Directory, "*" + extention);
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
            using (Stream fs = new FileStream(Directory + FileName + extention, FileMode.Open))
            {
                employees = (xs.Deserialize(fs) as List<ShpaginEmployee>)!;
            }
            Changed = false;
        }
    }
}
