using System;
using System.Windows.Forms;
using BusinessLogicExceptions;
using BusinessLogic; 
using Domain; 

namespace UI
{
	public partial class AddSentiment : UserControl
	{

		private GeneralManagement generalManagement; 

		public AddSentiment(GeneralManagement management)
		{
			InitializeComponent();
			generalManagement = management;
			InitializeListOfSentiment();
			DisplayDeleteButton();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string sentimentText = textBoxSentiment.Text;

			if (IsCheckedType().Equals(Sentiment.TypeSentiment.Neutral))
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
						SentimentType= IsCheckedType()
					};
					generalManagement.SentimentManagement.AddSentiment(sentiment);
					MessageBox.Show("Sentimiento agregado correctamente");
					InitializeListOfSentiment(); 
					ClearAllFields();
					DisplayDeleteButton(); 
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


		private void InitializeListOfSentiment()
		{
			listBoxSentiment.DataSource = generalManagement.SentimentManagement.AllSentiments;  
		}
		
		private Sentiment.TypeSentiment IsCheckedType()
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


		private void ClearAllFields()
		{
			textBoxSentiment.Text = "";
			labelError.Text = "";
			labelError.Visible = false; 
		}

		private void DisplayDeleteButton()
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
			if (listBoxSentiment.SelectedIndex == -1)
			{
				labelError.Visible = true;
				labelError.Text = "Error Seleccione un sentimiento a eliminar"; 
			}
			else
			{
				try
				{
					Sentiment sentiment = (Sentiment)listBoxSentiment.SelectedItem;
					generalManagement.SentimentManagement.DeleteSentiment(sentiment);
					DisplayDeleteButton();
					MessageBox.Show("El sentimiento se ha eliminado con exito.");
					InitializeListOfSentiment();
				}catch(TextManagementException exc)
				{
					labelError.Visible = true;
					labelError.Text = exc.Message; 
				}
				
			}
		}
		
    }
}
