using BusinessLogic;
using System;
using System.Windows.Forms;

namespace UI
{
	public partial class MainMenu : Form
	{
		public GeneralManagement GeneralManagement{get; set;}

		public MainMenu()
		{
			InitializeComponent();
			GeneralManagement = new GeneralManagement(); 
			
		}

		private void btnAddSentiment_Click(object sender, EventArgs e)
		{
			panelMain.Controls.Clear();
			UserControl addSentiment = new AddSentiment(GeneralManagement);
			panelMain.Controls.Add(addSentiment);
		}

		

		private void btnAddEntity_Click(object sender, EventArgs e)
		{
			panelMain.Controls.Clear();
			UserControl addEntity = new AddEntity(GeneralManagement);
			panelMain.Controls.Add(addEntity);

		}

		private void btnAddPhrase_Click(object sender, EventArgs e)
		{

			panelMain.Controls.Clear();
			UserControl addPhrase = new AddPhrase(GeneralManagement);
			panelMain.Controls.Add(addPhrase);

		}

        private void BtnAddAlarm_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            UserControl selectAlarm = new SelectAlarm (GeneralManagement);
            panelMain.Controls.Add(selectAlarm);
        }

		private void btnReport_Click(object sender, EventArgs e)
		{
			panelMain.Controls.Clear();
			UserControl reportPhrases = new ReportAnalysisPhrase(GeneralManagement);
			panelMain.Controls.Add(reportPhrases);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit(); 
		}

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            UserControl admAuthors = new AdmAuthors(GeneralManagement);
            panelMain.Controls.Add(admAuthors); 
        }
    }
}
