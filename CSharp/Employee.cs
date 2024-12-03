using System;
using System.Xml.Serialization;

namespace CSharp
{
    [XmlType("ShpaginEmployee")]
    public class ShpaginEmployee
    {
        [NonSerialized]
        public static int max_id;

        [XmlAttribute("Id")]
        public int id;

        [XmlElement("Name")]
        public string name;

        [XmlElement("Age")]
        public int age;

        [XmlElement("Experience")]
        public int experience;

        [XmlElement("Salary")]
        public int salary;

        public ShpaginEmployee()
        {
            id = ++max_id;
            name = "";
            age = 0;
            experience = 0;
            salary = 0;
        }

        public static void reset_max_id()
        {
            max_id = 0;
        }

        public virtual void console_input()
        {
            name = Utils.GetCorrectString("фамилия и имя: ");
            age = Utils.GetCorrectIntNumber("возраст: ", 18, 100);
            experience = Utils.GetCorrectIntNumber("стаж работы: ", 0, age);
            salary = Utils.GetCorrectIntNumber("зарпата (в месяц): ", 0, int.MaxValue);
        }

        public virtual void console_output()
        {
            Console.WriteLine(
                $"Сотрудник id_{id}\n" +
                $"имя - {name}\n" +
                $"возраст - {age}\n" +
                $"стаж работы - {experience} год/года/лет\n" +
                $"зарпата (в месяц) - {salary} руб/мес");
        }
    }
}
