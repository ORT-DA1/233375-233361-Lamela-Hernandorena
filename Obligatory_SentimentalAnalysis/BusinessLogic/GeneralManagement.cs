using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			int entityCounter = 0;
			Entity entityFound = new Entity();
			
			string textOfPhrase = DeleteSpaces(phrase.TextPhrase.ToLower()); 
			         //Tipo de variable de los elementos de la lista, el sentiment en minuscula guardo los elementos que estoy recorriendo, y luego va in y la list que voy a recorrer.
			foreach (Sentiment sentiment in SentimentManagement.SentimentList)
			{
				string sentimentOfList = DeleteSpaces(sentiment.SentimientText.ToLower()); // este es el sentimiento que estoy agarrando en la recorrida


				if (textOfPhrase.Contains(sentimentOfList))
				{
					if (sentiment.SentimentType.Equals(Sentiment.sentimentType.Positive))
					{
						positiveCounter++;
					}
					else
					{
						negetiveCounter++; 
					}
					
				}
			}
			
			foreach (Entity entity in EntityManagement.EntityList)
			{
				string entityOfList = DeleteSpaces(entity.EntityName.ToLower()); 

				if (textOfPhrase.Contains(entityOfList) && (entityCounter < 1)) //Tiene que entrar con 0 solamente, sino con 1 entra dos veces
				{
					entityCounter++;
					entityFound = entity; 
				}
			}
			
			phrase.Entity = entityFound;
			phrase.TypePhrase = SetTypeOfPhrase(positiveCounter, negetiveCounter);

			if (entityFound.EntityName.Equals(""))
			{
				phrase.TypePhrase = Phrase.typePhrase.Neutral; 
			}
		}
		
		private Phrase.typePhrase SetTypeOfPhrase(int counterPositive, int counterNegative)
		{
			if (counterNegative >= 1 && counterPositive == 0)
			{
				return Phrase.typePhrase.Negative; 
			}
			else
			{
				if (counterPositive >= 1 && counterNegative == 0)
				{
					return Phrase.typePhrase.Positive;
				}
				else
				{
					return Phrase.typePhrase.Neutral;
				}
			}
		}

		private string DeleteSpaces(string text)
		{
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}

		public void UpdateAlarms(ITimeProvider provider)
		{

			if (PhraseManagement.PhraseList.Count() > 0)
			{
				DateTime minDate = provider.Now();
				int counterPost = 0;
				foreach (Alarm a in AlarmManagement.AlarmList)
				{
					counterPost = 0;
					foreach (Phrase p in PhraseManagement.PhraseList)
					{
						if (a.IsInHours)
						{
							minDate = provider.Now().AddHours(-a.QuantityTime);
						}
						else
						{
							minDate = provider.Now().AddDays(-a.QuantityTime);
						}
						if (p.PhraseDate >= minDate)
						{
							if (p.Entity.Equals(a.Entity) && p.TypePhrase.ToString().Equals(a.TypeOfAlarm.ToString()))
							{
								counterPost++;
							}
						}
					}
					if (counterPost >= a.QuantityPost)
					{
						a.Active = true;
					}
				}
			}
		}
		
	}
}
