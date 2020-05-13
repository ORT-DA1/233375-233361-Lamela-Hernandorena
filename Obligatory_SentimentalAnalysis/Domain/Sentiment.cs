using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace BusinessLogic
{
	public class Sentiment
	{

		public enum TypeSentiment { Positive, Neutral, Negative }

		public string SentimientText { get; set;  }

		public TypeSentiment SentimentType { get; set; }

		public Sentiment(){ 
		}

		public override string ToString()
		{
			return SentimientText; 
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
					return string.Equals(Utilities.DeleteSpaces(SentimientText.Trim()), Utilities.DeleteSpaces(sentiment.SentimientText.Trim()), StringComparison.OrdinalIgnoreCase) && SentimentType.Equals(sentiment.SentimentType);
				}
			}
		}
	}
}
