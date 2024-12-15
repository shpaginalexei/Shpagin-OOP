namespace CSharpWithForms
{
    public class ShpaginEmployee
    {
        public static int MaxId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public static void ResetMaxId() { MaxId = 0; }

        public ShpaginEmployee()
        {
            Id = ++MaxId;
            Name = "";
            Age = 18;
            Experience = 0;
            Salary = 0;
        }

        public ShpaginEmployee(ShpaginEmployee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Age = employee.Age;
            Experience = employee.Experience;
            Salary = employee.Salary;
        }

        public string GetNameForList() => $"#{Id} - {Name}";

    }
}
