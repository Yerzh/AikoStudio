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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialityCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubjectNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.YearCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemesterCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TeacherTableEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1916, 1416);
            this.dataGridView1.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // SpecialityCol
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.SpecialityCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.SpecialityCol.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.SpecialityCol.FillWeight = 218.6398F;
            this.SpecialityCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.DepartmentCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DepartmentCol.HeaderText = "Отделение";
            this.DepartmentCol.MinimumWidth = 10;
            this.DepartmentCol.Name = "DepartmentCol";
            // 
            // YearCol
            // 
            this.YearCol.FillWeight = 79.17088F;
            this.YearCol.HeaderText = "Курс";
            this.YearCol.Name = "YearCol";
            this.YearCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.YearCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SemesterCol
            // 
            this.SemesterCol.FillWeight = 79.17088F;
            this.SemesterCol.HeaderText = "Семестр";
            this.SemesterCol.Name = "SemesterCol";
            this.SemesterCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SemesterCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1916, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.TeacherTableEditToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 19);
            this.toolStripMenuItem1.Text = "Меню";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // TeacherTableEditToolStripMenuItem
            // 
            this.TeacherTableEditToolStripMenuItem.Name = "TeacherTableEditToolStripMenuItem";
            this.TeacherTableEditToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.TeacherTableEditToolStripMenuItem.Text = "Редактировать таблицу преподавателей";
            this.TeacherTableEditToolStripMenuItem.Click += new System.EventHandler(this.TeacherTableEditToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 1053);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn SpecialityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNameCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn DepartmentCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemesterCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContingentCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LectureQtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeminarQtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaboratoryQtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LectureCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeminarCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaboratoryCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherCreditCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllCreditCol;
        private System.Windows.Forms.ToolStripMenuItem TeacherTableEditToolStripMenuItem;
    }
}

