using System.Windows.Forms;
using BusinessLogic;


namespace UI
{
	public partial class ReportAnalysisPhrase : UserControl
	{
		private GeneralManagement generalManagement;
		public ReportAnalysisPhrase(GeneralManagement general)
		{
			InitializeComponent();
			generalManagement = general;
			InitializeGridOfPhrases();
			ChangeNameOfColumnGrid();
		}
		
		private void InitializeGridOfPhrases()
		{
			grdPhrases.DataSource = generalManagement.PhraseManagement.AllPhrases;
		}


		private void ChangeNameOfColumnGrid()
		{
			for (int i = 0; i < grdPhrases.Columns.Count; i++)
			{
				string columnName = grdPhrases.Columns[i].HeaderText;
				if (columnName == "TextPhrase")
				{
					grdPhrases.Columns[i].HeaderText = "Texto de la frase";
					grdPhrases.Columns[i].Name = "Texto de la frase";
				}

				if (columnName == "PhraseDate")
				{
					grdPhrases.Columns[i].HeaderText = "Fecha de la frase";
					grdPhrases.Columns[i].Name = "Fecha de la frase";

				}

				if (columnName == "Entity")
				{
					grdPhrases.Columns[i].HeaderText = "Entidad";
					grdPhrases.Columns[i].Name = "Entidad";
				}

				if (columnName == "PhraseType")
				{
					grdPhrases.Columns[i].HeaderText = "Tipo de frase";
					grdPhrases.Columns[i].Name = "Tipo de frase";
				}

                if(columnName == "PhraseAuthor")
                {
                    grdPhrases.Columns[i].HeaderText = "Autor";
                    grdPhrases.Columns[i].Name = "Autor";
                }

			}
		}


	}
}
