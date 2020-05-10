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
using BusinessLogicExceptions;

namespace UI
{
	public partial class AddPhrase : UserControl
	{
		private GeneralManagement generalManagement; 

		public AddPhrase(GeneralManagement management)
		{
			InitializeComponent();
			generalManagement = management;

		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{

			try
			{
				AddPhraseUI(); 
			}
			catch (PhraseManagementException exp)
			{
				MessageBox.Show(exp.Message); 
			}
			catch(Exception exp2)
			{
				MessageBox.Show("Error interno del sistema."); 
			}
			
		}

		private void AddPhraseUI()
		{

			string phraseText = textBoxPhrase.Text;
			DateTime phraseDate = dateTimePickerPhraseDate.Value;

			if (dateTimePickerPhraseDate.Value== null)
			{
				MessageBox.Show("Debe seleccionar la fecha de la frase");
			}

			Phrase phrase = new Phrase()
			{
				TextPhrase = phraseText, 
				PhraseDate = phraseDate
			};
			generalManagement.AnalysisPhrase(phrase);
			generalManagement.PhraseManagement.AddPhrase(phrase);
			RealTimeProvider timeNow = new RealTimeProvider(); 
			generalManagement.UpdateAlarms(timeNow); 
			MessageBox.Show("Se ha agregado una frase correctamente");
			DeleteText(); 
		}

		private void DeleteText()
		{
			textBoxPhrase.Text = "";
		}

	}
}
