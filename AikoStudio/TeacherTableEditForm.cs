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
    public partial class TeacherTableEditForm : Form
    {
        private AikoDbEntities context;
        private DataTable cache;

        public TeacherTableEditForm()
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
            cache.Columns.Add("TeacherId", typeof(int));                  //1
            cache.Columns.Add("Fio", typeof(string));                     //2
            cache.Columns.Add("Publications", typeof(int));               //3
            cache.Columns.Add("DesiredWageRate", typeof(decimal));        //4            
        }

        private void TeacherTableEditForm_Load(object sender, EventArgs e)
        {
            populateCache();
            populateDataGridView();
        }

        private void populateCache()
        {
            var query = from t in context.Teachers
                        orderby t.Id
                        select new
                        {
                            TeacherId = t.Id,
                            Fio = t.Fio,
                            Publications = t.Publications,
                            DesiredWageRate = t.DesiredWageRate
                        };

            cache.Clear();

            foreach (var item in query)
            {
                DataRow row = cache.NewRow();
                row.ItemArray = new object[]
                {
                    null, //0
                    item.TeacherId, //1
                    item.Fio, //2
                    item.Publications, //3
                    item.DesiredWageRate //4                    
                };
                cache.Rows.Add(row);
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
                dataGridView1.Rows[newRowIndex].Cells[0].Value = (int)objs[0];
                dataGridView1.Rows[newRowIndex].Cells[1].Value = (string)objs[2];
                dataGridView1.Rows[newRowIndex].Cells[2].Value = (int)objs[3];
                dataGridView1.Rows[newRowIndex].Cells[3].Value = (decimal)objs[4];                
            }
            dataGridView1.Update();
        }

        private bool validateDataGridViewCellValues()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                object val = dataGridView1.Rows[i].Cells[1].Value;
                if (val == null || string.IsNullOrWhiteSpace(val.ToString()))
                {
                    //dataGridView1.Rows[i].Cells[1].AdjustCellBorderStyle()
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 1));
                    return false;
                }

                int intRes = 0;
                val = dataGridView1.Rows[i].Cells[2].Value;
                if (val == null || !int.TryParse(val.ToString(), out intRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 2));
                    return false;
                }

                decimal decRes = 0;
                val = dataGridView1.Rows[i].Cells[3].Value;
                if (val == null || !decimal.TryParse(val.ToString(), out decRes))
                {
                    MessageBox.Show(string.Format("Error: {0} {1}", i, 3));
                    return false;
                }                
            }
            return true;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                bool validateRes = validateDataGridViewCellValues();
                if (!validateRes)
                {
                    MessageBox.Show("Some cells have invalid values!");
                    return;
                }

                #region Deleting non-existing rows in datagridview1 from cache
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
                #endregion Deleting non-existing rows in datagridview1 from cache

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
                                cache.Rows[i][2] = val.ToString();
                                break;
                            case 2:
                                cache.Rows[i][3] = int.Parse(val.ToString());
                                break;
                            case 3:
                                cache.Rows[i][4] = decimal.Parse(val.ToString());
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
                    null,                                                                                      //0
                    0 /*item.TeacherId*/,                                                                      //1
                    dataGridView1.Rows[i].Cells[1].Value.ToString() /*item.Fio*/,                              //2
                    int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) /*item.Publications*/,          //3
                    decimal.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) /*item.DesiredWageRate*/,   //4
                    };
                    cache.Rows.Add(row);
                }
                #endregion Adding new rows into cache

                saveCacheIntoDb();
            }
        }

        private void saveCacheIntoDb()
        {
            #region Deleting from db
            var cacheTeacherIdsHashSet = new HashSet<int>(cache.Rows.OfType<DataRow>()
                                                                    .Select(dr => dr.Field<int>("TeacherId")).ToArray());

            var dbTeacherIdsHashSet = new HashSet<int>(context.Teachers.Select(t => t.Id).ToArray());


            dbTeacherIdsHashSet.ExceptWith(cacheTeacherIdsHashSet);

            foreach (int id in dbTeacherIdsHashSet)
            {                
                Teacher t = context.Teachers.Find(id);
                context.Teachers.Remove(t);
            }
            context.SaveChanges();
            #endregion Deleting from db

            #region Add or update rows in tables of db
            foreach (DataRow row in cache.Rows)
            {
                object[] objs = row.ItemArray;
                if ((int)objs[1] > 0)
                {
                    var t = context.Teachers.Find((int)objs[1]);
                                       
                    t.Fio = objs[2].ToString();
                    t.Publications = (int)objs[3];
                    t.DesiredWageRate = (decimal)objs[4];
                    context.Entry(t).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    Teacher t = new Teacher()
                    {
                        Fio = objs[2].ToString(),
                        Publications = (int)objs[3],
                        DesiredWageRate = (decimal)objs[4]
                    };
                    context.Teachers.Add(t);
                }
                context.SaveChanges();
                #endregion Add or update rows in tables of db
            }
        }
    }
}
