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
    public partial class IUPEditorForm : Form
    {
        AikoDbEntities context;
        AddIUPItem iupParams;
        Form1 parent;
        public IUPEditorForm(Form1 parent, AddIUPItem iupParams)
        {
            InitializeComponent();
            context = new AikoDbEntities();
            this.parent = parent;
            this.iupParams = iupParams;
        }

        private void IUPEditorForm_Load(object sender, EventArgs e)
        {
            if (iupParams == null)
                return;

            var teachers = from t in context.Teachers
                           orderby t.Id
                           select t;

            teacherChoosingComboBox.Items.Clear();
            SetTeacherFioComboBoxDataSource();

            //parent.cache.
            //MessageBox.Show(string.Format("row = {0}, col = {1}", iupParams.RowIndex, iupParams.ColIndex));
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

            DataRow row = table.NewRow();
            row["TeacherId"] = 0;
            row["TeacherFIODisplayName"] = "<Не выбрано>";
            table.Rows.Add(row);
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
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }
    }
}
