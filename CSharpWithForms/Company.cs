using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpWithForms
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct CSharpEmployeeStruct
    {
        [MarshalAs(UnmanagedType.I4)]
        public int id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string name;
        [MarshalAs(UnmanagedType.I4)]
        public int age;
        [MarshalAs(UnmanagedType.I4)]
        public int experience;
        [MarshalAs(UnmanagedType.I4)]
        public int salary;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct CSharpEmployeeOrDeveloperStruct
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool is_developer;

        public CSharpEmployeeStruct employee_data;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string main_language;
        [MarshalAs(UnmanagedType.I1)]
        public bool is_full_stack;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string current_project_name;
    }
    public class ShpaginCompany
    {
        [DllImport("ShpaginDLL.dll")]
        static extern int GetObjectsSize(StringBuilder filename);

        [DllImport("ShpaginDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void LoadObjects(StringBuilder filename, [Out] CSharpEmployeeOrDeveloperStruct[] array);

        [DllImport("ShpaginDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void SaveObjects(StringBuilder filename, int size, CSharpEmployeeOrDeveloperStruct[] array);

        public List<ShpaginEmployee> employees = [];
        public bool Empty => employees.Count == 0;
        public string Path { get; set; }

        public ShpaginCompany()
        {
            employees = [];
            Path = "";
        }

        public void add_employee()
        {
            ShpaginEmployee e = new();
            //e.console_input();
            employees.Add(e);
        }

        public void add_developer()
        {
            ShpaginDeveloper d = new();
            //d.console_input();
            employees.Add(d);
        }

        public void DeleteEmployee(int idx)
        {
            employees.RemoveAt(idx);
        }

        public void clear()
        {
            employees.Clear();
            ShpaginEmployee.ResetMaxId();
        }

        public void SaveToFile(string filename)
        {
            int size = employees.Count;
            CSharpEmployeeOrDeveloperStruct[] array = new CSharpEmployeeOrDeveloperStruct[size];

            for (int i = 0; i < size; i++)
            {
                var employee = employees[i];
                var employee_data = new CSharpEmployeeStruct
                {
                    id = employee.Id,
                    name = employee.Name,
                    age = employee.Age,
                    experience = employee.Experience,
                    salary = employee.Salary,
                };
                if (employee is ShpaginDeveloper developer)
                {                    
                    array[i] = new CSharpEmployeeOrDeveloperStruct
                    {
                        is_developer = true,
                        employee_data = employee_data,
                        main_language = developer.MainLanguage,
                        is_full_stack = developer.IsFullStack,
                        current_project_name = developer.CurrentProjectName
                    };
                }
                else
                {
                    array[i] = new CSharpEmployeeOrDeveloperStruct
                    {
                        is_developer = false,
                        employee_data = employee_data
                    };
                }
            }
            var sb = new StringBuilder(filename);
            SaveObjects(sb, size, array);
        }

        public void LoadFromFile(string filename)
        {
            clear();
            var sb = new StringBuilder(filename);
            int size = GetObjectsSize(sb);

            CSharpEmployeeOrDeveloperStruct[] array = new CSharpEmployeeOrDeveloperStruct[size];
            LoadObjects(sb, array);

            foreach (var item in array)
            {
                if (!item.is_developer)
                {
                    ShpaginEmployee employee = new()
                    {
                        Name = item.employee_data.name,
                        Age = item.employee_data.age,
                        Experience = item.employee_data.experience,
                        Salary = item.employee_data.salary
                    };
                    employees.Add(employee);
                }
                else
                {
                    ShpaginDeveloper developer = new()
                    {
                        Id = item.employee_data.id,
                        Name = item.employee_data.name,
                        Age = item.employee_data.age,
                        Experience = item.employee_data.experience,
                        Salary = item.employee_data.salary,
                        CurrentProjectName = item.current_project_name,
                        IsFullStack = item.is_full_stack,
                        MainLanguage = item.main_language
                    };
                    employees.Add(developer);
                }
            }
        }
    }
}
