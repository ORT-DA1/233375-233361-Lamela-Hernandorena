﻿using System;
using BusinessLogicExceptions; 


namespace Domain 
{
	public class Sentiment
	{
		public enum TypeSentiment { Positive, Neutral, Negative }

		public string SentimientText { get; set;  }

		public TypeSentiment SentimentType { get; set; }

		public bool IsAssociated { get; set; }

		public Sentiment(){
			IsAssociated = false; 
		}

		public override string ToString()
		{
			return SentimientText; 
		}

		public void VerifyFormat()
		{
			if (String.IsNullOrEmpty(SentimientText.Trim()))
			{
				throw new TextManagementException(MessagesExceptions.ErrorIsEmpty);
			}
		}

		public void VerifyFormatToDelete()
		{
			if (IsAssociated)
			{
				throw new TextManagementException(MessagesExceptions.ErrorIsAssociated); 
			}
		}

		public override bool Equals(object obj)
		{
			if(obj== null)
			{
				return false;
			}
			else
			{
				if (this.GetType() != obj.GetType())
				{
					return false;
				}
				else
				{
					Sentiment sentiment = (Sentiment)obj;
					return string.Equals(Utilities.DeleteSpaces(SentimientText.Trim()), 
						Utilities.DeleteSpaces(sentiment.SentimientText.Trim()), 
						StringComparison.OrdinalIgnoreCase) && SentimentType.Equals(sentiment.SentimentType);
				}
			}
		}
	}
}
