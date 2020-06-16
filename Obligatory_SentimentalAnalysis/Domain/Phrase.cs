using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogicExceptions; 

namespace Domain
{
    [Table("Phrases_Table")]
	public class Phrase
	{
        [Required]
		public string TextPhrase { get; set; }

        [Required]
        public DateTime PhraseDate { get; set; }
        
        public virtual Entity Entity { get; set; }

		public enum TypePhrase { Positive, Neutral, Negative }

        [Required]
        public TypePhrase PhraseType { get; set; }

        [Key]
		public int Id { get; set; }

        [Required]
        public virtual Author PhraseAuthor { get; set; }

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
            Phrase phrase = obj as Phrase;
            if (phrase == null || Convert.IsDBNull(phrase))
            {
                return false;
            }
			bool toReturn = string.Equals(TextPhrase, phrase.TextPhrase, StringComparison.OrdinalIgnoreCase)
			&& PhraseType.Equals(phrase.PhraseType) && PhraseAuthor.Equals(phrase.PhraseAuthor);
			if (phrase.Entity == null)
			{
				toReturn = toReturn && Entity == null;
			}
			if (Entity == null)
			{
				toReturn = toReturn && phrase.Entity == null;
			}
			else
			{
				toReturn = toReturn && Entity.Equals(phrase.Entity);
			}
			return toReturn;
		}
	}
}
