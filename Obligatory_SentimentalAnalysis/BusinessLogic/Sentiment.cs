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


		

	}
}
