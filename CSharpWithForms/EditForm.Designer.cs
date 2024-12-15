namespace CSharpWithForms
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCancel = new Button();
            radioPanel = new FlowLayoutPanel();
            radioButtonEmployee = new RadioButton();
            radioButtonDeveloper = new RadioButton();
            buttonsPanel = new FlowLayoutPanel();
            buttonDone = new Button();
            tablePanel = new TableLayoutPanel();
            CurrentProjectNameValue = new TextBox();
            labelCurrentProjectName = new Label();
            labelMainLanguage = new Label();
            SalaryValue = new TextBox();
            labelSalary = new Label();
            labelExperience = new Label();
            labelName = new Label();
            labelAge = new Label();
            NameValue = new TextBox();
            AgeValue = new NumericUpDown();
            ExperienceValue = new NumericUpDown();
            IsFullStackValue = new CheckBox();
            MainLanguageValue = new ComboBox();
            radioPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AgeValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExperienceValue).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom;
            buttonCancel.AutoSize = true;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(301, 10);
            buttonCancel.Margin = new Padding(10);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(151, 32);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Отмена";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // radioPanel
            // 
            radioPanel.AutoSize = true;
            radioPanel.Controls.Add(radioButtonEmployee);
            radioPanel.Controls.Add(radioButtonDeveloper);
            radioPanel.Dock = DockStyle.Top;
            radioPanel.Location = new Point(0, 0);
            radioPanel.Name = "radioPanel";
            radioPanel.Size = new Size(462, 36);
            radioPanel.TabIndex = 21;
            radioPanel.WrapContents = false;
            // 
            // radioButtonEmployee
            // 
            radioButtonEmployee.Anchor = AnchorStyles.Left;
            radioButtonEmployee.Checked = true;
            radioButtonEmployee.Location = new Point(20, 3);
            radioButtonEmployee.Margin = new Padding(20, 3, 3, 3);
            radioButtonEmployee.Name = "radioButtonEmployee";
            radioButtonEmployee.Size = new Size(146, 30);
            radioButtonEmployee.TabIndex = 0;
            radioButtonEmployee.TabStop = true;
            radioButtonEmployee.Text = "Сотрудник";
            radioButtonEmployee.UseVisualStyleBackColor = true;
            radioButtonEmployee.CheckedChanged += radioButtonEmployee_CheckedChanged;
            // 
            // radioButtonDeveloper
            // 
            radioButtonDeveloper.Anchor = AnchorStyles.Right;
            radioButtonDeveloper.Location = new Point(172, 3);
            radioButtonDeveloper.Name = "radioButtonDeveloper";
            radioButtonDeveloper.Size = new Size(146, 30);
            radioButtonDeveloper.TabIndex = 1;
            radioButtonDeveloper.Text = "Разработчик";
            radioButtonDeveloper.UseVisualStyleBackColor = true;
            radioButtonDeveloper.CheckedChanged += radioButtonDeveloper_CheckedChanged;
            // 
            // buttonsPanel
            // 
            buttonsPanel.AutoSize = true;
            buttonsPanel.Controls.Add(buttonCancel);
            buttonsPanel.Controls.Add(buttonDone);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.Location = new Point(0, 381);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.RightToLeft = RightToLeft.Yes;
            buttonsPanel.Size = new Size(462, 52);
            buttonsPanel.TabIndex = 22;
            // 
            // buttonDone
            // 
            buttonDone.Anchor = AnchorStyles.Bottom;
            buttonDone.AutoSize = true;
            buttonDone.FlatStyle = FlatStyle.Flat;
            buttonDone.Location = new Point(130, 10);
            buttonDone.Margin = new Padding(10);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(151, 32);
            buttonDone.TabIndex = 1;
            buttonDone.Text = "ОК";
            buttonDone.Click += buttonDone_Click;
            // 
            // tablePanel
            // 
            tablePanel.AllowDrop = true;
            tablePanel.ColumnCount = 2;
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tablePanel.Controls.Add(CurrentProjectNameValue, 1, 6);
            tablePanel.Controls.Add(labelCurrentProjectName, 0, 6);
            tablePanel.Controls.Add(labelMainLanguage, 0, 4);
            tablePanel.Controls.Add(SalaryValue, 1, 3);
            tablePanel.Controls.Add(labelSalary, 0, 3);
            tablePanel.Controls.Add(labelExperience, 0, 2);
            tablePanel.Controls.Add(labelName, 0, 0);
            tablePanel.Controls.Add(labelAge, 0, 1);
            tablePanel.Controls.Add(NameValue, 1, 0);
            tablePanel.Controls.Add(AgeValue, 1, 1);
            tablePanel.Controls.Add(ExperienceValue, 1, 2);
            tablePanel.Controls.Add(IsFullStackValue, 0, 5);
            tablePanel.Controls.Add(MainLanguageValue, 1, 4);
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.Location = new Point(0, 36);
            tablePanel.Name = "tablePanel";
            tablePanel.Padding = new Padding(10, 0, 10, 0);
            tablePanel.RowCount = 8;
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.RowStyles.Add(new RowStyle());
            tablePanel.Size = new Size(462, 345);
            tablePanel.TabIndex = 28;
            // 
            // CurrentProjectNameValue
            // 
            CurrentProjectNameValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CurrentProjectNameValue.Location = new Point(278, 256);
            CurrentProjectNameValue.MaxLength = 100;
            CurrentProjectNameValue.Name = "CurrentProjectNameValue";
            CurrentProjectNameValue.Size = new Size(171, 27);
            CurrentProjectNameValue.TabIndex = 19;
            // 
            // labelCurrentProjectName
            // 
            labelCurrentProjectName.AutoSize = true;
            labelCurrentProjectName.Location = new Point(20, 260);
            labelCurrentProjectName.Margin = new Padding(10);
            labelCurrentProjectName.Name = "labelCurrentProjectName";
            labelCurrentProjectName.Size = new Size(121, 20);
            labelCurrentProjectName.TabIndex = 18;
            labelCurrentProjectName.Text = "Текущий проект";
            // 
            // labelMainLanguage
            // 
            labelMainLanguage.AutoSize = true;
            labelMainLanguage.Location = new Point(20, 170);
            labelMainLanguage.Margin = new Padding(10);
            labelMainLanguage.Name = "labelMainLanguage";
            labelMainLanguage.Size = new Size(104, 20);
            labelMainLanguage.TabIndex = 14;
            labelMainLanguage.Text = "Основной ЯП";
            // 
            // SalaryValue
            // 
            SalaryValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SalaryValue.Location = new Point(278, 126);
            SalaryValue.MaxLength = 9;
            SalaryValue.Name = "SalaryValue";
            SalaryValue.Size = new Size(171, 27);
            SalaryValue.TabIndex = 13;
            SalaryValue.KeyPress += SalaryValue_KeyPress;
            // 
            // labelSalary
            // 
            labelSalary.AutoSize = true;
            labelSalary.Location = new Point(20, 130);
            labelSalary.Margin = new Padding(10);
            labelSalary.Name = "labelSalary";
            labelSalary.Size = new Size(144, 20);
            labelSalary.TabIndex = 8;
            labelSalary.Text = "Зарплата (руб/мес)";
            // 
            // labelExperience
            // 
            labelExperience.AutoSize = true;
            labelExperience.Location = new Point(20, 90);
            labelExperience.Margin = new Padding(10);
            labelExperience.Name = "labelExperience";
            labelExperience.Size = new Size(135, 20);
            labelExperience.TabIndex = 6;
            labelExperience.Text = "Стаж работы (лет)";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 10);
            labelName.Margin = new Padding(10);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Имя";
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(20, 50);
            labelAge.Margin = new Padding(10);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(64, 20);
            labelAge.TabIndex = 2;
            labelAge.Text = "Возраст";
            // 
            // NameValue
            // 
            NameValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            NameValue.Location = new Point(278, 6);
            NameValue.MaxLength = 100;
            NameValue.Name = "NameValue";
            NameValue.Size = new Size(171, 27);
            NameValue.TabIndex = 9;
            // 
            // AgeValue
            // 
            AgeValue.Anchor = AnchorStyles.Right;
            AgeValue.Location = new Point(396, 46);
            AgeValue.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            AgeValue.Name = "AgeValue";
            AgeValue.Size = new Size(53, 27);
            AgeValue.TabIndex = 11;
            AgeValue.TextAlign = HorizontalAlignment.Right;
            AgeValue.Value = new decimal(new int[] { 18, 0, 0, 0 });
            AgeValue.ValueChanged += AgeValue_ValueChanged;
            // 
            // ExperienceValue
            // 
            ExperienceValue.Anchor = AnchorStyles.Right;
            ExperienceValue.Location = new Point(396, 86);
            ExperienceValue.Name = "ExperienceValue";
            ExperienceValue.Size = new Size(53, 27);
            ExperienceValue.TabIndex = 12;
            ExperienceValue.TextAlign = HorizontalAlignment.Right;
            // 
            // IsFullStackValue
            // 
            IsFullStackValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tablePanel.SetColumnSpan(IsFullStackValue, 2);
            IsFullStackValue.Location = new Point(20, 210);
            IsFullStackValue.Margin = new Padding(10);
            IsFullStackValue.Name = "IsFullStackValue";
            IsFullStackValue.RightToLeft = RightToLeft.Yes;
            IsFullStackValue.Size = new Size(422, 30);
            IsFullStackValue.TabIndex = 20;
            IsFullStackValue.Text = "Full Stack";
            IsFullStackValue.TextAlign = ContentAlignment.MiddleRight;
            IsFullStackValue.UseVisualStyleBackColor = true;
            // 
            // MainLanguageValue
            // 
            MainLanguageValue.Anchor = AnchorStyles.Right;
            MainLanguageValue.FormattingEnabled = true;
            MainLanguageValue.Location = new Point(298, 166);
            MainLanguageValue.Name = "MainLanguageValue";
            MainLanguageValue.Size = new Size(151, 28);
            MainLanguageValue.TabIndex = 21;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 433);
            Controls.Add(tablePanel);
            Controls.Add(buttonsPanel);
            Controls.Add(radioPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditForm";
            radioPanel.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);
            buttonsPanel.PerformLayout();
            tablePanel.ResumeLayout(false);
            tablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AgeValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExperienceValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private FlowLayoutPanel radioPanel;
        private RadioButton radioButtonEmployee;
        private RadioButton radioButtonDeveloper;
        private FlowLayoutPanel buttonsPanel;
        private Button buttonDone;
        private TableLayoutPanel tablePanel;
        private TextBox CurrentProjectNameValue;
        private Label labelCurrentProjectName;
        private Label labelMainLanguage;
        private TextBox SalaryValue;
        private Label labelSalary;
        private Label labelExperience;
        private Label labelName;
        private Label labelAge;
        private TextBox NameValue;
        private NumericUpDown AgeValue;
        private NumericUpDown ExperienceValue;
        private CheckBox IsFullStackValue;
        private ComboBox MainLanguageValue;
    }
}