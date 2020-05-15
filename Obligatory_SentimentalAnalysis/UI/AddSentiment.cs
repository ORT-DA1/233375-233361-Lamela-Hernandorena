using System;
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
			initializeListOfSentiment();
			DisplayButton();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string sentimentText = textBoxSentiment.Text;

			if (isChecked().Equals(Sentiment.TypeSentiment.Neutral))
			{
				labelError.Visible = true;
				labelError.Text ="Debe seleccionar el tipo de sentimiento."; 
			}
			else
			{
				try
				{
					Sentiment sentiment = new Sentiment()
					{
						SentimientText= sentimentText,
						SentimentType= isChecked()
					};
					generalManagement.SentimentManagement.AddSentiment(sentiment);
					MessageBox.Show("Sentimiento agregado correctamente");
					initializeListOfSentiment(); 
					DeleteText();
					DisplayButton(); 
				}
				catch (TextManagementException exc)
				{
					labelError.Visible = true; 
					labelError.Text = exc.Message; 
				}
				catch (Exception)
				{
					MessageBox.Show("Error interno del sistema");
				}
			}
			
		}


		private void initializeListOfSentiment()
		{
			listBoxSentiment.DataSource = generalManagement.SentimentManagement.AllSentiments;  
		}
		
		private Sentiment.TypeSentiment isChecked()
		{
			if (radioButtonNegative.Checked)
			{
				return Sentiment.TypeSentiment.Negative; 
			}
			else
			{
				if (radioButtonPositive.Checked)
				{
					return Sentiment.TypeSentiment.Positive;
				}
				else
				{
					return Sentiment.TypeSentiment.Neutral; 
				}
			}
		}


		private void DeleteText()
		{
			textBoxSentiment.Text = "";
			radioButtonNegative.Checked = false;
			radioButtonPositive.Checked = false;
			labelError.Text = "";
			labelError.Visible = false; 
		}

		private void DisplayButton()
		{
			if (generalManagement.SentimentManagement.AllSentiments.Length > 0)
			{
				btnDelete.Enabled = true;
			}
			else
			{
				btnDelete.Enabled = false;
			}
		}


		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (this.listBoxSentiment.SelectedIndex == -1)
			{
				labelError.Visible = true;
				labelError.Text = "Error Seleccione un sentimiento a eliminar"; 
			}
			else
			{
				Sentiment sentiment = (Sentiment)listBoxSentiment.SelectedItem; 
				generalManagement.SentimentManagement.DeleteText(sentiment);
				DisplayButton();
				MessageBox.Show("El sentimiento se ha eliminado con exito.");
				initializeListOfSentiment(); 
			}
		}
		
    }
}
