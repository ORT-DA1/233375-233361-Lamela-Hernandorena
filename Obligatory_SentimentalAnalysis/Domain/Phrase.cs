using System;
using BusinessLogicExceptions; 

namespace Domain
{
	public class Phrase
	{
		public string TextPhrase { get; set; }

		public DateTime PhraseDate { get; set; }

		public  Entity Entity { get; set; }

		public enum TypePhrase { Positive, Neutral, Negative }

		public TypePhrase PhraseType { get; set; }

		public int Id { get; set; }

		public Author PhraseAuthor { get; set; }

		public bool IsDeleted {get;set;}
		
        public Phrase ()
        {
          
        }

		public void VerifyFormat()
		{
			const int DaysOfTheYear = 365;
			if (String.IsNullOrEmpty(TextPhrase))
			{
				throw new PhraseManagementException(MessagesExceptions.ErrorIsEmpty);
			}
			if (PhraseDate > DateTime.Now)
			{
				throw new PhraseManagementException(MessagesExceptions.ErrorIsAfterToday);
			}

			if ((DateTime.Now - PhraseDate).Days > DaysOfTheYear)
			{
				throw new PhraseManagementException(MessagesExceptions.ErrorIsOneYearBefore);
			}
		}

		public void SetTypeOfPhrase(int counterPositive, int counterNegative)
		{
			if (counterNegative >= 1 && counterPositive == 0)
			{
				PhraseType= TypePhrase.Negative;
			}
			else
			{
				if (counterPositive >= 1 && counterNegative == 0)   
				{
					PhraseType = TypePhrase.Positive;
				}
				else
				{
					PhraseType = TypePhrase.Neutral;
				}
			}
		}
		
		public override bool Equals(object obj)
		{
			if(obj == null)
			{
				return false;
			}
			else
			{
				if(GetType() != obj.GetType())
				{
					return false;
				}
				else
				{
					Phrase phrase = (Phrase)obj;
					return string.Equals(TextPhrase, phrase.TextPhrase, StringComparison.OrdinalIgnoreCase) && Entity.Equals(phrase.Entity)
						&& PhraseType.Equals(phrase.PhraseType);
				}
			}
		}
	}
}
