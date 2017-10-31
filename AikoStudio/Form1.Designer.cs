namespace AikoStudio
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SpecialityCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubjectNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.YearCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SemesterCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ContingentCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LectureQtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeminarQtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaboratoryQtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LectureCreditCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeminarCreditCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaboratoryCreditCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherCreditCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllCreditCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpecialityCol,
            this.SubjectNameCol,
            this.DepartmentCol,
            this.YearCol,
            this.SemesterCol,
            this.ContingentCol,
            this.LectureQtyCol,
            this.SeminarQtyCol,
            this.LaboratoryQtyCol,
            this.LectureCreditCol,
            this.SeminarCreditCol,
            this.LaboratoryCreditCol,
            this.OtherCreditCol,
            this.AllCreditCol});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(1375, 837);
            this.dataGridView1.TabIndex = 4;
            // 
            // SpecialityCol
            // 
            this.SpecialityCol.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.SpecialityCol.FillWeight = 218.6398F;
            this.SpecialityCol.HeaderText = "Специальность";
            this.SpecialityCol.MinimumWidth = 10;
            this.SpecialityCol.Name = "SpecialityCol";
            // 
            // SubjectNameCol
            // 
            this.SubjectNameCol.FillWeight = 203.8816F;
            this.SubjectNameCol.HeaderText = "Дисциплина";
            this.SubjectNameCol.Name = "SubjectNameCol";
            // 
            // DepartmentCol
            // 
            this.DepartmentCol.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.DepartmentCol.FillWeight = 106.599F;
            this.DepartmentCol.HeaderText = "Отделение";
            this.DepartmentCol.MinimumWidth = 10;
            this.DepartmentCol.Name = "DepartmentCol";
            // 
            // YearCol
            // 
            this.YearCol.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.YearCol.FillWeight = 79.17088F;
            this.YearCol.HeaderText = "Курс";
            this.YearCol.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.YearCol.Name = "YearCol";
            // 
            // SemesterCol
            // 
            this.SemesterCol.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.SemesterCol.FillWeight = 79.17088F;
            this.SemesterCol.HeaderText = "Семестр";
            this.SemesterCol.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.SemesterCol.Name = "SemesterCol";
            // 
            // ContingentCol
            // 
            this.ContingentCol.FillWeight = 79.17088F;
            this.ContingentCol.HeaderText = "Контингент";
            this.ContingentCol.Name = "ContingentCol";
            // 
            // LectureQtyCol
            // 
            this.LectureQtyCol.FillWeight = 79.17088F;
            this.LectureQtyCol.HeaderText = "Кол. лекций";
            this.LectureQtyCol.Name = "LectureQtyCol";
            this.LectureQtyCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LectureQtyCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SeminarQtyCol
            // 
            this.SeminarQtyCol.FillWeight = 79.17088F;
            this.SeminarQtyCol.HeaderText = "Кол. семинаров";
            this.SeminarQtyCol.Name = "SeminarQtyCol";
            this.SeminarQtyCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeminarQtyCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LaboratoryQtyCol
            // 
            this.LaboratoryQtyCol.FillWeight = 79.17088F;
            this.LaboratoryQtyCol.HeaderText = "Кол. лаб. занят.";
            this.LaboratoryQtyCol.Name = "LaboratoryQtyCol";
            this.LaboratoryQtyCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LaboratoryQtyCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LectureCreditCol
            // 
            this.LectureCreditCol.FillWeight = 79.17088F;
            this.LectureCreditCol.HeaderText = "Кред. Лек.";
            this.LectureCreditCol.Name = "LectureCreditCol";
            this.LectureCreditCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LectureCreditCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SeminarCreditCol
            // 
            this.SeminarCreditCol.FillWeight = 79.17088F;
            this.SeminarCreditCol.HeaderText = "Кред. Семин.";
            this.SeminarCreditCol.Name = "SeminarCreditCol";
            this.SeminarCreditCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeminarCreditCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LaboratoryCreditCol
            // 
            this.LaboratoryCreditCol.FillWeight = 79.17088F;
            this.LaboratoryCreditCol.HeaderText = "Кред. Лаб.";
            this.LaboratoryCreditCol.Name = "LaboratoryCreditCol";
            this.LaboratoryCreditCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LaboratoryCreditCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OtherCreditCol
            // 
            this.OtherCreditCol.FillWeight = 79.17088F;
            this.OtherCreditCol.HeaderText = "Прочие в кред";
            this.OtherCreditCol.Name = "OtherCreditCol";
            // 
            // AllCreditCol
            // 
            this.AllCreditCol.FillWeight = 79.17088F;
            this.AllCreditCol.HeaderText = "Всего кредитов";
            this.AllCreditCol.Name = "AllCreditCol";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1375, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItem1.Text = "Меню";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Удалить выделенные";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 836);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AikoStudio";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn SpecialityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNameCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn DepartmentCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn YearCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn SemesterCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContingentCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LectureQtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeminarQtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaboratoryQtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LectureCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeminarCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaboratoryCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllCreditCol;
    }
}

