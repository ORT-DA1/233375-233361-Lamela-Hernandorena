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
						sentiment.IsAssociated = true; 
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
			phrase.PhraseType = SetTypeOfPhrase(positiveCounter, negetiveCounter);
			if (IsNotAssociatedEntity(entityFound))
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

		private bool IsNotAssociatedEntity(Entity entity)
		{
			return entity.EntityName.Equals(""); 
		}
		

		private Phrase.TypePhrase SetTypeOfPhrase(int counterPositive, int counterNegative)
		{
			const int MinimumQuantityNegativeSentiments = 1;
			const int MinimumQuantityPositiveSentiments = 1;
			const int AnyQuantitySentiments = 0; 

			if (counterNegative >= 1 && counterPositive == 0)
			{
				return Phrase.TypePhrase.Negative; 
			}
			else
			{
				if (counterPositive >= 1 && counterNegative == 0)
				{
					return Phrase.TypePhrase.Positive;
				}
				else
				{
					return Phrase.TypePhrase.Neutral;
				}
			}
		}

		public void UpdateAlarms(ITimeProvider provider)
		{
			if (PhraseManagement.AllPhrases.Length > 0)
			{
				DateTime minDate = provider.Now();
				foreach (IAlarm a in AlarmManagement.AllAlarms)
				{
					a.UpdateState(PhraseManagement.AllPhrases, minDate);
				}
			}
		}
	}
}
