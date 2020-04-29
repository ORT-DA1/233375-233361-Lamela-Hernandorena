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
	public partial class AddSentiment : UserControl
	{

		private GeneralManagement generalManagement; 

		public AddSentiment(GeneralManagement management)
		{
			InitializeComponent();
			generalManagement = management; 

		}
	}
}
