using System.ComponentModel;

namespace CSharpWithForms
{
    public partial class MainForm : Form
    {
        public ShpaginCompany company;
        private string FileName = "";

        public MainForm(ShpaginCompany company)
        {
            InitializeComponent();
            this.company = company;
            saveFileDialog.InitialDirectory = company.Path;
            CompanyIsEmptyUpdate();
        }

        public void LoadFromFile()
        {
            try
            {
                company.LoadFromFile(FileName);
                toolStripStatusLabel.Text = $"Файл открыт ({Path.GetFileName(FileName)})";
            }
            catch
            {
                toolStripStatusLabel.Text = "Ошибка открытия файла";
            }
        }

        public void SaveToFile()
        {
            try
            {
                company.SaveToFile(FileName);
                toolStripStatusLabel.Text = $"Файл сохранен ({Path.GetFileName(FileName)})";
            }
            catch
            {
                toolStripStatusLabel.Text = "Ошибка сохранения файла";
            }
        }
        public BindingList<string> GetEmployeesList()
        {
            var list = new BindingList<string>();
            foreach (ShpaginEmployee employee in company.employees)
            {
                list.Add(employee.GetNameForList());
            }
            return list;
        }

        public void CompanyIsEmptyUpdate()
        {
            if (company.Empty)
            {
                labelHeader.Text = "Пока никого нет..";
                SetBaseFieldVisible(false);
                SetOptionalFieldVisible(false);
                buttonDelete.Visible = false;
                buttonEdit.Visible = false;
            }
            else
            {
                SetBaseFieldVisible(true);
                buttonDelete.Visible = true;
                buttonEdit.Visible = true;
            }

        }

        public void SetBaseFieldVisible(bool visible)
        {
            labelName.Visible = visible;
            labelNameValue.Visible = visible;
            labelAge.Visible = visible;
            labelAgeValue.Visible = visible;
            labelExperience.Visible = visible;
            labelExperienceValue.Visible = visible;
            labelSalary.Visible = visible;
            labelSalaryValue.Visible = visible;
        }

        public void SetOptionalFieldVisible(bool visible)
        {
            labelMainLanguage.Visible = visible;
            labelMainLanguageValue.Visible = visible;
            labelIsFullStack.Visible = visible;
            labelIsFullStackValue.Visible = visible;
            labelCurrentProjectName.Visible = visible;
            labelCurrentProjectNameValue.Visible = visible;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Открытие...";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                LoadFromFile();
                listBox.DataSource = GetEmployeesList();
                listBox.SelectedIndex = listBox.Items.Count == 0 ? -1 : 0;
            }
            else
            {
                toolStripStatusLabel.Text = "";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Сохранение...";
            if (FileName is "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                SaveToFile();
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Сохранение как...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = saveFileDialog.FileName;
                SaveToFile();
            }
            else
            {
                toolStripStatusLabel.Text = "";
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyIsEmptyUpdate();

            int idx = listBox.SelectedIndex;
            ShpaginEmployee employee = company.employees[idx];

            labelHeader.Text = $"Сотрудник #{employee.Id}";

            labelNameValue.Text = employee.Name;
            labelAgeValue.Text = employee.Age.ToString();
            labelExperienceValue.Text = employee.Experience.ToString();
            labelSalaryValue.Text = employee.Salary.ToString();

            if (employee is ShpaginDeveloper developer)
            {
                SetOptionalFieldVisible(true);
                labelMainLanguageValue.Text = developer.MainLanguage;
                labelIsFullStackValue.Text = developer.IsFullStack ? "Да" : "Нет";
                labelCurrentProjectNameValue.Text = developer.CurrentProjectName;
            }
            else
            {
                SetOptionalFieldVisible(false);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Новый файл";
            company.clear();
            listBox.DataSource = GetEmployeesList();
            listBox.SelectedIndex = listBox.Items.Count == 0 ? -1 : 0;
            CompanyIsEmptyUpdate();
            FileName = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int currentRow = listBox.SelectedIndex;
            if (currentRow < 0)
            {
                return;
            }
            company.DeleteEmployee(currentRow);
            listBox.DataSource = GetEmployeesList();
            listBox.SelectedIndex = listBox.Items.Count == 0 ? -1 : 0;
            CompanyIsEmptyUpdate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ShpaginEmployee Employee = new();
            EditForm dialog = new EditForm(Employee, IsEdit: false);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                company.employees.Add(dialog.Employee);
            }
            else
            {
                ShpaginEmployee.MaxId -= 1;
            }
            listBox.DataSource = GetEmployeesList();
            listBox.SelectedIndex = company.employees.Count - 1;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (company.Empty)
            {
                return;
            }
            ShpaginEmployee Employee = company.employees[listBox.SelectedIndex];
            int idx = listBox.SelectedIndex;
            EditForm dialog = new EditForm(Employee);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                company.employees[listBox.SelectedIndex] = dialog.Employee;
            }
            listBox.DataSource = GetEmployeesList();
            listBox.SelectedIndex = idx;
        }
    }
}
