using System;
using System.Xml.Serialization;

namespace CSharp
{
    [XmlType("ShpaginDeveloper")]
    public class ShpaginDeveloper : ShpaginEmployee
    {
        public string MainLanguage { get; set; }
        public bool IsFullStack { get; set; }
        public string CurrentProjectName { get; set; }

        public ShpaginDeveloper()
            : base()
        {
            MainLanguage = "";
            IsFullStack = false;
            CurrentProjectName = "";
        }

        public override void console_input()
        {
            base.console_input();
            MainLanguage = Utils.GetCorrectString("основной язык программирования: ");
            IsFullStack = Utils.GetCorrectIntNumber("Full Stack разработчик (1 - да, 0 - нет)?: ", 0, 1) != 0;
            CurrentProjectName = Utils.GetCorrectString("название текущего проекта: ");
        }

        public override void console_output()
        {
            base.console_output();
            Console.WriteLine(
                $"основной язык программирования - {MainLanguage}\n" +
                $"Full Stack разработчик - {(IsFullStack ? "да" : "нет")}\n" +
                $"название текущего проекта - {CurrentProjectName}");
        }
    }
}
