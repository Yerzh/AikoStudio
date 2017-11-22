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

            parent.SaveDataGridViewToCache();
            parent.saveCacheIntoDb();

            subjectNameRightLabel.Text = parent.cache.Rows[iupParams.RowIndex].ItemArray[5].ToString();
            specialityRightLabel.Text = parent.cache.Rows[iupParams.RowIndex].ItemArray[3].ToString();
            yearSemesterRigthLabel.Text = parent.cache.Rows[iupParams.RowIndex].ItemArray[8].ToString() + "/" +
                                          parent.cache.Rows[iupParams.RowIndex].ItemArray[9].ToString();
            lecSemLabRightLabel.Text = parent.cache.Rows[iupParams.RowIndex].ItemArray[11].ToString() + "/" +
                                       parent.cache.Rows[iupParams.RowIndex].ItemArray[12].ToString() + "/" +
                                       parent.cache.Rows[iupParams.RowIndex].ItemArray[13].ToString();

            calculateAllCredits();
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

        private void calculateAllCredits()
        {
            decimal tbLectureQtyDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbLectureQty.Text) ? "0" : tbLectureQty.Text, out tbLectureQtyDecimal);

            decimal tbSeminarQtyDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbSeminarQty.Text) ? "0" : tbSeminarQty.Text, out tbSeminarQtyDecimal);

            decimal tbLabQtyDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbLabQty.Text) ? "0" : tbLabQty.Text, out tbLabQtyDecimal);

            decimal tbEducCredDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbEducCred.Text) ? "0" : tbEducCred.Text, out tbEducCredDecimal);

            decimal tbPedagCredDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbPedagCred.Text) ? "0" : tbPedagCred.Text, out tbPedagCredDecimal);

            decimal tbGradCredDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbGradCred.Text) ? "0" : tbGradCred.Text, out tbGradCredDecimal);

            decimal tbIndustCredDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbIndustCred.Text) ? "0" : tbIndustCred.Text, out tbIndustCredDecimal);

            decimal tbResearchCredDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbResearchCred.Text) ? "0" : tbResearchCred.Text, out tbResearchCredDecimal);

            decimal tbMemberCredDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbMemberCred.Text) ? "0" : tbMemberCred.Text, out tbMemberCredDecimal);

            decimal tbSupervCredDecimal;
            decimal.TryParse(string.IsNullOrEmpty(tbSupervCred.Text) ? "0" : tbSupervCred.Text, out tbSupervCredDecimal);

            labelAllCred.Text = (tbLectureQtyDecimal + tbSeminarQtyDecimal + tbLabQtyDecimal +
                                 tbEducCredDecimal + tbPedagCredDecimal + tbGradCredDecimal +
                                 tbIndustCredDecimal + tbResearchCredDecimal + tbResearchCredDecimal +
                                 tbMemberCredDecimal + tbSupervCredDecimal).ToString();
        }

        private void tbLectureQty_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbLectureQty.Text) ? "0" : tbLectureQty.Text, out result))
            {
                e.Cancel = true;
                tbLectureQty.Select(0, tbLectureQty.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbLectureQty, errorMsg);
            }              
        }

        private void tbLectureQty_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbLectureQty, "");
            calculateAllCredits();
        }

        private void tbSeminarQty_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbSeminarQty.Text) ? "0" : tbSeminarQty.Text, out result))
            {
                e.Cancel = true;
                tbSeminarQty.Select(0, tbSeminarQty.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbSeminarQty, errorMsg);
            }
        }

        private void tbSeminarQty_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbSeminarQty, "");
            calculateAllCredits();
        }

        private void tbLabQty_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbLabQty.Text) ? "0" : tbLabQty.Text, out result))
            {
                e.Cancel = true;
                tbLabQty.Select(0, tbLabQty.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbLabQty, errorMsg);
            }
        }

        private void tbLabQty_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbLabQty, "");
            calculateAllCredits();
        }

        private void tbEducCred_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbEducCred.Text) ? "0" : tbEducCred.Text, out result))
            {
                e.Cancel = true;
                tbEducCred.Select(0, tbEducCred.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbEducCred, errorMsg);
            }
        }

        private void tbEducCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbEducCred, "");
            calculateAllCredits();
        }

        private void tbPedagCred_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbPedagCred.Text) ? "0" : tbPedagCred.Text, out result))
            {
                e.Cancel = true;
                tbPedagCred.Select(0, tbPedagCred.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbPedagCred, errorMsg);
            }
        }

        private void tbPedagCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbPedagCred, "");
            calculateAllCredits();
        }

        private void tbGradCred_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbGradCred.Text) ? "0" : tbGradCred.Text, out result))
            {
                e.Cancel = true;
                tbGradCred.Select(0, tbGradCred.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbGradCred, errorMsg);
            }
        }

        private void tbGradCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbGradCred, "");
            calculateAllCredits();
        }

        private void tbIndustCred_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbIndustCred.Text) ? "0" : tbIndustCred.Text, out result))
            {
                e.Cancel = true;
                tbIndustCred.Select(0, tbIndustCred.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbIndustCred, errorMsg);
            }
        }

        private void tbIndustCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbIndustCred, "");
            calculateAllCredits();
        }

        private void tbResearchCred_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbResearchCred.Text) ? "0" : tbResearchCred.Text, out result))
            {
                e.Cancel = true;
                tbResearchCred.Select(0, tbResearchCred.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbResearchCred, errorMsg);
            }
        }

        private void tbResearchCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbResearchCred, "");
            calculateAllCredits();
        }

        private void tbMemberCred_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbMemberCred.Text) ? "0" : tbMemberCred.Text, out result))
            {
                e.Cancel = true;
                tbMemberCred.Select(0, tbMemberCred.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbMemberCred, errorMsg);
            }
        }

        private void tbMemberCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbMemberCred, "");
            calculateAllCredits();
        }

        private void tbSupervCred_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            decimal result;
            if (!decimal.TryParse(string.IsNullOrEmpty(tbSupervCred.Text) ? "0" : tbSupervCred.Text, out result))
            {
                e.Cancel = true;
                tbSupervCred.Select(0, tbSupervCred.Text.Length);
                errorMsg = "Value must be numeric.";
                this.errorProvider1.SetError(tbSupervCred, errorMsg);
            }
        }

        private void tbSupervCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbSupervCred, "");
            calculateAllCredits();
        }
    }
}
