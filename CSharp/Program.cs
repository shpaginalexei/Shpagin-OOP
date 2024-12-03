namespace CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShpaginCompany company = new ShpaginCompany();

            string directory_path = "D:\\5 семестр\\Объектно-ориентированное проектирование и программирование\\Shpagin OOP\\saves";
            if (!Directory.Exists(directory_path))
            {
                Directory.CreateDirectory(directory_path);
            }
            company.set_directory($"{directory_path}\\");

            while (true)
            {
                Menu.MainMenu(company);
            }
        }
    }
}
