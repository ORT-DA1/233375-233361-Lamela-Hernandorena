using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class GeneralManagementTest
	{
		GeneralManagement management; 

		[TestInitialize]
		public void SetUp()
		{
			management = new GeneralManagement();
		}


		[TestMethod]
		public void AnalysisOfPhrasePositive()
		{
			Entity entityExpected = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment); 
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola"
			}; 
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				TypePhrase= Phrase.typePhrase.Positive
			};
			Assert.AreEqual(expectedPhrase, phrase); 
			
		}


		[TestMethod]
		public void AnalysisOfPhraseNegative()
		{
			Entity entityExpected = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me disgusta",
				SentimentType= Sentiment.sentimentType.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me disgusta Coca Cola"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me disgusta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				TypePhrase= Phrase.typePhrase.Negative
			};
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisOfPhraseNeutral()
		{
			Entity entityExpected = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me disgusta",
				SentimentType= Sentiment.sentimentType.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me disgusta me encanta Coca Cola"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me disgusta me encanta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				TypePhrase= Phrase.typePhrase.Neutral
			};
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void AnalysisOfPhraseNeutralEmptyEntity()
		{
			Entity entityExpected = new Entity(""); 
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me encanta"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me encanta",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				TypePhrase= Phrase.typePhrase.Neutral
			};
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisOfPhraseNeutralEmptySentiment()
		{
			Entity entityExpected = new Entity("Rappi");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
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
				TypePhrase= Phrase.typePhrase.Neutral
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
				Entity= new Entity(""),
				TypePhrase= Phrase.typePhrase.Neutral
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
				Entity= new Entity(""),
				TypePhrase= Phrase.typePhrase.Neutral
			};
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void AnalysisPhraseTwoEntities()
		{
			Entity entity = new Entity("McDonald's");
			management.EntityManagement.AddEntity(entity); 
			Entity entity2 = new Entity("Starbucks");
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
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
				TypePhrase= Phrase.typePhrase.Positive
			};
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisOfPhraseTwoSentimentPositive()
		{
			Entity entityExpected = new Entity("Rappi");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta me encanta Rappi"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta me encanta Rappi",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				TypePhrase= Phrase.typePhrase.Positive
			};
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisOfPhraseNotContainsEntity()
		{
			Entity entityExpected = new Entity("Mc donalds");
			management.EntityManagement.AddEntity(entityExpected); 
			Entity entity2 = new Entity("Rappi");
			management.EntityManagement.AddEntity(entity2);
			Entity entity = new Entity("Coca cola");
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me encanta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Mc       donalds"
			};
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase()
			{
				TextPhrase= "Me gusta Mc       donalds",
				PhraseDate= DateTime.Now,
				Entity= entityExpected,
				TypePhrase= Phrase.typePhrase.Positive
			};
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void VerifyAlarms()
		{
			Entity entity = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, true);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= DateTime.Now,
				Entity= entity,
				TypePhrase= Phrase.typePhrase.Positive
			};
			management.PhraseManagement.AddPhrase(phrase);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2019, 10, 1, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsTrue(aAlarm.Active);
		}

		[TestMethod]
		public void VerifyAlarms2()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020,04,28),
				Entity= entity,
				TypePhrase= Phrase.typePhrase.Positive
			};
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Me gusta Pepsi",
				PhraseDate= DateTime.Now,
				Entity= entity2,
				TypePhrase= Phrase.typePhrase.Positive
			};
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm.Active);
		}


		[TestMethod]
		public void VerifyAlarms3()
		{
			Entity entity = new Entity("Coca Cola");
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm.Active);
		}


		[TestMethod]
		public void VerifyAlarms4()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity,
				TypePhrase= Phrase.typePhrase.Positive
			};
			Phrase phrase2 = new Phrase()
			{
				TextPhrase="Me gusta Pepsi",
				PhraseDate= new DateTime(2020, 04, 26),
				Entity= entity2,
				TypePhrase= Phrase.typePhrase.Positive
			};
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 26, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsTrue(aAlarm.Active);
		}

		[TestMethod]
		public void VerifyAlarms5()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 2, false);
			Alarm aAlarm2 = new Alarm(entity2, Alarm.Type.Negative, 1, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity,
				TypePhrase= Phrase.typePhrase.Positive
			};
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Me gusta Pepsi",
				PhraseDate= new DateTime(2020,04,30),
				Entity= entity2,
				TypePhrase= Phrase.typePhrase.Positive
			};
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 30, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm2.Active);
		}

		[TestMethod]
		public void VerifyAlarms6()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Me gusta",
				SentimentType= Sentiment.sentimentType.Positive
			};
			Sentiment sentiment2 = new Sentiment()
			{
				SentimientText= "Odio",
				SentimentType= Sentiment.sentimentType.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			management.SentimentManagement.AddSentiment(sentiment2);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 10, 1, false);
			Alarm aAlarm2 = new Alarm(entity2, Alarm.Type.Negative, 2, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Me gusta Coca Cola",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity,
				TypePhrase= Phrase.typePhrase.Positive
			};
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Odio Pepsi",
				PhraseDate= new DateTime(2020, 04, 25),
				Entity= entity2,
				TypePhrase= Phrase.typePhrase.Negative
			};
			Phrase phrase3 = new Phrase()
			{
				TextPhrase= "Odio con todo mi ser a Pepsi",
				PhraseDate=  new DateTime(2020, 04, 25),
				Entity= entity2,
				TypePhrase= Phrase.typePhrase.Negative
			};
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.PhraseManagement.AddPhrase(phrase3);

			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 04, 26, 19, 10, 30)
			};
			management.UpdateAlarms(provider);
			Assert.IsTrue(aAlarm2.Active);
			Assert.IsFalse(aAlarm.Active);
		}


		[TestMethod]
		public void VerifyAlarms7()
		{
			Entity entity = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment()
			{
				SentimientText= "Odio",
				SentimentType= Sentiment.sentimentType.Negative
			};
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Odio Coca Cola",
				PhraseDate= new DateTime(2020,02,10),
				Entity= entity,
				TypePhrase= Phrase.typePhrase.Negative
			};
			management.PhraseManagement.AddPhrase(phrase);
			MockedTimeProvider provider = new MockedTimeProvider()
			{
				MockedDateTime = new DateTime(2020, 02, 10, 19, 10, 30)
			};

			management.UpdateAlarms(provider);
			Assert.IsFalse(aAlarm.Active);
		}
	}
}
