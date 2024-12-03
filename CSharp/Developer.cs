using System;
using System.Xml.Serialization;

namespace CSharp
{
    [XmlType("ShpaginDeveloper")]
    public class ShpaginDeveloper : ShpaginEmployee
    {
        [XmlElement("MainLanguage")]
        public string main_language;

        [XmlElement("IsFullStack")]
        public bool is_full_stack;

        [XmlElement("CurrentProjectName")]
        public string current_project_name;

        public ShpaginDeveloper()
            : base()
        {
            main_language = "";
            is_full_stack = false;
            current_project_name = "";
        }

        public override void console_input()
        {
            base.console_input();
            main_language = Utils.GetCorrectString("основной язык программирования: ");
            is_full_stack = Utils.GetCorrectIntNumber("Full Stack разработчик (1 - да, 0 - нет)?: ", 0, 1) != 0;
            current_project_name = Utils.GetCorrectString("название текущего проекта: ");
        }

        public override void console_output()
        {
            base.console_output();
            Console.WriteLine(
                $"основной язык программирования - {main_language}\n" +
                $"Full Stack разработчик - {(is_full_stack ? "да" : "нет")}\n" +
                $"название текущего проекта - {current_project_name}");
        }
    }
}
