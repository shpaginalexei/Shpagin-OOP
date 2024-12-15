namespace CSharpWithForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog = new OpenFileDialog();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            labelHeader = new Label();
            panelButtons = new FlowLayoutPanel();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            listBox = new ListBox();
            tablePanel = new TableLayoutPanel();
            labelCurrentProjectNameValue = new Label();
            labelCurrentProjectName = new Label();
            labelIsFullStackValue = new Label();
            labelIsFullStack = new Label();
            labelMainLanguageValue = new Label();
            labelMainLanguage = new Label();
            labelSalaryValue = new Label();
            labelExperienceValue = new Label();
            labelAgeValue = new Label();
            labelNameValue = new Label();
            labelSalary = new Label();
            labelExperience = new Label();
            labelName = new Label();
            labelAge = new Label();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            panelButtons.SuspendLayout();
            tablePanel.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.Filter = "Текстовый документ|*.txt|Все файлы|*.*";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(782, 28);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(59, 24);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(288, 26);
            newToolStripMenuItem.Text = "Новый";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(288, 26);
            openToolStripMenuItem.Text = "Открыть";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(288, 26);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(288, 26);
            saveAsToolStripMenuItem.Text = "Сохранить как..";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(288, 26);
            quitToolStripMenuItem.Text = "Выход";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.AddExtension = false;
            saveFileDialog.Filter = "Текстовый документ|*.txt|Все файлы|*.*";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 531);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(782, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 16);
            // 
            // labelHeader
            // 
            labelHeader.Dock = DockStyle.Top;
            labelHeader.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelHeader.Location = new Point(179, 76);
            labelHeader.Name = "labelHeader";
            labelHeader.Padding = new Padding(20, 5, 5, 5);
            labelHeader.Size = new Size(603, 35);
            labelHeader.TabIndex = 6;
            labelHeader.Text = "Пока никого нет..";
            labelHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelButtons
            // 
            panelButtons.AllowDrop = true;
            panelButtons.Controls.Add(buttonAdd);
            panelButtons.Controls.Add(buttonEdit);
            panelButtons.Controls.Add(buttonDelete);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 28);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(782, 48);
            panelButtons.TabIndex = 19;
            panelButtons.WrapContents = false;
            // 
            // buttonAdd
            // 
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Location = new Point(10, 10);
            buttonAdd.Margin = new Padding(10);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 30);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Location = new Point(124, 10);
            buttonEdit.Margin = new Padding(10);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(121, 30);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Редактировать";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Location = new Point(265, 10);
            buttonDelete.Margin = new Padding(10);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 30);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // listBox
            // 
            listBox.BorderStyle = BorderStyle.None;
            listBox.Dock = DockStyle.Left;
            listBox.HorizontalScrollbar = true;
            listBox.Location = new Point(0, 76);
            listBox.Name = "listBox";
            listBox.Size = new Size(179, 455);
            listBox.TabIndex = 1;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // tablePanel
            // 
            tablePanel.AllowDrop = true;
            tablePanel.AutoScroll = true;
            tablePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tablePanel.ColumnCount = 2;
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePanel.Controls.Add(labelCurrentProjectNameValue, 1, 6);
            tablePanel.Controls.Add(labelCurrentProjectName, 0, 6);
            tablePanel.Controls.Add(labelIsFullStackValue, 1, 5);
            tablePanel.Controls.Add(labelIsFullStack, 0, 5);
            tablePanel.Controls.Add(labelMainLanguageValue, 1, 4);
            tablePanel.Controls.Add(labelMainLanguage, 0, 4);
            tablePanel.Controls.Add(labelSalaryValue, 1, 3);
            tablePanel.Controls.Add(labelExperienceValue, 1, 2);
            tablePanel.Controls.Add(labelAgeValue, 1, 1);
            tablePanel.Controls.Add(labelNameValue, 1, 0);
            tablePanel.Controls.Add(labelSalary, 0, 3);
            tablePanel.Controls.Add(labelExperience, 0, 2);
            tablePanel.Controls.Add(labelName, 0, 0);
            tablePanel.Controls.Add(labelAge, 0, 1);
            tablePanel.Dock = DockStyle.Fill;
            tablePanel.Location = new Point(179, 111);
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
            tablePanel.Size = new Size(603, 420);
            tablePanel.TabIndex = 22;
            // 
            // labelCurrentProjectNameValue
            // 
            labelCurrentProjectNameValue.AutoSize = true;
            labelCurrentProjectNameValue.Location = new Point(311, 250);
            labelCurrentProjectNameValue.Margin = new Padding(10);
            labelCurrentProjectNameValue.Name = "labelCurrentProjectNameValue";
            labelCurrentProjectNameValue.Size = new Size(0, 20);
            labelCurrentProjectNameValue.TabIndex = 18;
            // 
            // labelCurrentProjectName
            // 
            labelCurrentProjectName.AutoSize = true;
            labelCurrentProjectName.Location = new Point(20, 250);
            labelCurrentProjectName.Margin = new Padding(10);
            labelCurrentProjectName.Name = "labelCurrentProjectName";
            labelCurrentProjectName.Size = new Size(121, 20);
            labelCurrentProjectName.TabIndex = 17;
            labelCurrentProjectName.Text = "Текущий проект";
            // 
            // labelIsFullStackValue
            // 
            labelIsFullStackValue.AutoSize = true;
            labelIsFullStackValue.Location = new Point(311, 210);
            labelIsFullStackValue.Margin = new Padding(10);
            labelIsFullStackValue.Name = "labelIsFullStackValue";
            labelIsFullStackValue.Size = new Size(0, 20);
            labelIsFullStackValue.TabIndex = 16;
            // 
            // labelIsFullStack
            // 
            labelIsFullStack.AutoSize = true;
            labelIsFullStack.Location = new Point(20, 210);
            labelIsFullStack.Margin = new Padding(10);
            labelIsFullStack.Name = "labelIsFullStack";
            labelIsFullStack.Size = new Size(71, 20);
            labelIsFullStack.TabIndex = 15;
            labelIsFullStack.Text = "Full Stack";
            // 
            // labelMainLanguageValue
            // 
            labelMainLanguageValue.AutoSize = true;
            labelMainLanguageValue.Location = new Point(311, 170);
            labelMainLanguageValue.Margin = new Padding(10);
            labelMainLanguageValue.Name = "labelMainLanguageValue";
            labelMainLanguageValue.Size = new Size(0, 20);
            labelMainLanguageValue.TabIndex = 14;
            // 
            // labelMainLanguage
            // 
            labelMainLanguage.AutoSize = true;
            labelMainLanguage.Location = new Point(20, 170);
            labelMainLanguage.Margin = new Padding(10);
            labelMainLanguage.Name = "labelMainLanguage";
            labelMainLanguage.Size = new Size(104, 20);
            labelMainLanguage.TabIndex = 13;
            labelMainLanguage.Text = "Основной ЯП";
            // 
            // labelSalaryValue
            // 
            labelSalaryValue.AutoSize = true;
            labelSalaryValue.Location = new Point(311, 130);
            labelSalaryValue.Margin = new Padding(10);
            labelSalaryValue.Name = "labelSalaryValue";
            labelSalaryValue.Size = new Size(0, 20);
            labelSalaryValue.TabIndex = 12;
            // 
            // labelExperienceValue
            // 
            labelExperienceValue.AutoSize = true;
            labelExperienceValue.Location = new Point(311, 90);
            labelExperienceValue.Margin = new Padding(10);
            labelExperienceValue.Name = "labelExperienceValue";
            labelExperienceValue.Size = new Size(0, 20);
            labelExperienceValue.TabIndex = 11;
            // 
            // labelAgeValue
            // 
            labelAgeValue.AutoSize = true;
            labelAgeValue.Location = new Point(311, 50);
            labelAgeValue.Margin = new Padding(10);
            labelAgeValue.Name = "labelAgeValue";
            labelAgeValue.Size = new Size(0, 20);
            labelAgeValue.TabIndex = 10;
            // 
            // labelNameValue
            // 
            labelNameValue.AutoSize = true;
            labelNameValue.Location = new Point(311, 10);
            labelNameValue.Margin = new Padding(10);
            labelNameValue.Name = "labelNameValue";
            labelNameValue.Size = new Size(0, 20);
            labelNameValue.TabIndex = 9;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(tablePanel);
            Controls.Add(labelHeader);
            Controls.Add(listBox);
            Controls.Add(panelButtons);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Шпагин А.Ю. АС-22-05";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panelButtons.ResumeLayout(false);
            tablePanel.ResumeLayout(false);
            tablePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Panel panel2;
        private Label labelHeader;
        private FlowLayoutPanel panelButtons;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private ListBox listBox;
        private TableLayoutPanel tablePanel;
        private Label labelCurrentProjectNameValue;
        private Label labelCurrentProjectName;
        private Label labelIsFullStackValue;
        private Label labelIsFullStack;
        private Label labelMainLanguageValue;
        private Label labelMainLanguage;
        private Label labelSalaryValue;
        private Label labelExperienceValue;
        private Label labelAgeValue;
        private Label labelSalary;
        private Label labelExperience;
        private Label labelName;
        private Label labelAge;
        private Label labelNameValue;
    }
}
