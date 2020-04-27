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
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment); 
			Phrase phrase = new Phrase("Me gusta Coca Cola"); 
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me gusta Coca Cola", DateTime.Now, entityExpected, Phrase.typePhrase.Positive);
			Assert.AreEqual(expectedPhrase, phrase); 
			
		}


		[TestMethod]
		public void AnalysisOfPhraseNegative()
		{
			Entity entityExpected = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment("Me disgusta", Sentiment.sentimentType.Negative);
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment("Me encanta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase("Me disgusta Coca Cola");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me disgusta Coca Cola", DateTime.Now, entityExpected, Phrase.typePhrase.Negative);
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisOfPhraseNeutral()
		{
			Entity entityExpected = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment("Me disgusta", Sentiment.sentimentType.Negative);
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment("Me encanta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase("Me disgusta me encanta Coca Cola");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me disgusta me encanta Coca Cola", DateTime.Now, entityExpected, Phrase.typePhrase.Neutral);
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void AnalysisOfPhraseNeutralEmptyEntity()
		{
			Entity entityExpected = new Entity(""); 
			Sentiment sentiment = new Sentiment("Me encanta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase("Me encanta");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me encanta", DateTime.Now, entityExpected , Phrase.typePhrase.Neutral);
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisOfPhraseNeutralEmptySentiment()
		{
			Entity entityExpected = new Entity("Rappi");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment("Me encanta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase("Rappi");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Rappi", DateTime.Now, entityExpected, Phrase.typePhrase.Neutral);
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisUnregistredSentimentAndEntity()
		{
			Phrase phrase = new Phrase("Me gusta subway");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me gusta subway", DateTime.Now, new Entity(""), Phrase.typePhrase.Neutral);
			Assert.AreEqual(expectedPhrase, phrase);
		}


		[TestMethod]
		public void AnalysisEmptyPhrase()
		{
			Phrase phrase = new Phrase("");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("", DateTime.Now, new Entity(""), Phrase.typePhrase.Neutral);
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void AnalysisPhraseTwoEntities()
		{
			Entity entity = new Entity("McDonald's");
			management.EntityManagement.AddEntity(entity); 
			Entity entity2 = new Entity("Starbucks");
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment("Me encanta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Phrase phrase = new Phrase("Me encanta McDonald's y también Starbucks");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me encanta McDonald's y también Starbucks", DateTime.Now, entity, Phrase.typePhrase.Positive);
			Assert.AreEqual(expectedPhrase, phrase);
		}



		[TestMethod]
		public void AnalysisOfPhraseTwoSentimentPositive()
		{
			Entity entityExpected = new Entity("Rappi");
			management.EntityManagement.AddEntity(entityExpected);
			Sentiment sentiment = new Sentiment("Me encanta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase("Me gusta me encanta Rappi");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me gusta me encanta Rappi", DateTime.Now, entityExpected, Phrase.typePhrase.Positive);
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
			Sentiment sentiment = new Sentiment("Me encanta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Sentiment sentiment2 = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment2);
			Phrase phrase = new Phrase("Me gusta Mc       donalds");
			management.AnalysisPhrase(phrase);
			Phrase expectedPhrase = new Phrase("Me gusta Mc       donalds", DateTime.Now, entityExpected, Phrase.typePhrase.Positive);
			Assert.AreEqual(expectedPhrase, phrase);
		}

		[TestMethod]
		public void VerifyAlarms()
		{
			Entity entity = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, true);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase("Me gusta Coca Cola", DateTime.Now, entity, Phrase.typePhrase.Positive);
			management.PhraseManagement.AddPhrase(phrase);
			management.UpdateAlarms();
			Assert.IsTrue(aAlarm.Active);
		}

		[TestMethod]
		public void VerifyAlarms2()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase("Me gusta Coca Cola", new DateTime(2020,04,24), entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Me gusta Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Positive);
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.UpdateAlarms();
			Assert.IsFalse(aAlarm.Active);
		}


		[TestMethod]
		public void VerifyAlarms3()
		{
			Entity entity = new Entity("Coca Cola");
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			management.UpdateAlarms();
			Assert.IsFalse(aAlarm.Active);
		}


		[TestMethod]
		public void VerifyAlarms4()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase("Me gusta Coca Cola", new DateTime(2020, 04, 25), entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Me gusta Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Positive);
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.UpdateAlarms();
			Assert.IsTrue(aAlarm.Active);
		}

		[TestMethod]
		public void VerifyAlarms5()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 2, false);
			Alarm aAlarm2 = new Alarm(entity2, Alarm.Type.Negative, 1, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase("Me gusta Coca Cola", new DateTime(2020, 04, 25), entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Me gusta Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Positive);
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.UpdateAlarms();
			Assert.IsFalse(aAlarm2.Active);
		}

		[TestMethod]
		public void VerifyAlarms6()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 2, false);
			Alarm aAlarm2 = new Alarm(entity2, Alarm.Type.Negative, 1, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase("Me gusta Coca Cola", new DateTime(2020, 04, 25), entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Me gusta Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Positive);
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.UpdateAlarms();
			Assert.IsFalse(aAlarm2.Active);
		}

		[TestMethod]
		public void VerifyAlarms7()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			Sentiment sentiment2 = new Sentiment("Odio", Sentiment.sentimentType.Negative);
			management.SentimentManagement.AddSentiment(sentiment);
			management.SentimentManagement.AddSentiment(sentiment2);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 10, 1, false);
			Alarm aAlarm2 = new Alarm(entity2, Alarm.Type.Negative, 2, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase("Me gusta Coca Cola", new DateTime(2020, 04, 25), entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Odio Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Negative);
			Phrase phrase3 = new Phrase("Odio con todo mi ser a Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Negative);
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.PhraseManagement.AddPhrase(phrase3);
			management.UpdateAlarms();
			Assert.IsTrue(aAlarm2.Active);
			Assert.IsFalse(aAlarm.Active);
		}

		[TestMethod]
		public void VerifyAlarms8()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("Pepsi");
			management.EntityManagement.AddEntity(entity);
			management.EntityManagement.AddEntity(entity2);
			Sentiment sentiment = new Sentiment("Me gusta", Sentiment.sentimentType.Positive);
			Sentiment sentiment2 = new Sentiment("Odio", Sentiment.sentimentType.Negative);
			management.SentimentManagement.AddSentiment(sentiment);
			management.SentimentManagement.AddSentiment(sentiment2);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 10, 1, false);
			Alarm aAlarm2 = new Alarm(entity2, Alarm.Type.Negative, 2, 2, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			management.AlarmManagement.AddAlarm(aAlarm2);
			Phrase phrase = new Phrase("Me gusta Coca Cola", new DateTime(2020, 04, 25), entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Odio Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Negative);
			Phrase phrase3 = new Phrase("Odio con todo mi ser a Pepsi", DateTime.Now, entity2, Phrase.typePhrase.Negative);
			management.PhraseManagement.AddPhrase(phrase);
			management.PhraseManagement.AddPhrase(phrase2);
			management.PhraseManagement.AddPhrase(phrase3);
			management.UpdateAlarms();
			Assert.IsTrue(aAlarm2.Active);
			Assert.IsFalse(aAlarm.Active);
		}


		[TestMethod]
		public void VerifyAlarms9()
		{
			Entity entity = new Entity("Coca Cola");
			management.EntityManagement.AddEntity(entity);
			Sentiment sentiment = new Sentiment("Odio", Sentiment.sentimentType.Negative);
			management.SentimentManagement.AddSentiment(sentiment);
			Alarm aAlarm = new Alarm(entity, Alarm.Type.Positive, 1, 1, false);
			management.AlarmManagement.AddAlarm(aAlarm);
			Phrase phrase = new Phrase("Odio Coca Cola", DateTime.Now, entity, Phrase.typePhrase.Negative);
			management.PhraseManagement.AddPhrase(phrase);
			management.UpdateAlarms();
			Assert.IsFalse(aAlarm.Active);
		}
	}
}
