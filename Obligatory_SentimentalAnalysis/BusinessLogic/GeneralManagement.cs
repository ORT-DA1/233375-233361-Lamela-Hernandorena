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
			Sentiment[] sentimentsContainedInPhrase = phrase.AllAssociatedSentiments(SentimentManagement.AllSentiments);
			int quantityOfPositiveSentiments = phrase.QuantityOfAssociatedPositiveSentiments(sentimentsContainedInPhrase);
			int quantityOfNegativeSentiments = phrase.QuantityOfAssociatedNegativeSentiments(sentimentsContainedInPhrase);
			SentimentManagement.UpdateAssociatedSentiments(sentimentsContainedInPhrase);
			EntityManagement.AssociateEntityToPhrase(phrase);
			phrase.SetTypeOfPhrase(quantityOfPositiveSentiments, quantityOfNegativeSentiments);
			PhraseManagement.UpdatePhrase(phrase); 
		}

		public void UpdateAlarms(ITimeProvider provider)
		{
				DateTime minDate = provider.Now();
				foreach (IAlarm alarm in AlarmManagement.AllAlarms)
				{
					alarm.UpdateState(PhraseManagement.AllPhrases, minDate);
                    AlarmManagement.Update(alarm); 
				}
			
		}
	}
}
