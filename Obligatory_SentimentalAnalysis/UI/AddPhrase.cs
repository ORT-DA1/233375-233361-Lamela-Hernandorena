using System;
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
			InitializeCalendar(); 

		}

		private void InitializeCalendar()
		{
			dateTimePickerPhraseDate.Value = DateTime.Now;
			dateTimePickerPhraseDate.MinDate = DateTime.Now.AddYears(-1);
			dateTimePickerPhraseDate.MaxDate = DateTime.Now; 
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			try
			{
				AddPhraseUI(); 
			}
			catch (PhraseManagementException exp)
			{
				labelError.Visible = true;
				labelError.Text = exp.Message; 
			}
			catch(Exception)
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
				labelError.Visible = true;
				labelError.Text = "Debe seleccionar la fecha de la frase"; 
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
			labelError.Visible = false;
			labelError.Text = ""; 
		}

	}
}
