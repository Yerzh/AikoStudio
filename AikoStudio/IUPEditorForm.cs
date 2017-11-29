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
        private AikoDbEntities context;
        private AddIUPItem iupParams;
        private Form1 parent;

        private decimal oldLectureCredits;
        private decimal oldSeminarCredits;
        private decimal oldLaboratoryCredits;
        private decimal oldOtherCredits;

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

            //SumUpAllCredits();
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

        private void addButton_Click(object sender, EventArgs e)
        {
            int GroupSubjectId = (int)this.parent.cache.Rows[iupParams.RowIndex].ItemArray[1];
            int TeacherId = (int)this.teacherChoosingComboBox.SelectedValue;
            Curriculum existed = context.Curriculums.SingleOrDefault(c => c.GroupSubjectId == GroupSubjectId && c.TeacherId == TeacherId);

            decimal lectureCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbLectureQty.Text) ? "0" : tbLectureQty.Text);
            decimal seminarCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbSeminarQty.Text) ? "0" : tbSeminarQty.Text);
            decimal laborCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbLabQty.Text) ? "0" : tbLabQty.Text);
            decimal educCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbEducCred.Text) ? "0" : tbEducCred.Text);
            decimal pedagCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbPedagCred.Text) ? "0" : tbPedagCred.Text);
            decimal gradCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbGradCred.Text) ? "0" : tbGradCred.Text);
            decimal industCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbIndustCred.Text) ? "0" : tbIndustCred.Text);
            decimal researchCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbResearchCred.Text) ? "0" : tbResearchCred.Text);
            decimal memberCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbMemberCred.Text) ? "0" : tbMemberCred.Text);
            decimal supervCredits = decimal.Parse(string.IsNullOrWhiteSpace(tbSupervCred.Text) ? "0" : tbSupervCred.Text);

            decimal cacheLectures = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[14];
            decimal cacheSeminars = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[15];
            decimal cacheLabors = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[16];
            decimal cacheOthers = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];

            Subject subj = context.GroupSubjects.Find(GroupSubjectId).Subject;
            decimal residual = cacheLectures + oldLectureCredits - lectureCredits;
            parent.cache.Rows[iupParams.RowIndex][14] = residual;
            parent.dataGridView1.Rows[iupParams.RowIndex].Cells[10].Value = (decimal)residual;
            subj.LectureCreditQty = residual;
            
            residual = cacheSeminars + oldSeminarCredits - seminarCredits;
            parent.cache.Rows[iupParams.RowIndex][15] = residual;
            parent.dataGridView1.Rows[iupParams.RowIndex].Cells[11].Value = (decimal)residual;
            subj.SeminarCreditQty = residual;
            
            residual = cacheLabors + oldLaboratoryCredits - laborCredits;
            parent.cache.Rows[iupParams.RowIndex][16] = residual;
            parent.dataGridView1.Rows[iupParams.RowIndex].Cells[12].Value = (decimal)residual;
            subj.LaboratoryCreditQty = residual;
            
            residual = cacheOthers + oldOtherCredits - educCredits - pedagCredits - gradCredits - industCredits - researchCredits - memberCredits - supervCredits;
            if (residual < 0)
                this.errorProvider1.SetError(addButton, "Значение введенных кредитов превышает максимальное значение дополнительных кредитов");
            subj.OtherCreditQty = residual;

            context.Entry(subj).State = System.Data.Entity.EntityState.Modified;

            if (existed == null)
            {
                context.Curriculums.Add(new Curriculum()
                {
                    GroupSubjectId = GroupSubjectId,
                    TeacherId = TeacherId,
                    LectureCredits = lectureCredits,
                    SeminarCredits = seminarCredits,
                    LaboratoryCredits = laborCredits,
                    EducationalPractice = educCredits,
                    PedagogicalPractice = pedagCredits,
                    UndergraduatePractice = gradCredits,
                    IndustrialPractice = industCredits,
                    ResearchPractice = researchCredits,
                    СommissionMembership = memberCredits,
                    SupervisoryWork = supervCredits
                });
            }                
            else
            {
                existed.LectureCredits = lectureCredits;
                existed.SeminarCredits = seminarCredits;
                existed.LaboratoryCredits = laborCredits;
                existed.EducationalPractice = educCredits;
                existed.PedagogicalPractice = pedagCredits;
                existed.UndergraduatePractice = gradCredits;
                existed.IndustrialPractice = industCredits;
                existed.ResearchPractice = researchCredits;
                existed.СommissionMembership = memberCredits;
                existed.SupervisoryWork = supervCredits;
            }

            context.SaveChanges();
            parent.dataGridView1.Update();
            this.Close();
        }

        private void SumUpAllCredits()
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
                                 tbIndustCredDecimal + tbResearchCredDecimal +
                                 tbMemberCredDecimal + tbSupervCredDecimal).ToString();
        }

        private void tbLectureQty_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbLectureQty.Text) ? "0" : tbLectureQty.Text, out result))
            {
                e.Cancel = true;
                tbLectureQty.Select(0, tbLectureQty.Text.Length);
                this.errorProvider1.SetError(tbLectureQty, "Значение должно быть числом.");
            }

            var lectures = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[14];
            if (result > lectures + oldLectureCredits || result < 0)
            {
                e.Cancel = true;
                tbLectureQty.Select(0, tbLectureQty.Text.Length);
                this.errorProvider1.SetError(tbLectureQty, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbLectureQty_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbLectureQty, "");
            SumUpAllCredits();
        }

        private void tbSeminarQty_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbSeminarQty.Text) ? "0" : tbSeminarQty.Text, out result))
            {
                e.Cancel = true;
                tbSeminarQty.Select(0, tbSeminarQty.Text.Length);
                this.errorProvider1.SetError(tbSeminarQty, "Значение должно быть числом.");
            }

            var seminars = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[15];
            if (result > seminars + oldSeminarCredits || result < 0)
            {
                e.Cancel = true;
                tbSeminarQty.Select(0, tbSeminarQty.Text.Length);
                this.errorProvider1.SetError(tbSeminarQty, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbSeminarQty_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbSeminarQty, "");
            SumUpAllCredits();
        }

        private void tbLabQty_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbLabQty.Text) ? "0" : tbLabQty.Text, out result))
            {
                e.Cancel = true;
                tbLabQty.Select(0, tbLabQty.Text.Length);
                this.errorProvider1.SetError(tbLabQty, "Значение должно быть числом.");
            }

            var labs = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[16];
            if (result > labs + oldLaboratoryCredits || result < 0)
            {
                e.Cancel = true;
                tbLabQty.Select(0, tbLabQty.Text.Length);
                this.errorProvider1.SetError(tbLabQty, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbLabQty_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbLabQty, "");
            SumUpAllCredits();
        }

        private void tbEducCred_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbEducCred.Text) ? "0" : tbEducCred.Text, out result))
            {
                e.Cancel = true;
                tbEducCred.Select(0, tbEducCred.Text.Length);
                this.errorProvider1.SetError(tbEducCred, "Значение должно быть числом.");
            }

            var educCredits = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];
            if (result > educCredits + oldOtherCredits || result < 0)
            {
                e.Cancel = true;
                tbEducCred.Select(0, tbEducCred.Text.Length);
                this.errorProvider1.SetError(tbEducCred, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbEducCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbEducCred, "");
            SumUpAllCredits();
        }

        private void tbPedagCred_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbPedagCred.Text) ? "0" : tbPedagCred.Text, out result))
            {
                e.Cancel = true;
                tbPedagCred.Select(0, tbPedagCred.Text.Length);
                this.errorProvider1.SetError(tbPedagCred, "Значение должно быть числом.");
            }

            var pedagCredits = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];
            if (result > pedagCredits + oldOtherCredits || result < 0)
            {
                e.Cancel = true;
                tbPedagCred.Select(0, tbPedagCred.Text.Length);
                this.errorProvider1.SetError(tbPedagCred, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbPedagCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbPedagCred, "");
            SumUpAllCredits();
        }

        private void tbGradCred_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbGradCred.Text) ? "0" : tbGradCred.Text, out result))
            {
                e.Cancel = true;
                tbGradCred.Select(0, tbGradCred.Text.Length);
                this.errorProvider1.SetError(tbGradCred, "Значение должно быть числом.");
            }

            var gradCredits = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];
            if (result > gradCredits + oldOtherCredits || result < 0)
            {
                e.Cancel = true;
                tbGradCred.Select(0, tbGradCred.Text.Length);
                this.errorProvider1.SetError(tbGradCred, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbGradCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbGradCred, "");
            SumUpAllCredits();
        }

        private void tbIndustCred_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbIndustCred.Text) ? "0" : tbIndustCred.Text, out result))
            {
                e.Cancel = true;
                tbIndustCred.Select(0, tbIndustCred.Text.Length);
                this.errorProvider1.SetError(tbIndustCred, "Значение должно быть числом.");
            }

            var industCredits = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];
            if (result > industCredits + oldOtherCredits || result < 0)
            {
                e.Cancel = true;
                tbIndustCred.Select(0, tbIndustCred.Text.Length);
                this.errorProvider1.SetError(tbIndustCred, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbIndustCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbIndustCred, "");
            SumUpAllCredits();
        }

        private void tbResearchCred_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbResearchCred.Text) ? "0" : tbResearchCred.Text, out result))
            {
                e.Cancel = true;
                tbResearchCred.Select(0, tbResearchCred.Text.Length);
                this.errorProvider1.SetError(tbResearchCred, "Значение должно быть числом.");
            }

            var researchCredits = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];
            if (result > researchCredits + oldOtherCredits || result < 0)
            {
                e.Cancel = true;
                tbResearchCred.Select(0, tbResearchCred.Text.Length);
                this.errorProvider1.SetError(tbResearchCred, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbResearchCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbResearchCred, "");
            SumUpAllCredits();
        }

        private void tbMemberCred_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbMemberCred.Text) ? "0" : tbMemberCred.Text, out result))
            {
                e.Cancel = true;
                tbMemberCred.Select(0, tbMemberCred.Text.Length);
                this.errorProvider1.SetError(tbMemberCred, "Значение должно быть числом.");
            }

            var memberCredits = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];
            if (result > memberCredits + oldOtherCredits || result < 0)
            {
                e.Cancel = true;
                tbMemberCred.Select(0, tbMemberCred.Text.Length);
                this.errorProvider1.SetError(tbMemberCred, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbMemberCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbMemberCred, "");
            SumUpAllCredits();
        }

        private void tbSupervCred_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (!decimal.TryParse(string.IsNullOrWhiteSpace(tbSupervCred.Text) ? "0" : tbSupervCred.Text, out result))
            {
                e.Cancel = true;
                tbSupervCred.Select(0, tbSupervCred.Text.Length);
                this.errorProvider1.SetError(tbSupervCred, "Значение должно быть числом.");
            }

            var supervCredits = (decimal)parent.cache.Rows[iupParams.RowIndex].ItemArray[17];
            if (result > supervCredits + oldOtherCredits || result < 0)
            {
                e.Cancel = true;
                tbSupervCred.Select(0, tbSupervCred.Text.Length);
                this.errorProvider1.SetError(tbSupervCred, "Значение выходит из разрешенного диапазона.");
            }
        }

        private void tbSupervCred_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(tbSupervCred, "");
            SumUpAllCredits();
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
            int GroupSubjectId = (int)this.parent.cache.Rows[iupParams.RowIndex].ItemArray[1];
            int TeacherId = (int)this.teacherChoosingComboBox.SelectedValue;
            if (TeacherId <= 0) return;

            tbLectureQty.Clear();
            tbSeminarQty.Clear();
            tbLabQty.Clear();
            tbEducCred.Clear();
            tbPedagCred.Clear();
            tbGradCred.Clear();
            tbIndustCred.Clear();
            tbResearchCred.Clear();
            tbMemberCred.Clear();
            tbSupervCred.Clear();
            labelAllCred.Text = string.Empty;

            oldLectureCredits = 0;
            oldSeminarCredits = 0;
            oldLaboratoryCredits = 0;
            oldOtherCredits = 0;

            Curriculum existed = context.Curriculums.SingleOrDefault(c => c.GroupSubjectId == GroupSubjectId && c.TeacherId == TeacherId);
            if (existed != null)
            {
                oldLectureCredits = existed.LectureCredits;
                oldSeminarCredits = existed.SeminarCredits;
                oldLaboratoryCredits = existed.LaboratoryCredits;
                oldOtherCredits = existed.EducationalPractice + existed.PedagogicalPractice + existed.UndergraduatePractice +
                                  existed.IndustrialPractice + existed.ResearchPractice + existed.СommissionMembership + existed.SupervisoryWork;

                tbLectureQty.Text = existed.LectureCredits.ToString();
                tbSeminarQty.Text = existed.SeminarCredits.ToString();
                tbLabQty.Text = existed.LaboratoryCredits.ToString();
                tbEducCred.Text = existed.EducationalPractice.ToString();
                tbPedagCred.Text = existed.PedagogicalPractice.ToString();
                tbGradCred.Text = existed.UndergraduatePractice.ToString();
                tbIndustCred.Text = existed.IndustrialPractice.ToString();
                tbResearchCred.Text = existed.ResearchPractice.ToString();
                tbMemberCred.Text = existed.СommissionMembership.ToString();
                tbSupervCred.Text = existed.SupervisoryWork.ToString();
                SumUpAllCredits();
            }
        }
    }
}
