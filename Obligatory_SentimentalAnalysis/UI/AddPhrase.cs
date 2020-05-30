using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain; 

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
            InitializeListOfAuthors();
            DisplayAddButton();
        }

		private void InitializeCalendar()
		{
			dateTimePickerPhraseDate.Value = DateTime.Now;
			dateTimePickerPhraseDate.MinDate = DateTime.Now.AddYears(-1);
			dateTimePickerPhraseDate.MaxDate = DateTime.Now; 
		}

        private void InitializeListOfAuthors()
        {
            listBoxAuthors.DataSource = generalManagement.AuthorManagement.AllAuthors;
        }

		private void btnAddPhrase_Click(object sender, EventArgs e)
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

            if (listBoxAuthors.SelectedIndex == -1)
            {
                labelError.Visible = true;
                labelError.Text = "Error seleccione un autor para la frase";
            }
            else
            {
                Phrase phrase = new Phrase()
                {
                    TextPhrase = phraseText,
                    PhraseDate = phraseDate,
                    PhraseAuthor = (Author)listBoxAuthors.SelectedItem
                };
                generalManagement.AnalysisPhrase(phrase);
                generalManagement.PhraseManagement.AddPhrase(phrase); 
                RealTimeProvider timeNow = new RealTimeProvider();
                generalManagement.UpdateAlarms(timeNow);
                MessageBox.Show("Se ha agregado una frase correctamente");
                ClearAllFields();
            }

            
		}

		private void ClearAllFields()
		{
			textBoxPhrase.Text = "";
			labelError.Visible = false;
			labelError.Text = ""; 
		}

        private void DisplayAddButton()
        {
            if (generalManagement.AuthorManagement.AllAuthors.Length > 0)
            {
                btnAddPhrase.Enabled = true;
            }
            else
            {
                btnAddPhrase.Enabled = false;
            }
        }


    }
}
