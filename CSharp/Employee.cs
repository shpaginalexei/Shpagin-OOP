using System;
using System.Xml.Serialization;

namespace CSharp
{
    [XmlType("ShpaginEmployee")]
    public class ShpaginEmployee
    {
        [XmlAttribute("Id")]
        protected static int max_id;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }

        public ShpaginEmployee()
        {
            Id = ++max_id;
            Name = "";
            Age = 0;
            Experience = 0;
            Salary = 0;
        }

        public static void ResetMaxId() { max_id = 0; }

        public virtual void console_input()
        {
            Name = Utils.GetCorrectString("фамилия и имя: ");
            Age = Utils.GetCorrectIntNumber("возраст: ", 18, 100);
            Experience = Utils.GetCorrectIntNumber("стаж работы: ", 0, Age);
            Salary = Utils.GetCorrectIntNumber("зарпата (в месяц): ", 0, int.MaxValue);
        }

        public virtual void console_output()
        {
            Console.WriteLine(
                $"Сотрудник id_{Id}\n" +
                $"имя - {Name}\n" +
                $"возраст - {Age}\n" +
                $"стаж работы - {Experience} год/года/лет\n" +
                $"зарпата (в месяц) - {Salary} руб/мес");
        }
    }
}
