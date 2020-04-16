using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class TextManegementTest
	{

		TextManagement manegement; 

		[TestInitialize]
		public void SetUp()
		{
			manegement = new TextManagement(); 
		}


		[TestMethod]
		public void AddValidSentiment()
		{
			Sentiment sentiment = new Sentiment("I like it");

			sentiment.SentimentType = "Positivo"; 
		
			manegement.AddText(sentiment);

			Assert.IsFalse(manegement.IsEmpty()); 

		}


		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void NotAddInvalidadSentimentPositive1()
		{
			Sentiment sentiment = new Sentiment("");

			sentiment.SentimentType = "Positive";

			manegement.AddText(sentiment); 
		}


		
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NotAddInvalidSentimentPositive2()
		{
			Sentiment sentiment = new Sentiment("                            ");
			sentiment.SentimentType = "Positive";
			manegement.AddText(sentiment); 

		}

	}
}
