using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace UI
{
	public partial class SelectAlarm : UserControl
	{
		private GeneralManagement generalManagement;
		public SelectAlarm(GeneralManagement management)
		{
			InitializeComponent();
			generalManagement = management;
			InitiliazeComboAlarms();
		}
		
		private void InitiliazeComboAlarms()
		{
			cmbSelectTypeAlarm.Items.Add("Alarma de sentimiento");
			cmbSelectTypeAlarm.Items.Add("Alarma de autores");
			cmbSelectTypeAlarm.SelectedIndex = 0;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbSelectTypeAlarm.SelectedIndex != -1)
			{
				int index = cmbSelectTypeAlarm.SelectedIndex;
				if (index == 0)
				{
					panelAlarms.Controls.Clear();
					UserControl addAlarm = new AddAlarm(generalManagement);
					panelAlarms.Controls.Add(addAlarm);
				}
				if(index == 1)
				{
					panelAlarms.Controls.Clear();
					UserControl addAuthorAlarm = new AddAuthorAlarm(generalManagement);
					panelAlarms.Controls.Add(addAuthorAlarm);
				}
			}
		}
	}
}
