using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Sentiment
	{

		public enum sentimentType { Positive, Neutral, Negative }

		public string SentimientText { get; set;  }

		public sentimentType SentimentType { get; set; }

		public Sentiment(string text, sentimentType type){
			SentimientText = text;
			SentimentType = type ; 
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
					return string.Equals(DeleteSpaces(SentimientText.Trim()), DeleteSpaces(sentiment.SentimientText.Trim()), StringComparison.OrdinalIgnoreCase) && SentimentType.Equals(sentiment.SentimentType);
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



	}
}
