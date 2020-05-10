using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private void panelMain_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnAddEntity_Click(object sender, EventArgs e)
		{
			panelMain.Controls.Clear();
			UserControl addEntity = new AddEntity(GeneralManagement);
			panelMain.Controls.Add(addEntity);
		}
	}
}
