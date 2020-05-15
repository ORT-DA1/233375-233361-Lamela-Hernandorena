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

		public GeneralManagement()
		{
			EntityManagement = new EntityManagement();
			SentimentManagement = new SentimentManagement();
			AlarmManagement = new AlarmManagement();
			PhraseManagement = new PhraseManagement();
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
						sentiment.IsAssociated = true;  //Pasarlo
					}
					else
					{
						negetiveCounter++;
						sentiment.IsAssociated = true; 
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
			int entityCounter = 0;
			Entity entityFound = new Entity(); 

			foreach (Entity entity in EntityManagement.AllEntities)
			{
				string entityOfList = Utilities.DeleteSpaces(entity.EntityName.ToLower());

				if (textOfPhrase.Contains(entityOfList) && (entityCounter < 1))
				{
					entityCounter++;
					entityFound = entity; 
				}
			}
			return entityFound; 
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
