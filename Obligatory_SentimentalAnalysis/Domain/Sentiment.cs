﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogicExceptions; 


namespace Domain 
{
    [Table("Sentiments_Table")]
	public class Sentiment
	{
		public enum TypeSentiment { Positive, Neutral, Negative }

        [Required]
        public string SentimientText { get; set;  }

        [Required]
        public TypeSentiment SentimentType { get; set; }
        
        public bool IsAssociatedToPhrase { get; set; }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public Sentiment(){
			IsAssociatedToPhrase = false; 
		}

		public override string ToString()
		{
			return SentimientText; 
		}

		public void VerifyFormat()
		{
			if (String.IsNullOrEmpty(SentimientText.Trim()))
			{
				throw new SentimentManagementException(MessagesExceptions.ErrorIsEmpty);
			}
		}

		public void VerifyFormatToDelete()
		{
			if (IsAssociatedToPhrase)
			{
				throw new SentimentManagementException(MessagesExceptions.ErrorIsAssociated); 
			}
		}

		public override bool Equals(object obj)
		{
            Sentiment sentiment = obj as Sentiment;

            if (sentiment == null || Convert.IsDBNull(sentiment))
            {
                return false;
            }
           	return string.Equals(Utilities.DeleteSpaces(SentimientText.Trim()), 
			Utilities.DeleteSpaces(sentiment.SentimientText.Trim()), 
			StringComparison.OrdinalIgnoreCase) && SentimentType.Equals(sentiment.SentimentType);
		}
	}
}
