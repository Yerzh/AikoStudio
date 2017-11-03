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
        private AikoDbEntities context;
        private DataTable cache;

        public Form1()
        {
            InitializeComponent();

            context = new AikoDbEntities();
            initCache();
        }

        private void initCache()
        {
            cache = new DataTable();
            DataColumn idColumn = new DataColumn("Id", typeof(int));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1;
            cache.PrimaryKey = new DataColumn[] { cache.Columns["Id"] };
            cache.Columns.Add(idColumn);
            cache.Columns.Add("GroupSubjectId", typeof(int));
            cache.Columns.Add("SpecialtyId", typeof(int));
            cache.Columns.Add("SpecialityName", typeof(string));
            cache.Columns.Add("SubjectId", typeof(int));
            cache.Columns.Add("SubjectName", typeof(string));
            cache.Columns.Add("DepartmentId", typeof(int));
            cache.Columns.Add("DepartmentName", typeof(string));
            cache.Columns.Add("Year", typeof(int));
            cache.Columns.Add("Semester", typeof(int));
            cache.Columns.Add("Contingent", typeof(int));
            cache.Columns.Add("LectureQty", typeof(float));
            cache.Columns.Add("SeminarQty", typeof(float));
            cache.Columns.Add("LaboratoryQty", typeof(float));
            cache.Columns.Add("LectureCreditQty", typeof(float));
            cache.Columns.Add("SeminarCreditQty", typeof(float));
            cache.Columns.Add("LaboratoryCreditQty", typeof(float));
            cache.Columns.Add("OtherCreditQty", typeof(float));
            cache.Columns.Add("AllCreditQty", typeof(float));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSpecialityColumnDataSource();
            SetDepartmentColumnDataSource();
            //SetOtherColumnDataSource();
            populateCache();
            populateDataGridView();
        }

        private void populateCache()
        {
            var query = from gs in context.GroupSubjects
                        join g in context.GroupOfStudents
                             on gs.GroupId equals g.Id
                        join sub in context.Subjects
                            on gs.SubjectId equals sub.Id
                        join spec in context.Specialties
                            on g.SpecialtyId equals spec.Id
                        join dep in context.Departments
                            on g.DepartmentId equals dep.Id
                        orderby gs.Id
                        select new
                        {
                            GroupSubjectId = gs.Id,
                            SpecialtyId = spec.Id,
                            SpecialityName = spec.Code + "," + spec.LongName,
                            SubjectId = sub.Id,
                            SubjectName = sub.Name,
                            DepartmentId = dep.Id,
                            DepartmentName = dep.LongName,
                            Year = g.Year,
                            Semester = g.Semester,
                            Contingent = g.Contingent,
                            LectureQty = sub.LectureQty,
                            SeminarQty = sub.SeminarQty,
                            LaboratoryQty = sub.LaboratoryQty,
                            LectureCreditQty = sub.LectureCreditQty,
                            SeminarCreditQty = sub.SeminarCreditQty,
                            LaboratoryCreditQty = sub.LaboratoryCreditQty,
                            OtherCreditQty = sub.OtherCreditQty,
                            AllCreditQty = sub.AllCreditQty
                        };

            foreach (var item in query)
            {
                DataRow row = cache.NewRow();
                row.ItemArray = new object[]
                {
                    null,
                    item.GroupSubjectId,
                    item.SpecialtyId,
                    item.SpecialityName,
                    item.SubjectId,
                    item.SubjectName,
                    item.DepartmentId,
                    item.DepartmentName,
                    item.Year,
                    item.Semester,
                    item.Contingent,
                    item.LectureQty,
                    item.SeminarQty,
                    item.LaboratoryQty,
                    item.LectureCreditQty,
                    item.SeminarCreditQty,
                    item.LaboratoryCreditQty,
                    item.OtherCreditQty,
                    item.AllCreditQty
                };
                cache.Rows.Add(row);
            }

            foreach (DataRow r in cache.Rows)
            {
                foreach (var cell in r.ItemArray)
                    Console.Write("\t{0}", cell);
                Console.WriteLine();
            }
        }

        private void populateDataGridView()
        {
            if (cache == null)
                throw new NullReferenceException("Кэш не может быть null");

            dataGridView1.Rows.Clear();
            foreach (DataRow r in cache.Rows)
            {
                object[] objs = r.ItemArray;
                int newRowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[newRowIndex].Cells[0].Value = objs[0];
                dataGridView1.Rows[newRowIndex].Cells[1].Value = objs[2];
                dataGridView1.Rows[newRowIndex].Cells[2].Value = objs[5];
                dataGridView1.Rows[newRowIndex].Cells[3].Value = objs[6];
                dataGridView1.Rows[newRowIndex].Cells[4].Value = objs[8];
                dataGridView1.Rows[newRowIndex].Cells[5].Value = objs[9];
                dataGridView1.Rows[newRowIndex].Cells[6].Value = objs[10];
                dataGridView1.Rows[newRowIndex].Cells[7].Value = objs[11];
                dataGridView1.Rows[newRowIndex].Cells[8].Value = objs[12];
                dataGridView1.Rows[newRowIndex].Cells[9].Value = objs[13];
                dataGridView1.Rows[newRowIndex].Cells[10].Value = objs[14];
                dataGridView1.Rows[newRowIndex].Cells[11].Value = objs[15];
                dataGridView1.Rows[newRowIndex].Cells[12].Value = objs[16];
                dataGridView1.Rows[newRowIndex].Cells[13].Value = objs[17];
                dataGridView1.Rows[newRowIndex].Cells[14].Value = objs[18];
            }
            dataGridView1.Update();
        }

        /*private void SetOtherColumnDataSource()
        {
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
        }*/

        private void SetSpecialityColumnDataSource()
        {
            DataTable table = new DataTable();
            //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            table.Columns.Add(new DataColumn() {
                    DataType = Type.GetType("System.Int32"),
                    ColumnName = "SpecialtyId"
                }
            );
            table.Columns.Add(new DataColumn() {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "SpecialityDisplayName"
                } 
            );

            foreach (var element in from spec in context.Specialties
                                     orderby spec.Id
                                     select spec)
            {
                var row = table.NewRow();
                row["SpecialtyId"] = element.Id;
                row["SpecialityDisplayName"] = element.Code + "," + element.LongName;
                table.Rows.Add(row);
            }

            this.SpecialityCol.DataSource = table;
            this.SpecialityCol.ValueMember = table.Columns["SpecialtyId"].ColumnName;
            this.SpecialityCol.DisplayMember = table.Columns["SpecialityDisplayName"].ColumnName;
        }
        
        private void SetDepartmentColumnDataSource()
        {
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            table.Columns.Add( 
                new DataColumn()
                {
                    DataType = Type.GetType("System.Int32"),
                    ColumnName = "DepartmentId"
                }
            );
            table.Columns.Add(
                new DataColumn()
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "DepartmentDisplayName"
                }
            );

            foreach (var element in from dep in context.Departments
                                    orderby dep.Id
                                    select dep)
            {
                var row = table.NewRow();
                row["DepartmentId"] = element.Id;
                row["DepartmentDisplayName"] = element.LongName;
                table.Rows.Add(row);
            }

            this.DepartmentCol.DataSource = table;
            this.DepartmentCol.ValueMember = table.Columns["DepartmentId"].ColumnName;
            this.DepartmentCol.DisplayMember = table.Columns["DepartmentDisplayName"].ColumnName;
        }

        /*private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
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

                dataGridView1.AllowUserToAddRows = true;
            }
        }*/
    }
}
