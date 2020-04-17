using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Sentiment
	{

		public string SentimientText { get; set;  }

		public string SentimentType { get; set; }

		


		public Sentiment(string text, string type){
			SentimientText = text;
			SentimentType = type; 
		}
		




	}
}
