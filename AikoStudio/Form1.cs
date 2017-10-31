using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AikoStudio
{
    public partial class Form1 : Form
    {
        public AikoDbEntities context = new AikoDbEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSpecialityColumnDataSource();
            SetDepartmentColumnDataSource();
            SetOtherColumnDataSource();
        }

        private void SetOtherColumnDataSource()
        {
            //select spec.Code, spec.LongName, sub.Name, d.LongName, g.Year, g.Semester, g.Contingent, sub.LectureQty, 
            //    sub.SeminarQty, sub.LaboratoryQty, sub.LectureCreditQty, sub.SeminarCreditQty, sub.LaboratoryCreditQty, 
            //    sub.OtherCreditQty, sub.AllCreditQty
            //  from LoadCalculation ld
            //    inner join Subject sub
            //      on ld.SubjectId = sub.Id
            //      inner join GroupOfStudents g
            //        on g.Id = ld.GroupId
            //        inner join Specialty spec
            //          on spec.Id = g.SpecialtyId
            //          inner join Department d
            //            on d.Id = g.DepartmentId

            var query = from ld in context.LoadCalculations
                        join sub in context.Subjects
                          on ld.SubjectId equals sub.Id
                        join g in context.GroupOfStudents
                          on ld.GroupId equals g.Id
                        join spec in context.Specialties
                          on g.SpecialtyId equals spec.Id
                        join d in context.Departments
                          on g.DepartmentId equals d.Id
                        orderby ld.Id ascending
                        select new
                        {
                            g.SpecialtyId,
                            sub.Name,
                            g.DepartmentId,
                            g.Year,
                            g.Semester,
                            g.Contingent,
                            sub.LectureQty,
                            sub.SeminarQty,
                            sub.LaboratoryQty,
                            sub.LectureCreditQty,
                            sub.SeminarCreditQty,
                            sub.LaboratoryCreditQty,
                            sub.OtherCreditQty,
                            sub.AllCreditQty
                        };

            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (var q in query)
            {
                dataGridView1.Rows[i].Cells[0].Value = q.SpecialtyId.ToString();
                dataGridView1.Rows[i].Cells[1].Value = q.Name;
                dataGridView1.Rows[i].Cells[2].Value = q.DepartmentId.ToString();
                dataGridView1.Rows[i].Cells[3].Value = q.Year.ToString();
                dataGridView1.Rows[i].Cells[4].Value = q.Semester.ToString();
                dataGridView1.Rows[i].Cells[5].Value = q.Contingent.ToString();
                dataGridView1.Rows[i].Cells[6].Value = q.LectureQty.ToString();
                dataGridView1.Rows[i].Cells[7].Value = q.SeminarQty.ToString();
                dataGridView1.Rows[i].Cells[8].Value = q.LaboratoryQty.ToString();
                dataGridView1.Rows[i].Cells[9].Value = q.LectureCreditQty.ToString();
                dataGridView1.Rows[i].Cells[10].Value = q.SeminarCreditQty.ToString();
                dataGridView1.Rows[i].Cells[11].Value = q.LaboratoryCreditQty.ToString();
                dataGridView1.Rows[i].Cells[12].Value = q.OtherCreditQty.ToString();
                dataGridView1.Rows[i].Cells[13].Value = q.AllCreditQty.ToString();
                i++;
            }
            dataGridView1.Update();
        }

        private void SetSpecialityColumnDataSource()
        {
            var query = from spec in context.Specialties
                        orderby spec.Id
                        select spec;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            table.Columns.Add(new DataColumn() {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "SpecialtyId"
                }
            );
            table.Columns.Add(new DataColumn() {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "SpecialityDisplayName"
                } 
            );

            foreach (var element in query)
            {
                var row = table.NewRow();
                row["SpecialtyId"] = element.Id;
                row["SpecialityDisplayName"] = element.Code + ", " + element.LongName;
                table.Rows.Add(row);
            }

            this.SpecialityCol.DataSource = table;
            this.SpecialityCol.ValueMember = table.Columns["SpecialtyId"].ColumnName;
            this.SpecialityCol.DisplayMember = table.Columns["SpecialityDisplayName"].ColumnName;
        }
        
        private void SetDepartmentColumnDataSource()
        {
            var query = from dep in context.Departments
                        orderby dep.Id
                        select dep;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            table.Columns.Add( 
                new DataColumn()
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "DepartmentId"
                }
            );
            table.Columns.Add(
                new DataColumn()
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "DepartmentName"
                }
            );

            foreach (var element in query)
            {
                var row = table.NewRow();
                row["DepartmentId"] = element.Id;
                row["DepartmentName"] = element.LongName;
                table.Rows.Add(row);
            }

            this.DepartmentCol.DataSource = table;
            this.DepartmentCol.ValueMember = table.Columns["DepartmentId"].ColumnName;
            this.DepartmentCol.DisplayMember = table.Columns["DepartmentName"].ColumnName;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false; // helps to get rid of last empty row

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                IEnumerable<DataGridViewCell> cellsWithValuesInRows = from DataGridViewCell cell in row.Cells
                                                                      where string.IsNullOrEmpty((string)cell.Value)
                                                                      select cell;

                if (cellsWithValuesInRows != null && cellsWithValuesInRows.Any())
                {
                    //Then cells with null or empty values where found  
                    MessageBox.Show("Не все ячейки заполнены!!!");
                    return;
                }
            }

            //MessageBox.Show(dataGridView1.Rows.Count.ToString() + " " + dataGridView1.Rows[0].Cells.Count.ToString());
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int specId = int.Parse(row.Cells[0].Value.ToString());
                string subName = row.Cells[1].Value.ToString();
                int depId = int.Parse(row.Cells[2].Value.ToString());
                int year = int.Parse(row.Cells[3].Value.ToString());
                int semester = int.Parse(row.Cells[4].Value.ToString());
                int cont = int.Parse(row.Cells[5].Value.ToString());
                int lectQty = int.Parse(row.Cells[6].Value.ToString());
                int seminQty = int.Parse(row.Cells[7].Value.ToString());
                int labQty = int.Parse(row.Cells[8].Value.ToString());
                int lectCredQty = int.Parse(row.Cells[9].Value.ToString());
                int seminCredQty = int.Parse(row.Cells[10].Value.ToString());
                int labCredQty = int.Parse(row.Cells[11].Value.ToString());
                int otherCredQty = int.Parse(row.Cells[12].Value.ToString());
                int allCredQty = int.Parse(row.Cells[13].Value.ToString());

                Subject subject = context.Subjects.Where(subj => subj.Name == subName).FirstOrDefault<Subject>();
                #region AddOrUpdateSubject
                if (subject == null)
                {
                    subject = new Subject()
                    {
                        Name = subName,
                        LectureQty = lectQty,
                        SeminarQty = seminQty,
                        LaboratoryQty = labQty,
                        LectureCreditQty = lectCredQty,
                        SeminarCreditQty = seminCredQty,
                        LaboratoryCreditQty = labCredQty,
                        OtherCreditQty = otherCredQty,
                        AllCreditQty = allCredQty
                    };
                    context.Subjects.Add(subject);
                }
                else
                {
                    subject.Name = subName;
                    subject.LectureQty = lectQty;
                    subject.SeminarQty = seminQty;
                    subject.LaboratoryQty = labQty;
                    subject.LectureCreditQty = lectCredQty;
                    subject.SeminarCreditQty = seminCredQty;
                    subject.LaboratoryCreditQty = labCredQty;
                    subject.OtherCreditQty = otherCredQty;
                    subject.AllCreditQty = allCredQty;
                    context.Entry(subject).State = System.Data.Entity.EntityState.Modified;
                }
                #endregion AddOrUpdateSubject

                GroupOfStudents group = context.GroupOfStudents.Where(gr => gr.SpecialtyId == specId && gr.DepartmentId == depId).FirstOrDefault<GroupOfStudents>();
                #region AddOrUpdateGroupOfStudents
                if (group == null)
                {
                    group = new GroupOfStudents()
                    {
                        SpecialtyId = specId,
                        DepartmentId = depId,
                        Contingent = cont,
                        Year = year,
                        Semester = semester
                    };
                    context.GroupOfStudents.Add(group);
                }
                else
                {
                    group.SpecialtyId = specId;
                    group.DepartmentId = depId;
                    group.Contingent = cont;
                    group.Year = year;
                    group.Semester = semester;
                    context.Entry(group).State = System.Data.Entity.EntityState.Modified;
                }
                #endregion AddOrUpdateGroupOfStudents

                LoadCalculation load = context.LoadCalculations.Where(ld => ld.GroupId == group.Id && ld.SubjectId == subject.Id).FirstOrDefault<LoadCalculation>();
                if (load == null)
                {
                    load = new LoadCalculation()
                    {
                        SubjectId = subject.Id,
                        GroupId = group.Id
                    };
                    context.LoadCalculations.Add(load);
                }

                context.SaveChanges();
            }
        }
    }
}
