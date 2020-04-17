using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SentimentManagement
    {

		


		public List<Sentiment> SentimentList { get; set; }
		

		public SentimentManagement()
		{
			SentimentList = new List<Sentiment>(); 
		}



		public void AddSentiment(Sentiment sentiment)
		{
			VerifyFormatAdd(sentiment);
			sentiment.SentimientText = DeleteSpaces(sentiment.SentimientText).Trim();
			SentimentList.Add(sentiment); 
		}

		public bool IsEmpty()
		{
			return SentimentList.Count == 0; 
		}


		private void VerifyFormatAdd(Sentiment sentiment)
		{
			if (String.IsNullOrEmpty(sentiment.SentimientText.Trim()))
			{
				throw new ArgumentNullException();
			}

			if (IsContained(sentiment))
			{
				throw new TextManagementException(MessagesExceptions.ERROR_IS_CONTAINED); 
			}

		}


		private bool IsContained(Sentiment sentiment)
		{
			bool toReturn = false;

			string element= DeleteSpaces(sentiment.SentimientText.ToLower().Trim()); 
			
			for (int i = 0; i < SentimentList.Count() && !toReturn; i++)
			{
				string listElement = SentimentList.ElementAt(i).SentimientText;
				listElement = DeleteSpaces(listElement.ToLower().Trim()); 

				if (element.Contains(listElement) || listElement.Contains(element)) 
				{                                    
					toReturn = true;
				}

			}
			return toReturn;
		}


		private string DeleteSpaces(string text)
		{
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}


		private void VerifyFormatDelete(Sentiment sentiment)
		{
			if (!Exist(sentiment))
			{
				throw new TextManagementException(MessagesExceptions.ERROR_DONT_EXIST); 
			}
		}


		public void DeleteText(Sentiment sentiment)
		{
			VerifyFormatDelete(sentiment); 
			SentimentList.Remove(sentiment); 
		}

		private bool Exist(Sentiment sentiment)
		{
			return SentimentList.Contains(sentiment); 
		}


		
		



	



    }
}
