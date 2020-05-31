using System;
using BusinessLogic;
using Domain; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class GeneralManagementTest
	{
		GeneralManagement management;
        Author author;
        Author author2; 

		[TestInitialize]
		public void SetUp()
		{
			management = new GeneralManagement();
            author = new Author()
            {
                UserName = "Josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AuthorManagement.AddAuthor(author);
            author2 = new Author()
            {
                UserName = "agustinh",
                Name = "Agustin",
                LastName = "Hernandorena",
                BirthDate = new DateTime(2000, 04, 01)
            };
            management.AuthorManagement.AddAuthor(author2); 
        }


		[TestMethod]
		public void AnalysisOfPhrasePositive()
		{
			Entity entityExpected = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment); 
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
                PhraseAuthor = author
            }; 
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase); 
			
		}


		[TestMethod]
		public void AnalysisOfPhraseNegative()
		{
			Entity entityExpected = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me disgusta",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me disgusta Coca Cola",
                PhraseAuthor = author
            };
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me disgusta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisOfPhraseNeutral()
		{
			Entity entityExpected = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me disgusta",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me disgusta me encanta Coca Cola",
                PhraseAuthor = author
            };
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me disgusta me encanta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				PhraseType= Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void AnalysisOfPhraseNeutralEmptyEntity()
		{
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			Entity entityExpected = new Entity(); 
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me encanta",
                PhraseAuthor = author
            };
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me encanta",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisOfPhraseNeutralEmptySentiment()
		{
			Entity entityExpected = new Entity()
			{
				EntityName = "Rappi"
			};
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase()
			{
				TextPhrase="Rappi"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Rappi",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisUnregistredSentimentAndEntity()
		{
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta subway"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta subway",
				PhraseDate= DateTime.Now,
				Entity= new Entity(),
				PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisEmptyPhrase()
		{
			Phrase phrase = new Phrase()
			{
				TextPhrase= ""
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "",
				PhraseDate= DateTime.Now,
				Entity= new Entity(),
				PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void AnalysisPhraseTwoEntities()
		{
			Entity entity = new Entity()
			{
				EntityName = "McDonald's"
			};
			management.EntityManagement.AddEntity(entity); 
			Entity entity2 = new Entity()
			{
				EntityName = "Starbucks"
			};
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me encanta McDonald's y también Starbucks"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me encanta McDonald's y también Starbucks",
				PhraseDate= DateTime.Now,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisOfPhraseTwoSentimentPositive()
		{
			Entity entityExpected = new Entity()
			{
				EntityName = "Rappi"
			};
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta me encanta Rappi",
                PhraseAuthor = author
            };
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta me encanta Rappi",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}
        
		[TestMethod]
		public void AnalysisOfPhraseNotContainsEntity()
		{
			Entity entityExpected = new Entity()
			{
				EntityName = "Mc donalds"
			};
			management.EntityManagement.AddEntity(entityExpected); 
			Entity entity2 = new Entity()
			{
				EntityName = "Rappi"
			};
			management.EntityManagement.AddEntity(entity2);
			Entity entity = new Entity()
			{
				EntityName = "Coca cola"
			};
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Mc       donalds",
                PhraseAuthor = author
            };
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta Mc       donalds",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void VerifyAlarms()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 1,
				QuantityTime = 1,
				IsInHours = true
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entity,
				PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			management.PhraseManagement.AddPhrase(phrase);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2019, 10, 1, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsTrue(aAlarm.IsActive);
		}

		[TestMethod]
		public void VerifyAlarms2()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "Pepsi"
			};
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 1,
				QuantityTime = 1,
				IsInHours = false
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020,04,28),
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Me gusta Pepsi",
				PhraseDate= DateTime.Now,
				Entity= entity2,
				PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm.IsActive);
		}


		[TestMethod]
		public void VerifyAlarms3()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			Alarm aAlarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 1,
				QuantityTime = 1,
				IsInHours = false
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm.IsActive);
		}


		[TestMethod]
		public void VerifyAlarms4()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "Pepsi"
			};
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 1,
				QuantityTime = 2,
				IsInHours = false
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Phrase phrase2 = new Phrase()
			{
				TextPhrase="Me gusta Pepsi",
				PhraseDate= new DateTime(2020, 04, 26),
				Entity= entity2,
				PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 26, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsTrue(aAlarm.IsActive);
		}

		[TestMethod]
		public void VerifyAlarms5()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "Pepsi"
			};
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 1,
				QuantityTime = 2,
				IsInHours = false
			};
			Alarm aAlarm2 = new Alarm()
			{
				Entity = entity2,
				TypeOfAlarm = Alarm.Type.Negative,
				QuantityPost = 1,
				QuantityTime = 2,
				IsInHours = false
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Me gusta Pepsi",
				PhraseDate= new DateTime(2020,04,30),
				Entity= entity2,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm2.IsActive);
		}

		[TestMethod]
		public void VerifyAlarms6()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "Pepsi"
			};
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Odio",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			management.SentimentManagement.AddSentiment(sentiment2);
			Alarm aAlarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost=10,
				QuantityTime = 1,
				IsInHours = false
			};
			Alarm aAlarm2 = new Alarm()
			{
				Entity = entity2,
				TypeOfAlarm = Alarm.Type.Negative,
				QuantityPost = 2,
				QuantityTime = 2,
				IsInHours = false
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Odio Pepsi",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity2,
				PhraseType= Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
			Phrase phrase3 = new Phrase()
			{
				TextPhrase= "Odio con todo mi ser a Pepsi",
				PhraseDate=  new DateTime(2020, 04, 25),
				Entity= entity2,
				PhraseType= Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.PhraseManagement.AddPhrase(phrase3);

			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 26, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsTrue(aAlarm2.IsActive);
			Assert.IsFalse(aAlarm.IsActive);
		}


		[TestMethod]
		public void VerifyAlarms7()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Odio",
				SentimentType= Sentiment.TypeSentiment.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 1,
				QuantityTime = 1,
				IsInHours = false
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Odio Coca Cola",
				PhraseDate= new DateTime(2020,02,10),
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
			management.PhraseManagement.AddPhrase(phrase);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 02, 10, 19, 10, 30)
			};

			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm.IsActive);
		}

        [TestMethod]
        public void DeleteAllPhrases()
        {
            Entity entityExpected = new Entity()
            {
                EntityName = "Mc donalds"
            };
            management.EntityManagement.AddEntity(entityExpected);
            Entity entity2 = new Entity()
            {
                EntityName = "Rappi"
            };
            management.EntityManagement.AddEntity(entity2);
            Entity entity = new Entity()
            {
                EntityName = "Coca cola"
            };
            management.EntityManagement.AddEntity(entity);
            Sentiment sentiment = new Sentiment()
            {
                SentimientText = "Me encanta",
                SentimentType = Sentiment.TypeSentiment.Positive
            };
            management.SentimentManagement.AddSentiment(sentiment);
            Sentiment sentiment2 = new Sentiment()
            {
                SentimientText = "Me gusta",
                SentimentType = Sentiment.TypeSentiment.Positive
            };
            management.SentimentManagement.AddSentiment(sentiment2);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Me gusta Mc       donalds",
                PhraseDate = DateTime.Now,
                PhraseAuthor = author
            };
            management.PhraseManagement.AddPhrase(phrase); 
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "No me gusta Rappi",
                PhraseDate = DateTime.Now,
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
            management.PhraseManagement.AddPhrase(phrase2);
            management.DeleteAuthorPhrases(author);
            Assert.IsTrue(management.PhraseManagement.AllPhrases.Length == 0);
            Assert.IsTrue(author.AllAuthorPhrases.Length == 0); 
        }


        //Test of the new type of alarms about Authors: 

        [TestMethod]
		public void VerifyAlarmsOfAuthors()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
            AuthorAlarm aAlarm = new AuthorAlarm()
			{
				TypeOfAlarm = AuthorAlarm.Type.Positive,
				QuantityPost = 1,
				QuantityTime = 1,
				IsInHours = true
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entity,
				PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
			management.PhraseManagement.AddPhrase(phrase);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2019, 10, 1, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsTrue(aAlarm.IsActive);
            CollectionAssert.Contains(aAlarm.AllAuthorsWhoActiveAlarm, author); 
		}

        [TestMethod]
        public void VerifyAlarmsOfAuthors2()
        {
            Entity entity = new Entity()
            {
                EntityName = "Coca Cola"
            };
            Entity entity2 = new Entity()
            {
                EntityName = "Pepsi"
            };
            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            Sentiment sentiment = new Sentiment()
            {
                SentimientText = "Me gusta",
                SentimentType = Sentiment.TypeSentiment.Positive
            };
            management.SentimentManagement.AddSentiment(sentiment);
            AuthorAlarm aAlarm = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.Type.Positive,
                QuantityPost = 1,
                QuantityTime = 1,
                IsInHours = false
            };
            management.AlarmManagement.AddAlarm(aAlarm);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Me gusta Coca Cola",
                PhraseDate = new DateTime(2020, 04, 28),
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "Me gusta Pepsi",
                PhraseDate = new DateTime(2020, 04, 25),
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            MockedTimeProvider provider = new MockedTimeProvider()
            {
                MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
            };
            management.UpdateAlarms(provider);
            Assert.IsFalse(aAlarm.IsActive);
            CollectionAssert.DoesNotContain(aAlarm.AllAuthorsWhoActiveAlarm, author); 
        }

        [TestMethod]
        public void VerifyAlarmsAuthorsAlarms()
        {
            AuthorAlarm aAlarm = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.Type.Positive,
                QuantityPost = 1,
                QuantityTime = 1,
                IsInHours = false
            };
            management.AlarmManagement.AddAlarm(aAlarm);
            MockedTimeProvider provider = new MockedTimeProvider()
            {
                MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
            };
            management.UpdateAlarms(provider);
            //Assert.IsFalse(aAlarm.IsActive);
            CollectionAssert.DoesNotContain(aAlarm.AllAuthorsWhoActiveAlarm, author); 
        }


        [TestMethod]
        public void VerifyAlarmsOfAuthors3()
        {
            Entity entity = new Entity()
            {
                EntityName = "Coca Cola"
            };
            Entity entity2 = new Entity()
            {
                EntityName = "Pepsi"
            };
            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            Sentiment sentiment = new Sentiment()
            {
                SentimientText = "Me gusta",
                SentimentType = Sentiment.TypeSentiment.Positive
            };
            management.SentimentManagement.AddSentiment(sentiment);
            AuthorAlarm aAlarm = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.Type.Positive,
                QuantityPost = 2,
                QuantityTime = 1,
                IsInHours = false
            };
            management.AlarmManagement.AddAlarm(aAlarm);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Me gusta Coca Cola",
                PhraseDate = new DateTime(2020, 04, 30),
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "Me gusta Pepsi",
                PhraseDate = new DateTime(2020, 04, 30),
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author2
            };
            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            MockedTimeProvider provider = new MockedTimeProvider()
            {
                MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
            };
            management.UpdateAlarms(provider);
            Assert.IsTrue(aAlarm.IsActive); 
            Assert.IsTrue(aAlarm.AllAuthorsWhoActiveAlarm.Length == 2); 
            CollectionAssert.Contains(aAlarm.AllAuthorsWhoActiveAlarm, author);
            CollectionAssert.Contains(aAlarm.AllAuthorsWhoActiveAlarm, author2);
        }

        [TestMethod]
        public void VerifyAlarmsOfAuthors4()
        {
            Entity entity = new Entity()
            {
                EntityName = "Coca Cola"
            };
            Entity entity2 = new Entity()
            {
                EntityName = "Pepsi"
            };
            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            Sentiment sentiment = new Sentiment()
            {
                SentimientText = "Me gusta",
                SentimentType = Sentiment.TypeSentiment.Positive
            };
            management.SentimentManagement.AddSentiment(sentiment);
            AuthorAlarm aAlarm = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.Type.Positive,
                QuantityPost = 1,
                QuantityTime = 2,
                IsInHours = false
            };
            management.AlarmManagement.AddAlarm(aAlarm);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Me gusta Coca Cola",
                PhraseDate = new DateTime(2020, 04, 25),
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "Me gusta Pepsi",
                PhraseDate = new DateTime(2020, 04, 26),
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            MockedTimeProvider provider = new MockedTimeProvider()
            {
                MockedDateTime = new DateTime(2020, 04, 26, 19, 10, 30)
            };
            management.UpdateAlarms(provider);
            Assert.IsTrue(aAlarm.IsActive);
            CollectionAssert.Contains(aAlarm.AllAuthorsWhoActiveAlarm, author); 
        }


        [TestMethod]
        public void VerifyAlarmsOfAuthors5()
        {
            Entity entity = new Entity()
            {
                EntityName = "Coca Cola"
            };
            Entity entity2 = new Entity()
            {
                EntityName = "Pepsi"
            };
            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            Sentiment sentiment = new Sentiment()
            {
                SentimientText = "Me gusta",
                SentimentType = Sentiment.TypeSentiment.Positive
            };
            management.SentimentManagement.AddSentiment(sentiment);
            AuthorAlarm aAlarm = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.Type.Negative,
                QuantityPost = 1,
                QuantityTime = 2,
                IsInHours = false
            };
            AuthorAlarm aAlarm2 = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.Type.Positive,
                QuantityPost = 1,
                QuantityTime = 2,
                IsInHours = false
            };
            management.AlarmManagement.AddAlarm(aAlarm);
            management.AlarmManagement.AddAlarm(aAlarm2);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Me gusta Coca Cola",
                PhraseDate = new DateTime(2020, 04, 25),
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "Me gusta Pepsi",
                PhraseDate = new DateTime(2020, 04, 30),
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author2
            };
            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            MockedTimeProvider provider = new MockedTimeProvider()
            {
                MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
            };
            management.UpdateAlarms(provider);
            Assert.IsTrue(aAlarm2.IsActive);
            Assert.IsFalse(aAlarm.IsActive);
            CollectionAssert.Contains(aAlarm2.AllAuthorsWhoActiveAlarm, author2);
            CollectionAssert.DoesNotContain(aAlarm2.AllAuthorsWhoActiveAlarm, author);
            CollectionAssert.DoesNotContain(aAlarm.AllAuthorsWhoActiveAlarm, author);
            CollectionAssert.DoesNotContain(aAlarm.AllAuthorsWhoActiveAlarm, author2);

        }


    }
}
