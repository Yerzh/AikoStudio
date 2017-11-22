using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AikoStudio
{
    public partial class Form1 : Form
    {
        private AikoDbEntities context;
        public DataTable cache;

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
            cache.PrimaryKey = new DataColumn[] { cache.Columns["Id"] };  //0
            cache.Columns.Add(idColumn);
            cache.Columns.Add("GroupSubjectId", typeof(int));             //1
            cache.Columns.Add("SpecialtyId", typeof(int));                //2
            cache.Columns.Add("SpecialityName", typeof(string));          //3
            cache.Columns.Add("SubjectId", typeof(int));                  //4
            cache.Columns.Add("SubjectName", typeof(string));             //5
            cache.Columns.Add("DepartmentId", typeof(int));               //6
            cache.Columns.Add("DepartmentName", typeof(string));          //7
            cache.Columns.Add("Year", typeof(int));                       //8
            cache.Columns.Add("Semester", typeof(int));                   //9
            cache.Columns.Add("Contingent", typeof(int));                 //10
            cache.Columns.Add("LectureQty", typeof(int));                 //11  
            cache.Columns.Add("SeminarQty", typeof(int));                 //12
            cache.Columns.Add("LaboratoryQty", typeof(int));              //13 
            cache.Columns.Add("LectureCreditQty", typeof(decimal));       //14 
            cache.Columns.Add("SeminarCreditQty", typeof(decimal));       //15
            cache.Columns.Add("LaboratoryCreditQty", typeof(decimal));    //16
            cache.Columns.Add("OtherCreditQty", typeof(decimal));         //17
            cache.Columns.Add("AllCreditQty", typeof(decimal));           //18
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSpecialityColumnDataSource();
            SetDepartmentColumnDataSource();
            populateCache();
            populateDataGridView();
        }

        public void populateCache()
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

            cache.Clear();

            foreach (var item in query)
            {
                DataRow row = cache.NewRow();
                row.ItemArray = new object[]
                {
                    null, //0
                    item.GroupSubjectId, //1
                    item.SpecialtyId, //2
                    item.SpecialityName, //3
                    item.SubjectId, //4
                    item.SubjectName, //5
                    item.DepartmentId, //6
                    item.DepartmentName, //7
                    item.Year, //8
                    item.Semester, //9
                    item.Contingent, //10
                    item.LectureQty, //11
                    item.SeminarQty, //12
                    item.LaboratoryQty, //13
                    item.LectureCreditQty, //14
                    item.SeminarCreditQty, //15
                    item.LaboratoryCreditQty, //16
                    item.OtherCreditQty, //17
                    item.AllCreditQty //18
                };
                cache.Rows.Add(row);
            }
        }

        public void populateDataGridView()
        {
            if (cache == null)
                throw new NullReferenceException("Кэш не может быть null");

            dataGridView1.Rows.Clear();
            foreach (DataRow r in cache.Rows)
            {
                object[] objs = r.ItemArray;
                int newRowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[newRowIndex].Cells[0].Value = (int)objs[0];
                dataGridView1.Rows[newRowIndex].Cells[1].Value = (int)objs[2];
                dataGridView1.Rows[newRowIndex].Cells[2].Value = (string)objs[5];
                dataGridView1.Rows[newRowIndex].Cells[3].Value = (int)objs[6];
                dataGridView1.Rows[newRowIndex].Cells[4].Value = (int)objs[8];
                dataGridView1.Rows[newRowIndex].Cells[5].Value = (int)objs[9];
                dataGridView1.Rows[newRowIndex].Cells[6].Value = (int)objs[10];
                dataGridView1.Rows[newRowIndex].Cells[7].Value = (int)objs[11];
                dataGridView1.Rows[newRowIndex].Cells[8].Value = (int)objs[12];
                dataGridView1.Rows[newRowIndex].Cells[9].Value = (int)objs[13];
                dataGridView1.Rows[newRowIndex].Cells[10].Value = (decimal)objs[14];
                dataGridView1.Rows[newRowIndex].Cells[11].Value = (decimal)objs[15];
                dataGridView1.Rows[newRowIndex].Cells[12].Value = (decimal)objs[16];
                dataGridView1.Rows[newRowIndex].Cells[13].Value = (decimal)objs[17];
                dataGridView1.Rows[newRowIndex].Cells[14].Value = (decimal)objs[18];
            }
            dataGridView1.Update();
        }
        
        private bool validateDataGridViewCellValues()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                
                if (dataGridView1.Rows[i].Cells[1].Value == null)
                {
                    //dataGridView1.Rows[i].Cells[1].AdjustCellBorderStyle()
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 1));
                    return false;
                }

                object val = dataGridView1.Rows[i].Cells[2].Value;
                if (val == null || string.IsNullOrWhiteSpace(val.ToString()))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 2));
                    return false;
                }

                if (dataGridView1.Rows[i].Cells[3].Value == null)
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 3));
                    return false;
                }

                int intRes = 0;
                val = dataGridView1.Rows[i].Cells[4].Value;
                if (val == null || !int.TryParse(val.ToString(), out intRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 4));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[5].Value;
                if (val == null || !int.TryParse(val.ToString(), out intRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 5));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[6].Value;
                if (val == null || !int.TryParse(val.ToString(), out intRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 6));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[7].Value;
                if (val == null || !int.TryParse(val.ToString(), out intRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 7));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[8].Value;
                if (val == null || !int.TryParse(val.ToString(), out intRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 8));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[9].Value;
                if (val == null || !int.TryParse(val.ToString(), out intRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 9));
                    return false;
                }

                decimal decRes = 0;
                val = dataGridView1.Rows[i].Cells[10].Value;
                if (val == null || !decimal.TryParse(val.ToString(), out decRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 10));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[11].Value;
                if (val == null || !decimal.TryParse(val.ToString(), out decRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 11));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[12].Value;
                if (val == null || !decimal.TryParse(val.ToString(), out decRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 12));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[13].Value;
                if (val == null || !decimal.TryParse(val.ToString(), out decRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 13));
                    return false;
                }

                val = dataGridView1.Rows[i].Cells[14].Value;
                if (val == null || !decimal.TryParse(val.ToString(), out decRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 14));
                    return false;
                }
            }
            return true;
        }

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

        public void SaveDataGridViewToCache()
        {
            bool validateRes = validateDataGridViewCellValues();
            if (!validateRes)
            {
                MessageBox.Show("Some cells have invalid values!");
                return;
            }

            int r = 0;
            while (r < cache.Rows.Count)
            {
                DataRow row = cache.Rows[r];
                if (dataGridView1.Rows[r].Cells[0].Value == null ||
                      (int)row.ItemArray[0] != int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString()))
                {
                    cache.Rows.Remove(row);
                    continue;
                }
                r++;
            }

            #region Updating existing rows in cache
            int i;
            for (i = 0; i < cache.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    object val = dataGridView1.Rows[i].Cells[j].Value;
                    switch (j)
                    {
                        case 1:
                            {
                                cache.Rows[i][2] = int.Parse(val.ToString());
                                Specialty spec = context.Specialties.Find(int.Parse(val.ToString()));
                                cache.Rows[i][3] = spec.Code + "," + spec.LongName;
                            }
                            break;
                        case 2:
                            cache.Rows[i][5] = val.ToString();
                            break;
                        case 3:
                            {
                                cache.Rows[i][6] = int.Parse(val.ToString());
                                Department dep = context.Departments.Find(int.Parse(val.ToString()));
                                cache.Rows[i][7] = dep.LongName;
                            }
                            break;
                        case 4:
                            cache.Rows[i][8] = int.Parse(val.ToString());
                            break;
                        case 5:
                            cache.Rows[i][9] = int.Parse(val.ToString());
                            break;
                        case 6:
                            cache.Rows[i][10] = int.Parse(val.ToString());
                            break;
                        case 7:
                            cache.Rows[i][11] = int.Parse(val.ToString());
                            break;
                        case 8:
                            cache.Rows[i][12] = int.Parse(val.ToString());
                            break;
                        case 9:
                            cache.Rows[i][13] = int.Parse(val.ToString());
                            break;
                        case 10:
                            cache.Rows[i][14] = decimal.Parse(val.ToString());
                            break;
                        case 11:
                            cache.Rows[i][15] = decimal.Parse(val.ToString());
                            break;
                        case 12:
                            cache.Rows[i][16] = decimal.Parse(val.ToString());
                            break;
                        case 13:
                            cache.Rows[i][17] = decimal.Parse(val.ToString());
                            break;
                        case 14:
                            cache.Rows[i][18] = decimal.Parse(val.ToString());
                            break;
                    }
                }
            }
            cache.AcceptChanges();
            #endregion Updating existing rows in cache

            #region Adding new rows into cache
            for (; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataRow row = cache.NewRow();
                row.ItemArray = new object[]
                {
                    null,                                                                               //0
                    0 /*item.GroupSubjectId*/,                                                          //1
                    int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) /*item.SpecialtyId*/,    //2
                    string.Empty /*item.SpecialityName*/,                                               //3
                    0 /*item.SubjectId*/,                                                               //4
                    dataGridView1.Rows[i].Cells[2].Value.ToString() /*item.SubjectName*/,               //5
                    int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) /*item.DepartmentId*/,   //6
                    String.Empty /*item.DepartmentName*/,                                               //7
                    int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) /*item.Year*/,                          //8
                    int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) /*item.Semester*/,                      //9
                    int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()) /*item.Contingent*/,                    //10
                    int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()) /*item.LectureQty*/,                    //11
                    int.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()) /*item.SeminarQty*/,                    //12
                    int.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString()) /*item.LaboratoryQty*/,                 //13
                    decimal.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()) /*item.LectureCreditQty*/,         //14
                    decimal.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString()) /*item.SeminarCreditQty*/,         //15
                    decimal.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString()) /*item.LaboratoryCreditQty*/,      //16
                    decimal.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString()) /*item.OtherCreditQty*/,           //17
                    decimal.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString()) /*item.AllCreditQty*/              //18
                };
                cache.Rows.Add(row);
            }
            #endregion Adding new rows into cache
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataGridViewToCache();
            saveCacheIntoDb();
            populateDataGridView();
            dataGridView1.Update();
        }

        public void saveCacheIntoDb()
        {
            #region Deleting from db
            var cacheGroupSubjectIdsHashSet = new HashSet<int>(cache.Rows.OfType<DataRow>()
                                                                    .Select(dr => dr.Field<int>("GroupSubjectId")).ToArray<int>());

            var dbGroupSubjectIdsHashSet = new HashSet<int>(context.GroupSubjects.Select(gs => gs.Id).ToArray<int>());


            dbGroupSubjectIdsHashSet.ExceptWith(cacheGroupSubjectIdsHashSet);

            foreach (int id in dbGroupSubjectIdsHashSet)
            {
                GroupSubject gs = context.GroupSubjects.Find(id);
                Subject sub = gs.Subject;
                GroupOfStudents gr = gs.GroupOfStudents;
                context.GroupSubjects.Remove(gs);
                context.Subjects.Remove(sub);
                context.GroupOfStudents.Remove(gr);
            }
            context.SaveChanges();
            #endregion Deleting from db

            #region Add or update rows in tables of db
            foreach (DataRow row in cache.Rows)
            {
                object[] objs = row.ItemArray;
                if ((int)objs[1] > 0)
                {
                    var gs = context.GroupSubjects.Find((int)objs[1]);
                    var gr = gs.GroupOfStudents;
                    var sub = gs.Subject;

                    sub.Name = objs[5].ToString();
                    sub.LectureQty = (int)objs[11];
                    sub.SeminarQty = (int)objs[12];
                    sub.LaboratoryQty = (int)objs[13];
                    sub.LectureCreditQty = (decimal)objs[14];
                    sub.SeminarCreditQty = (decimal)objs[15];
                    sub.LaboratoryCreditQty = (decimal)objs[16];
                    sub.OtherCreditQty = (decimal)objs[17];
                    sub.AllCreditQty = (decimal)objs[18];
                    context.Entry(sub).State = System.Data.Entity.EntityState.Modified;

                    gr.SpecialtyId = (int)objs[2];
                    gr.DepartmentId = (int)objs[6];
                    gr.Year = (int)objs[8];
                    gr.Semester = (int)objs[9];
                    gr.Contingent = (int)objs[10];
                    context.Entry(gr).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    Subject sub = new Subject()
                    {
                        Name = objs[5].ToString(),
                        LectureQty = (int)objs[11],
                        SeminarQty = (int)objs[12],
                        LaboratoryQty = (int)objs[13],
                        LectureCreditQty = (decimal)objs[14],
                        SeminarCreditQty = (decimal)objs[15],
                        LaboratoryCreditQty = (decimal)objs[16],
                        OtherCreditQty = (decimal)objs[17],
                        AllCreditQty = (decimal)objs[18]
                    };
                    context.Subjects.Add(sub);

                    GroupOfStudents gr = new GroupOfStudents()
                    {
                        SpecialtyId = (int)objs[2],
                        DepartmentId = (int)objs[6],
                        Contingent = (int)objs[10],
                        Year = (int)objs[8],
                        Semester = (int)objs[9]
                    };
                    context.GroupOfStudents.Add(gr);

                    GroupSubject gs = new GroupSubject()
                    {
                        SubjectId = sub.Id,
                        GroupId = gr.Id
                    };
                    context.GroupSubjects.Add(gs);
                }
                context.SaveChanges();
                #endregion Add or update rows in tables of db
            }
        }

        private void TeacherTableEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherTableEditForm teacherTableEdit = new TeacherTableEditForm();
            teacherTableEdit.StartPosition = FormStartPosition.CenterScreen;
            teacherTableEdit.ShowDialog();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;
                if (rowIndex != -1 && colIndex != -1)
                {
                    DataGridViewCell currentCell = (sender as DataGridView).CurrentCell;
                    var mousePosition = dataGridView1.PointToClient(Cursor.Position);
                    contextMenuStrip1.Show(dataGridView1, mousePosition);
                    selectedRowIndex = rowIndex;
                    selectedColIndex = colIndex;
                }
            }
        }

        int selectedRowIndex;
        int selectedColIndex;
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.Rows[selectedRowIndex].Cells[selectedColIndex];
            if (e.ClickedItem == tsCopyMenuItem)
                Clipboard.SetText(selectedCell.FormattedValue.ToString());                
            else if (e.ClickedItem == tsPasteMenuItem)
            {
                if (selectedCell.OwningColumn.GetType() == typeof(DataGridViewComboBoxColumn))
                    return;

                selectedCell.Value = Clipboard.GetText();
            }
            else if (e.ClickedItem == tsCutMenuItem)
            {
                if (selectedCell.OwningColumn.GetType() == typeof(DataGridViewComboBoxColumn))
                    return;

                Clipboard.SetText(selectedCell.Value.ToString());
                selectedCell.Value = null;
            }
            else if (e.ClickedItem == tsAddMenuItem)
            {
                IUPEditorForm iup = new IUPEditorForm(this, new AddIUPItem() { RowIndex = selectedRowIndex, ColIndex = selectedColIndex });
                iup.StartPosition = FormStartPosition.CenterScreen;
                iup.ShowDialog();
            }
        }
    }

    public class AddIUPItem
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
    }
}
