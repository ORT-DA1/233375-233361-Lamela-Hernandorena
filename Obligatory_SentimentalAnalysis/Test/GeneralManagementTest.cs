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
            author2 = new Author()
            {
                UserName = "agustinh",
                Name = "Agustin",
                LastName = "Hernandorena",
                BirthDate = new DateTime(2000, 04, 01)
            };
			management.PhraseManagement.EmptyPhrase();
			management.AuthorManagement.EmptyAll();
			management.AlarmManagement.DeleteAll();
			management.EntityManagement.EmptyEntity();
			management.SentimentManagement.EmptySentiment();
		}

		[TestCleanup]
        public void CleanUp()
        {
            management = new GeneralManagement();
			management.PhraseManagement.EmptyPhrase();
			management.AuthorManagement.EmptyAll();
			management.AlarmManagement.DeleteAll();
			management.EntityManagement.EmptyEntity();
			management.SentimentManagement.EmptySentiment();

		}


		[TestMethod]
		public void AnalysisOfPhrasePositive()
		{
            management.AuthorManagement.AddAuthor(author);
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
                PhraseAuthor = author,
				PhraseDate = DateTime.Now
            };
			management.PhraseManagement.AddPhrase(phrase);
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
            management.AuthorManagement.AddAuthor(author);

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
                PhraseAuthor = author,
				PhraseDate = DateTime.Now
            };
			management.PhraseManagement.AddPhrase(phrase);
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
            management.AuthorManagement.AddAuthor(author);

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
                PhraseAuthor = author,
				PhraseDate = DateTime.Now
            };
			management.PhraseManagement.AddPhrase(phrase);
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
            management.AuthorManagement.AddAuthor(author);

            Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me encanta",
                PhraseAuthor = author,
				PhraseDate = DateTime.Now
            };
			management.PhraseManagement.AddPhrase(phrase);
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me encanta",
				PhraseDate= DateTime.Now,
				Entity= null,
				PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisOfPhraseNeutralEmptySentiment()
		{
            management.AuthorManagement.AddAuthor(author);

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
				TextPhrase="Rappi",
				PhraseAuthor = author,
				PhraseDate = DateTime.Now
			};
			management.PhraseManagement.AddPhrase(phrase);
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
            management.AuthorManagement.AddAuthor(author);

            Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta subway",
				PhraseAuthor= author,
				PhraseDate = DateTime.Now
			};
			management.PhraseManagement.AddPhrase(phrase);
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta subway",
				PhraseDate= DateTime.Now,
				Entity= null,
				PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisPhraseTwoEntities()
		{
            management.AuthorManagement.AddAuthor(author);

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
				TextPhrase= "Me encanta McDonald's y también Starbucks",
				PhraseDate = DateTime.Now,
				PhraseAuthor = author,
			};
			management.PhraseManagement.AddPhrase(phrase);
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
            management.AuthorManagement.AddAuthor(author);

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
                PhraseAuthor = author,
				PhraseDate = DateTime.Now
            };
			management.PhraseManagement.AddPhrase(phrase);
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
            management.AuthorManagement.AddAuthor(author);

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
                PhraseAuthor = author,
				PhraseDate = DateTime.Now
            };
			management.PhraseManagement.AddPhrase(phrase);
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta Mc donalds",
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
            management.AuthorManagement.AddAuthor(author);

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
			Assert.IsTrue(management.AlarmManagement.GetSentimentAlarm(aAlarm).IsActive);
		}

		[TestMethod]
		public void VerifyAlarms2()
		{
            management.AuthorManagement.AddAuthor(author);

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
            management.AuthorManagement.AddAuthor(author);

            Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entity);
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
            management.AuthorManagement.AddAuthor(author);

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
			Assert.IsTrue(management.AlarmManagement.GetSentimentAlarm(aAlarm).IsActive);
		}

		[TestMethod]
		public void VerifyAlarms5()
		{
            management.AuthorManagement.AddAuthor(author);

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
            management.AuthorManagement.AddAuthor(author);

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
			Assert.IsTrue(management.AlarmManagement.GetSentimentAlarm(aAlarm2).IsActive);
			Assert.IsFalse(management.AlarmManagement.GetSentimentAlarm(aAlarm).IsActive);
		}


		[TestMethod]
		public void VerifyAlarms7()
		{
            management.AuthorManagement.AddAuthor(author);

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
            management.AuthorManagement.AddAuthor(author);

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
                Entity = entityExpected, 
                PhraseType= Phrase.TypePhrase.Positive, 
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
            Author prueba = management.AuthorManagement.GetAuthor(author); 
            management.PhraseManagement.DeletePhrasesOfAuthor(author);
            Assert.IsTrue(management.PhraseManagement.AllPhrases.Length == 0);
        }


        //Test of the new type of alarms about Authors: 

        [TestMethod]
		public void VerifyAlarmsOfAuthors()
		{
            management.AuthorManagement.AddAuthor(author);

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
				TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
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
			AuthorAlarm dbAlarm = management.AlarmManagement.GetAuthorAlarm(aAlarm);
			Assert.IsTrue(dbAlarm.IsActive);
            CollectionAssert.Contains(dbAlarm.ParticipantsAuthors, author); 
		}

        [TestMethod]
        public void VerifyAlarmsOfAuthors2()
        {
            management.AuthorManagement.AddAuthor(author);

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
                TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
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
            CollectionAssert.DoesNotContain(aAlarm.ParticipantsAuthors, author); 
        }

        [TestMethod]
        public void VerifyAlarmsAuthorsAlarms()
        {
            management.AuthorManagement.AddAuthor(author);

            AuthorAlarm aAlarm = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
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
            CollectionAssert.DoesNotContain(aAlarm.ParticipantsAuthors, author); 
        }


		[TestMethod]
		public void VerifyAlarmsOfAuthors3()
        {
            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

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
				TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
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
			Assert.IsFalse(aAlarm.IsActive); 
			Assert.IsFalse(aAlarm.ParticipantsAuthors.Count == 2); 
			CollectionAssert.DoesNotContain(aAlarm.ParticipantsAuthors, author);
			CollectionAssert.DoesNotContain(aAlarm.ParticipantsAuthors, author2);
		}

		[TestMethod]
		public void ShowInactiveAlarm()
		{
			AuthorAlarm aAlarm = new AuthorAlarm()
			{
				TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
				QuantityPost = 2,
				QuantityTime = 1,
				IsInHours = false
			};
			string resultExpected = "Alarma de tipo: " + "positiva" + " con estado: " + "inactiva";
			Assert.AreEqual(resultExpected, aAlarm.Show());
		}

		[TestMethod]
		public void ShowActiveAlarm()
		{
            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            AuthorAlarm aAlarm = new AuthorAlarm()
			{
				TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
				QuantityPost = 1,
				QuantityTime = 1,
				IsInHours = false
			};
			management.AlarmManagement.AddAlarm(aAlarm);
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText = "Me gusta",
				SentimentType = Sentiment.TypeSentiment.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
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
				TextPhrase = "Me gusta Coca Cola",
				PhraseDate = new DateTime(2020, 04, 30),
				Entity = entity,
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
			string resultExpected = "Alarma de tipo: " + "positiva" + " con estado: " + "activa" + " con los autores: "
				+ " " + "Josami" + "  " + "agustinh ";
			Assert.AreEqual(resultExpected, management.AlarmManagement.GetAuthorAlarm(aAlarm).Show());
		}

		[TestMethod]
        public void VerifyAlarmsOfAuthors4()
        {
            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);
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
                TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
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
			AuthorAlarm dbAlarm = management.AlarmManagement.GetAuthorAlarm(aAlarm);
			Assert.IsTrue(dbAlarm.IsActive);
			CollectionAssert.Contains(dbAlarm.ParticipantsAuthors, author);
        }


        [TestMethod]
        public void VerifyAlarmsOfAuthors5()
        {

            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);
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
                TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Negative,
                QuantityPost = 1,
                QuantityTime = 2,
                IsInHours = false
            };
            AuthorAlarm aAlarm2 = new AuthorAlarm()
            {
                TypeOfAlarm = AuthorAlarm.TypeOfNewAlarm.Positive,
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
			AuthorAlarm dbAlarm = management.AlarmManagement.GetAuthorAlarm(aAlarm);
			AuthorAlarm dbAlarm2 = management.AlarmManagement.GetAuthorAlarm(aAlarm2);
			Assert.IsTrue(dbAlarm2.IsActive);
            Assert.IsFalse(dbAlarm.IsActive);
            CollectionAssert.Contains(dbAlarm2.ParticipantsAuthors, author2);
            CollectionAssert.DoesNotContain(dbAlarm2.ParticipantsAuthors, author);
            CollectionAssert.DoesNotContain(dbAlarm.ParticipantsAuthors, author);
            CollectionAssert.DoesNotContain(dbAlarm.ParticipantsAuthors, author2);

        }

		[TestMethod]
		public void VerifyUpdateSentiment()
		{

			management.AuthorManagement.AddAuthor(author);
			management.AuthorManagement.AddAuthor(author2);
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
			management.AnalysisPhrase(phrase);
			management.AnalysisPhrase(phrase2);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
			};

			management.AuthorManagement.DeleteAuthor(author);
			management.SentimentManagement.UpdateSentiments(management.PhraseManagement.AllPhrases);
			Assert.IsFalse(sentiment.IsAssociatedToPhrase);

		}




	}
}
