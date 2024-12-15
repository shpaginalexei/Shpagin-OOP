namespace CSharpWithForms
{
    public enum LanguageEnum
    {
        Empty, C, CPP, C_Sharp, Python, Java, JavaScript, Go, TypeScript, PHP, Rust, Ruby, Kotlin, Swift,
    };

    public partial class EditForm : Form
    {
        private bool IsEdit {  get; set; }
        public ShpaginEmployee Employee { get; set; }

        public EditForm(ShpaginEmployee Employee, bool IsEdit = true)
        {
            InitializeComponent();
            this.Employee = Employee;
            this.IsEdit = IsEdit;

            MainLanguageValue.DataSource = Enum.GetValues(typeof(LanguageEnum));
            FillFields();
            NameValue.Focus(); // ???
        }

        private void FillFields()
        {
            NameValue.Text = Employee.Name;
            AgeValue.Value = Employee.Age;
            ExperienceValue.Value = Employee.Experience;
            SalaryValue.Text = Employee.Salary.ToString();

            if (IsEdit)
            {
                Text = "Редактирование";
                if (Employee is ShpaginDeveloper Developer)
                {
                    radioButtonEmployee.Enabled = false;
                    radioButtonDeveloper.Checked = true;
                    MainLanguageValue.SelectedIndex = MainLanguageValue.FindStringExact(Developer.MainLanguage);
                    IsFullStackValue.Checked = Developer.IsFullStack;
                    CurrentProjectNameValue.Text = Developer.CurrentProjectName;
                }
                else
                {
                    radioButtonDeveloper.Enabled = false;
                    radioButtonEmployee.Checked = true;
                    SetOptionalFieldVisible(false);
                }
            }
            else
            {
                Text = "Добавить";
                SetOptionalFieldVisible(false);
            }
            ExperienceValue.Maximum = Employee.Age;
        }

        public void SetOptionalFieldVisible(bool visible)
        {
            labelMainLanguage.Visible = visible;
            MainLanguageValue.Visible = visible;
            IsFullStackValue.Visible = visible;
            labelCurrentProjectName.Visible = visible;
            CurrentProjectNameValue.Visible = visible;
        }

        private void radioButtonEmployee_CheckedChanged(object sender, EventArgs e)
        {
            SetOptionalFieldVisible(false);
        }

        private void radioButtonDeveloper_CheckedChanged(object sender, EventArgs e)
        {
            SetOptionalFieldVisible(true);
        }

        private void AgeValue_ValueChanged(object sender, EventArgs e)
        {
            ExperienceValue.Maximum = AgeValue.Value;
        }

        private void SalaryValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            Employee.Name = NameValue.Text;
            Employee.Age = (int)AgeValue.Value;
            Employee.Experience = (int)ExperienceValue.Value;
            Employee.Salary = int.Parse(SalaryValue.Text);
            if (!IsEdit && radioButtonDeveloper.Checked)
            {
                Employee = new ShpaginDeveloper(Employee);
            }
            if (Employee is ShpaginDeveloper Developer)
            {
                Developer.MainLanguage = MainLanguageValue.Text;
                Developer.IsFullStack = IsFullStackValue.Checked;
                Developer.CurrentProjectName = CurrentProjectNameValue.Text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
