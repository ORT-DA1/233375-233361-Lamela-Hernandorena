using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SentimentManagement
    {
		private List<Sentiment> sentimentList; 
		
		public SentimentManagement()
		{
			sentimentList = new List<Sentiment>(); 
		}

		public void AddSentiment(Sentiment sentiment)
		{
			VerifyFormatAdd(sentiment);
			sentiment.SentimientText = Utilities.DeleteSpaces(sentiment.SentimientText).Trim();
			sentimentList.Add(sentiment); 
		}

		public bool IsEmpty()
		{
			return sentimentList.Count == 0; 
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

			string element= Utilities.DeleteSpaces(sentiment.SentimientText.ToLower().Trim()); 
			
			for (int i = 0; i < sentimentList.Count() && !toReturn; i++)
			{
				string listElement = sentimentList.ElementAt(i).SentimientText;
				listElement = Utilities.DeleteSpaces(listElement.ToLower().Trim()); 

				if (element.Contains(listElement) || listElement.Contains(element)) 
				{                                    
					toReturn = true;
				}

			}
			return toReturn;
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
			sentimentList.Remove(sentiment); 
		}

		private bool Exist(Sentiment sentiment)
		{
			return sentimentList.Contains(sentiment); 
		}

		public Sentiment[] AllSentiments
		{
			get { return sentimentList.ToArray();  }
		}
    }
}
