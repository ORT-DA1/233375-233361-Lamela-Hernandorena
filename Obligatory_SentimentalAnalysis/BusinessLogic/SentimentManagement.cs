using Domain;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions; 


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
			sentiment.VerifyFormat(); 
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
			if (IsPartOfAnotherSentiment(sentiment))
			{
				throw new TextManagementException(MessagesExceptions.ErrorIsContained); 
			}
		}

		private bool IsPartOfAnotherSentiment(Sentiment sentiment)
		{
			bool toReturn = false;

			string sentimentText= Utilities.DeleteSpaces(sentiment.SentimientText.ToLower().Trim()); 
			
			for (int i = 0; i < sentimentList.Count() && !toReturn; i++)
			{
				string currentSentiment = sentimentList.ElementAt(i).SentimientText;
				currentSentiment = Utilities.DeleteSpaces(currentSentiment.ToLower().Trim()); 

				if (sentimentText.Contains(currentSentiment) || currentSentiment.Contains(sentimentText)) 
				{                                    
					toReturn = true;
				}

			}
			return toReturn;
		}

		private void VerifyFormatDelete(Sentiment sentiment)
		{
			if (IsNotContained(sentiment))
			{
				throw new TextManagementException(MessagesExceptions.ErrorDontExist); 
			}

		}

		public void DeleteSentiment(Sentiment sentiment)
		{
			sentiment.VerifyFormatToDelete(); 
			VerifyFormatDelete(sentiment);
			sentimentList.Remove(sentiment); 
		}

		private bool IsNotContained(Sentiment sentiment)
		{
			return !sentimentList.Contains(sentiment); 
		}

		public Sentiment[] AllSentiments
		{
			get { return sentimentList.ToArray();  }
		}
    }
}
