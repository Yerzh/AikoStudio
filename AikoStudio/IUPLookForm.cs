using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AikoStudio
{
    public partial class IUPLookForm : Form
    {
        private AikoDbEntities context;

        public IUPLookForm()
        {
            InitializeComponent();
            context = new AikoDbEntities();
        }

        private void IUPLookForm_Load(object sender, EventArgs e)
        {
            teacherChoosingComboBox.Items.Clear();
            SetTeacherFioComboBoxDataSource();
        }

        private void SetTeacherFioComboBoxDataSource()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn()
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "TeacherId"
            }
            );
            table.Columns.Add(new DataColumn()
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "TeacherFIODisplayName"
            }
            );

            DataRow row;
            foreach (var element in from t in context.Teachers
                                    orderby t.Id
                                    select t)
            {
                row = table.NewRow();
                row["TeacherId"] = element.Id;
                row["TeacherFIODisplayName"] = element.Fio;
                table.Rows.Add(row);
            }

            this.teacherChoosingComboBox.DataSource = table;
            this.teacherChoosingComboBox.ValueMember = table.Columns["TeacherId"].ColumnName;
            this.teacherChoosingComboBox.DisplayMember = table.Columns["TeacherFIODisplayName"].ColumnName;
            this.teacherChoosingComboBox.SelectedItem = null;
        }

        private void teacherChoosingComboBox_Validating(object sender, CancelEventArgs e)
        {
            int? TeacherId = (int?)this.teacherChoosingComboBox.SelectedValue;
            if (TeacherId == null) return;
            if (TeacherId <= 0)
            {
                e.Cancel = true;
                this.teacherChoosingComboBox.Select(0, this.teacherChoosingComboBox.Text.Length);
                this.errorProvider1.SetError(teacherChoosingComboBox, "Значение не выбрано.");
            }
        }

        private void teacherChoosingComboBox_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(teacherChoosingComboBox, "");
        }

        private void teacherChoosingComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int TeacherId = (int)this.teacherChoosingComboBox.SelectedValue;
            if (TeacherId <= 0) return;

            var iup = from c in context.Curriculums
                        join gs in context.GroupSubjects
                          on c.GroupSubjectId equals gs.Id
                          join s in context.Subjects
                            on gs.SubjectId equals s.Id
                      where c.TeacherId == TeacherId
                      orderby gs.GroupOfStudents.Year, gs.GroupOfStudents.Semester
                      select new
                      {
                          Курс = gs.GroupOfStudents.Year,
                          Семестр = gs.GroupOfStudents.Semester,
                          Специальность = gs.GroupOfStudents.Specialty.Code + " - " + gs.GroupOfStudents.Specialty.LongName,
                          Дисциплина = s.Name,
                          Контингент = gs.GroupOfStudents.Contingent,
                          Отделение = gs.GroupOfStudents.Department.ShortName,
                          ЛекСемЛаб = s.LectureQty.ToString() + "/" + s.SeminarQty.ToString() + "/" + s.LaboratoryQty.ToString(),
                          Лекции = c.LectureCredits,
                          Семинарские = c.SeminarCredits,
                          Лабораторные = c.LaboratoryCredits,

                          Всего = c.TotalCredits
                      };

            
            dataGridView1.DataSource = iup.ToList();
        }
    }
}
