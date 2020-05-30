using Domain;
using System;

namespace BusinessLogic
{
	public class GeneralManagement
	{
		public AlarmManagement AlarmManagement { get; set; }
		public PhraseManagement PhraseManagement { get; set; }
		public EntityManagement EntityManagement { get; set; }
		public SentimentManagement SentimentManagement { get; set; }
        public AuthorManagement AuthorManagement { get; set; }

		public GeneralManagement()
		{
			EntityManagement = new EntityManagement();
			SentimentManagement = new SentimentManagement();
			AlarmManagement = new AlarmManagement();
			PhraseManagement = new PhraseManagement();
            AuthorManagement = new AuthorManagement(); 
		}

		public void AnalysisPhrase(Phrase phrase)
		{
			int positiveCounter = 0;
			int negetiveCounter = 0;
			string textOfPhrase = Utilities.DeleteSpaces(phrase.TextPhrase.ToLower()); 

			foreach (Sentiment sentiment in SentimentManagement.AllSentiments)
			{
				string sentimentOfList = Utilities.DeleteSpaces(sentiment.SentimientText.ToLower());

				if (textOfPhrase.Contains(sentimentOfList))
				{
					if (sentiment.SentimentType.Equals(Sentiment.TypeSentiment.Positive))
					{
						positiveCounter++;
						sentiment.IsAssociatedToPhrase = true;  
					}
					else
					{
						negetiveCounter++;
						sentiment.IsAssociatedToPhrase = true; 
					}
				}
			}
			Entity entityFound = FindEntity(textOfPhrase); 
			phrase.Entity = entityFound;
			phrase.SetTypeOfPhrase(positiveCounter, negetiveCounter);
			if (entityFound.IsEmptyEntity())
			{
				phrase.PhraseType = Phrase.TypePhrase.Neutral;
			}
		}

		private Entity FindEntity(string textOfPhrase)
		{
			int minUbication = 9999; 
			Entity entityFound = new Entity(); 

			foreach (Entity entity in EntityManagement.AllEntities)
			{
				string entityOfList = Utilities.DeleteSpaces(entity.EntityName.ToLower());
				
				if (textOfPhrase.Contains(entityOfList))
				{
					if(textOfPhrase.IndexOf(entityOfList) < minUbication)
					{
						minUbication = textOfPhrase.IndexOf(entityOfList);
						entityFound = entity;
					}
				}
			}
			return entityFound; 
		}

        public void DeleteAuthorPhrases(Author author)
        {
            author.DeleteAllPhrases();
            PhraseManagement.DeletePhrasesOfAuthor(author); 
        }

		
		public void UpdateAlarms(ITimeProvider provider)
		{
			if (PhraseManagement.AllPhrases.Length > 0)
			{
				DateTime minDate = provider.Now();
				foreach (IAlarm alarm in AlarmManagement.AllAlarms)
				{
					alarm.UpdateState(PhraseManagement.AllPhrases, minDate);
				}
			}
		}
	}
}
