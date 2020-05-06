using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
	[TestClass]
	public class SentimentManagementTest
	{

		SentimentManagement manegement;
	

		[TestInitialize]
		public void SetUp()
		{
			manegement = new SentimentManagement(); 
			
			
		}


		[TestMethod]
		public void AddValidSentimentPositive1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimentType = Sentiment.sentimentType.Positive,
				SentimientText = "I like it"
			};
		
			manegement.AddSentiment(sentiment);

			CollectionAssert.Contains(manegement.AllSentiments, sentiment); 


		}

		[TestMethod]
		public void AddValidSentimentPositive2()
		{

			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Love",
				SentimentType= Sentiment.sentimentType.Positive
			};

			manegement.AddSentiment(sentiment);

			CollectionAssert.Contains(manegement.AllSentiments, sentiment); 
		}


		[ExpectedException(typeof(TextManagementException))]
		[TestMethod]
		public void VerifySentimentContained1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me     gusta",
				SentimentType=Sentiment.sentimentType.Positive
			};
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "No       me         gusta",
				SentimentType= Sentiment.sentimentType.Negative
			};
			manegement.AddSentiment(sentiment2); 

		}

		[ExpectedException(typeof(TextManagementException))]
		[TestMethod]
		public void VerifySentimentContained2()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "No                                me                                              gusta",
				SentimentType=  Sentiment.sentimentType.Negative
			};
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me            gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			
			manegement.AddSentiment(sentiment2);

		}


		[TestMethod]
		public void VerifySentimentNotContained1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText="Me encanta",
				SentimentType=Sentiment.sentimentType.Positive
			};
			
			manegement.AddSentiment(sentiment2);


			Assert.IsTrue(manegement.AllSentiments.Length==2); 
		}


		[TestMethod]
		public void VerifySentimentNotContained2()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me        gusta mucho                ",
				SentimentType= Sentiment.sentimentType.Positive
			} ;
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "                     Me encanta                            ",
				SentimentType=  Sentiment.sentimentType.Positive
			};
			
			manegement.AddSentiment(sentiment2);

			CollectionAssert.Contains(manegement.AllSentiments, sentiment); 
			
		}


		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void NotAddInvalidadSentimentPositive1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText = "                               ",
				SentimentType=  Sentiment.sentimentType.Neutral
			};
			manegement.AddSentiment(sentiment); 
		}


		
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NotAddInvalidSentimentPositive2()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "",
				SentimentType= Sentiment.sentimentType.Neutral
			};
			
			manegement.AddSentiment(sentiment); 

		}

		[TestMethod]
		public void DeleteSentimentPositive()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.DeleteText(sentiment);
			Assert.IsTrue(manegement.IsEmpty()); 
		}



		[TestMethod]
		public void DeleteThreeSentimentPositive1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			Sentiment sentiment3 = new Sentiment()
			{
				SentimientText= "Lo amo",
				SentimentType = Sentiment.sentimentType.Positive
			};
			Sentiment sentiment4 = new Sentiment()
			{
				SentimientText= "Es precioso",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.AddSentiment(sentiment2);
			manegement.AddSentiment(sentiment3);
			manegement.AddSentiment(sentiment4);
			manegement.DeleteText(sentiment2);
			manegement.DeleteText(sentiment3);
			manegement.DeleteText(sentiment);

			CollectionAssert.Contains(manegement.AllSentiments, sentiment4); 
		}
		

		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void DeleteNotExistSentiment()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.DeleteText(sentiment);
			manegement.DeleteText(sentiment); 
		}


		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void DeleteNotExistSentiment2()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment2); 
			manegement.DeleteText(sentiment);
			manegement.DeleteText(sentiment2);
			manegement.DeleteText(sentiment2); 
			
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TryingDeleteEmptySentiment()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.DeleteText(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment2);
			manegement.DeleteText(sentiment2);

		}

        [TestMethod]
        public void AddValidSentimentNegative1()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
			CollectionAssert.Contains(manegement.AllSentiments, sentiment); 
        }

        [TestMethod]
        public void AddValidSentimentNegative2()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Detesto",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
			CollectionAssert.Contains(manegement.AllSentiments, sentiment); 
        }

        [ExpectedException(typeof(TextManagementException))]
        [TestMethod]
        public void VerifyNegativeSentimentContained1()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "No     me gusta",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "No me gusta para nada",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment2);
        }

        [ExpectedException(typeof(TextManagementException))]
        [TestMethod]
        public void VerifyNegativeSentimentContained2()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "No me gusta en absoluto",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "NO   ME GUSTA",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment2);
        }

        [TestMethod]
        public void VerifyNegativeSentimentNotContained1()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Lo detesto",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment2);
			Assert.IsTrue(manegement.AllSentiments.Length == 2);
        }

        [TestMethod]
        public void VerifyNegativeSentimentNotContained2()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "  Lo  odio              ",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Yo    odio",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment2);
			CollectionAssert.Contains(manegement.AllSentiments, sentiment); 
        }

        [TestMethod]
        public void DeleteNegativeSentiment()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Es nefasto",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
            manegement.DeleteText(sentiment);
            Assert.IsTrue(manegement.IsEmpty());
        }

        [TestMethod]
        public void DeleteThreeNegativesSentiments1()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.sentimentType.Negative
			};
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Lo detesto",
				SentimentType= Sentiment.sentimentType.Negative
			};
            Sentiment sentiment3 = new Sentiment()
			{
				SentimientText= "Es nefasto",
				SentimentType= Sentiment.sentimentType.Negative
			};
            Sentiment sentiment4 = new Sentiment()
			{
				SentimientText= "De lo peor",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
            manegement.AddSentiment(sentiment2);
            manegement.AddSentiment(sentiment3);
            manegement.AddSentiment(sentiment4);
            manegement.DeleteText(sentiment2);
            manegement.DeleteText(sentiment3);
            manegement.DeleteText(sentiment);
			CollectionAssert.Contains(manegement.AllSentiments, sentiment4); 
        }

       

        [TestMethod]
        [ExpectedException(typeof(TextManagementException))]
        public void DeleteNotExistNegativeSentiment()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.sentimentType.Negative
			};
            manegement.AddSentiment(sentiment);
            manegement.DeleteText(sentiment);
            manegement.DeleteText(sentiment);
        }


		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void TryingAddInvalidSentiment()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Posible",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Imposible",
				SentimentType= Sentiment.sentimentType.Negative
			};
			manegement.AddSentiment(sentiment2); 
		}

		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void TryingAddInvalidSentiment2()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Imposible",
				SentimentType= Sentiment.sentimentType.Negative
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Posible",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment2);
		}


		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void TryingAddRepeteadSentiment()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Posible",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Posible",
				SentimentType= Sentiment.sentimentType.Positive
			};
			manegement.AddSentiment(sentiment2);
		}



		[TestMethod]
		public void TryingToString()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			Assert.AreEqual("Me gusta", sentiment.ToString()); 
		}

		[TestMethod]
		public void TestingReduceSpace()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me       gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			bool areEquals = sentiment.Equals(sentiment2);
			Assert.IsTrue(areEquals); 

		}

		



	}
}
