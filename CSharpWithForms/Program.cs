namespace CSharpWithForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ShpaginCompany company = new();

            string directory_path = "D:\\5 семестр\\Объектно-ориентированное проектирование и программирование\\Shpagin OOP\\saves";
            if (!Directory.Exists(directory_path))
            {
                Directory.CreateDirectory(directory_path);
            }
            company.Path = $"{directory_path}\\";

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(company));
        }
    }
}