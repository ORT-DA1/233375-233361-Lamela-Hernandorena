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
			initializeListOfSentiment();
			DisplayButton();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string sentimentText = textBoxSentiment.Text;

			if (isChecked().Equals(Sentiment.sentimentType.Neutral))
			{
				MessageBox.Show("Debe seleccionar si el tipo de sentimiento."); 
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
					MessageBox.Show(exc.Message); 
				}
				catch(ArgumentNullException exp2)
				{
					MessageBox.Show(exp2.Message); 
				}
			}
			
		}


		private void initializeListOfSentiment()
		{
			listBoxSentiment.DataSource = generalManagement.SentimentManagement.AllSentiments;  
		}
		
		private Sentiment.sentimentType isChecked()
		{
			if (radioButtonNegative.Checked)
			{
				return Sentiment.sentimentType.Negative; 
			}
			else
			{
				if (radioButtonPositive.Checked)
				{
					return Sentiment.sentimentType.Positive;
				}
				else
				{
					return Sentiment.sentimentType.Neutral; 
				}
			}
		}


		private void DeleteText()
		{
			textBoxSentiment.Text = "";
			radioButtonNegative.Checked = false;
			radioButtonPositive.Checked = false; 
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
				MessageBox.Show("Seleccione un sentimiento a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private void listBoxSentiment_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
