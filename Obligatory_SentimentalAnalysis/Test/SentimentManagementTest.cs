using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using BusinessLogicExceptions; 

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
				SentimentType = Sentiment.TypeSentiment.Positive,
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
				SentimentType= Sentiment.TypeSentiment.Positive
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
				SentimentType=Sentiment.TypeSentiment.Positive
			};
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "No       me         gusta",
				SentimentType= Sentiment.TypeSentiment.Negative
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
				SentimentType=  Sentiment.TypeSentiment.Negative
			};
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me            gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			
			manegement.AddSentiment(sentiment2);

		}


		[TestMethod]
		public void VerifySentimentNotContained1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText="Me encanta",
				SentimentType=Sentiment.TypeSentiment.Positive
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
				SentimentType= Sentiment.TypeSentiment.Positive
			} ;
			
			manegement.AddSentiment(sentiment);

			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "                     Me encanta                            ",
				SentimentType=  Sentiment.TypeSentiment.Positive
			};
			
			manegement.AddSentiment(sentiment2);

			CollectionAssert.Contains(manegement.AllSentiments, sentiment); 
			
		}


		[ExpectedException(typeof(TextManagementException))]
		[TestMethod]
		public void NotAddInvalidadSentimentPositive1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText = "                               ",
				SentimentType=  Sentiment.TypeSentiment.Neutral
			};
			manegement.AddSentiment(sentiment); 
		}


		
		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void NotAddInvalidSentimentPositive2()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "",
				SentimentType= Sentiment.TypeSentiment.Neutral
			};
			
			manegement.AddSentiment(sentiment); 

		}

		[TestMethod]
		public void DeleteSentimentPositive()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.DeleteSentiment(sentiment);
			Assert.IsTrue(manegement.IsEmpty()); 
		}



		[TestMethod]
		public void DeleteThreeSentimentPositive1()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			Sentiment sentiment3 = new Sentiment()
			{
				SentimientText= "Lo amo",
				SentimentType = Sentiment.TypeSentiment.Positive
			};
			Sentiment sentiment4 = new Sentiment()
			{
				SentimientText= "Es precioso",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.AddSentiment(sentiment2);
			manegement.AddSentiment(sentiment3);
			manegement.AddSentiment(sentiment4);
			manegement.DeleteSentiment(sentiment2);
			manegement.DeleteSentiment(sentiment3);
			manegement.DeleteSentiment(sentiment);

			CollectionAssert.Contains(manegement.AllSentiments, sentiment4); 
		}
		

		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void DeleteNotExistSentiment()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.DeleteSentiment(sentiment);
			manegement.DeleteSentiment(sentiment); 
		}


		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void DeleteNotExistSentiment2()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment2); 
			manegement.DeleteSentiment(sentiment);
			manegement.DeleteSentiment(sentiment2);
			manegement.DeleteSentiment(sentiment2); 
			
		}

		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void TryingDeleteEmptySentiment()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment);
			manegement.DeleteSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment2);
			manegement.DeleteSentiment(sentiment2);

		}

        [TestMethod]
        public void AddValidSentimentNegative1()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.TypeSentiment.Negative
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
				SentimentType= Sentiment.TypeSentiment.Negative
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
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "No me gusta para nada",
				SentimentType= Sentiment.TypeSentiment.Negative
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
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "NO   ME GUSTA",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment2);
        }

        [TestMethod]
        public void VerifyNegativeSentimentNotContained1()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Lo detesto",
				SentimentType= Sentiment.TypeSentiment.Negative
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
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Yo    odio",
				SentimentType= Sentiment.TypeSentiment.Negative
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
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment);
            manegement.DeleteSentiment(sentiment);
            Assert.IsTrue(manegement.IsEmpty());
        }

        [TestMethod]
        public void DeleteThreeNegativesSentiments1()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Lo detesto",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            Sentiment sentiment3 = new Sentiment()
			{
				SentimientText= "Es nefasto",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            Sentiment sentiment4 = new Sentiment()
			{
				SentimientText= "De lo peor",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment);
            manegement.AddSentiment(sentiment2);
            manegement.AddSentiment(sentiment3);
            manegement.AddSentiment(sentiment4);
            manegement.DeleteSentiment(sentiment2);
            manegement.DeleteSentiment(sentiment3);
            manegement.DeleteSentiment(sentiment);
			CollectionAssert.Contains(manegement.AllSentiments, sentiment4); 
        }

       

        [TestMethod]
        [ExpectedException(typeof(TextManagementException))]
        public void DeleteNotExistNegativeSentiment()
        {
            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Lo odio",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
            manegement.AddSentiment(sentiment);
            manegement.DeleteSentiment(sentiment);
            manegement.DeleteSentiment(sentiment);
        }


		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void TryingAddInvalidSentiment()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Posible",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Imposible",
				SentimentType= Sentiment.TypeSentiment.Negative
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
				SentimentType= Sentiment.TypeSentiment.Negative
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Posible",
				SentimentType= Sentiment.TypeSentiment.Positive
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
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Posible",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			manegement.AddSentiment(sentiment2);
		}



		[TestMethod]
		public void TryingToString()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			Assert.AreEqual("Me gusta", sentiment.ToString()); 
		}

		[TestMethod]
		public void TestingReduceSpace()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me       gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			bool areEquals = sentiment.Equals(sentiment2);
			Assert.IsTrue(areEquals); 

		}

		[TestMethod]
		[ExpectedException(typeof(TextManagementException))]
		public void TestDeleteAssosiatedPhrase()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText = "Me gusta",
				SentimentType = Sentiment.TypeSentiment.Positive,
				IsAssociatedToPhrase = true
				
			};
			manegement.AddSentiment(sentiment);
			manegement.DeleteSentiment(sentiment); 
		}





	}
}
