using System;
using System.Windows.Forms;
using BusinessLogic;
using Domain;

namespace UI
{
    public partial class ReportOfAuthors : UserControl
    {
        private GeneralManagement generalManagement;


        public ReportOfAuthors(GeneralManagement management)
        {
            InitializeComponent();
            generalManagement = management;
            InitializeComponentsOfUI();
        }

        private void InitializeSortingCriteria()
        {
            cmbCriterion.Items.Add("Porcentaje de frases positivas");
            cmbCriterion.Items.Add("Porcentaje de frases negativas");
            cmbCriterion.Items.Add("Cantidad de entidades mencionadas");
            cmbCriterion.Items.Add("Promedio diario de frases");
            cmbCriterion.SelectedIndex = 0;
            
        }

        private void InitializeComponentsOfUI()
        {
            InitializeSortingCriteria();
            radioButtonAsc.Checked = true;
            grdReport.Visible = false;
            

        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {

            int index = cmbCriterion.SelectedIndex;
            if (index == 0)
            {

                PhrasesPercentageReport report = new PhrasesPercentageReport();
                report.IsPercentageOfPositivePhrases = true;
                report.TypeOfSort = TypeOfSort();
                generalManagement.AuthorManagement.GenerateReportOfAuthor(report);
                ChargeGrid(report);
            }
            if (index == 1)
            {
                PhrasesPercentageReport report = new PhrasesPercentageReport();
                report.IsPercentageOfPositivePhrases = false;
                report.TypeOfSort = TypeOfSort();
                generalManagement.AuthorManagement.GenerateReportOfAuthor(report);
                ChargeGrid(report);

            }
            if (index == 2)
            {
                EntitiesMentionedReport report = new EntitiesMentionedReport();
                report.TypeOfSort = TypeOfSort();
                generalManagement.AuthorManagement.GenerateReportOfAuthor(report);
                ChargeGrid(report);
            }
            if (index == 3)
            {
                DailyAveragePhraseReport report = new DailyAveragePhraseReport();
                report.TypeOfSort = TypeOfSort();
                generalManagement.AuthorManagement.GenerateReportOfAuthor(report);
                ChargeGrid(report);
            }
        }

        private AuthorReport.SortingType TypeOfSort()
        {
            if (radioButtonAsc.Checked)
            {
                return AuthorReport.SortingType.Asc;
            }
            else
            {
                return AuthorReport.SortingType.Desc;
            }
        }

        public void ChargeGrid(AuthorReport report)
        {
            grdReport.DataSource = report.AllAuthorsParticipants;
            grdReport.Columns[0].Width = 270;
            grdReport.Columns[0].HeaderText = "Autor";
            grdReport.Columns[1].HeaderText = cmbCriterion.Text;
            grdReport.Columns[1].Width = 220;
            grdReport.Visible = true;
        }
    }
}
