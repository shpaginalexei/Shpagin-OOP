namespace CSharpWithForms
{
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

        public ShpaginDeveloper(ShpaginEmployee employee)
            : base(employee)
        {
            MainLanguage = "";
            IsFullStack = false;
            CurrentProjectName = "";
        }
    }
}
