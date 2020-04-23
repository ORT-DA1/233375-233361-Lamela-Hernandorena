using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class PhraseManagementTest
	{

		PhraseManagement management; 

		[TestInitialize]
		public void SetUp()
		{
			management = new PhraseManagement(); 
		}


		[TestMethod]
		public void AddValidPhrase()
		{
			Entity entity = new Entity("Mc donalds"); 
			Phrase phrase = new Phrase("Me encanta Mc Donalds", DateTime.Now, entity, Phrase.typePhrase.Positive);
			management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
			Assert.IsFalse(management.IsEmpty());
		}

		[TestMethod]
		public void AddValidPhrase2()
		{
			Entity entity = new Entity("Disney");
			Phrase phrase = new Phrase("No me gusta Disney", DateTime.Now, entity, Phrase.typePhrase.Negative);
			management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
		}

        [TestMethod]
        public void AddValidPhrase3()
        {
			Entity entity = new Entity("Disney");
			Phrase phrase = new Phrase("No       me      gusta   Disney", DateTime.Now, entity, Phrase.typePhrase.Negative);
            management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
			Assert.IsFalse(management.IsEmpty()); 
		}

        [TestMethod]
		[ExpectedException(typeof(PhraseManagementException))]
		public void AddInvalidPhrase2()
		{
			Phrase phrase = new Phrase("");
			management.AddPhrase(phrase); 
		}

        [TestMethod]
        public void AddPhraseWithTodayDate()
        {
			Entity entity = new Entity("Burger King");
			Phrase phrase = new Phrase("Amo Burger King", DateTime.Now, entity, Phrase.typePhrase.Positive);
            management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
		}

        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddPhraseWithDateAfterToday()
        {
			DateTime aDate = new DateTime(2020, 12, 29);
			Entity entity = new Entity("Burger King");
			Phrase phrase = new Phrase("Amo Burger King", aDate, entity, Phrase.typePhrase.Positive);
			management.AddPhrase(phrase);
        }


        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddInvalidEmptyPhrase()
        {
			Entity entity = new Entity("");
			Phrase phrase = new Phrase("           ", DateTime.Now,entity, Phrase.typePhrase.Neutral);
            management.AddPhrase(phrase);
            
        }


		[TestMethod]
		[ExpectedException(typeof(PhraseManagementException))]
		public void AddPhraseWithDateBeforeOneYear()
		{
			DateTime aDate = new DateTime(2019, 03, 22);
			Entity entity = new Entity("Burger King");
			Phrase phrase = new Phrase("Amo Burger King", aDate, entity, Phrase.typePhrase.Positive);
			management.AddPhrase(phrase);
		}

		[TestMethod]
		public void TryingEqualsMethod()
		{
			DateTime aDate = new DateTime(2020, 03, 22);
			Entity entity = new Entity("Burger King");
			Phrase phrase = new Phrase("Amo Burger King", aDate, entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Amo Burger King", aDate, entity, Phrase.typePhrase.Positive);
			bool areEquals = phrase.Equals(phrase2);
			Assert.IsTrue(areEquals); 
		}


		[TestMethod]
		public void TryingNotEquals()
		{
			DateTime aDate = new DateTime(2020, 03, 22);
			Entity entity = new Entity("Burger King");
			Entity entity2 = new Entity("Mc Donalds");
			Phrase phrase = new Phrase("Amo Burger King", aDate, entity, Phrase.typePhrase.Positive);
			Phrase phrase2 = new Phrase("Amo Mc Donalds", aDate, entity2, Phrase.typePhrase.Positive);
			bool areEquals = phrase.Equals(phrase2);
			Assert.IsFalse(areEquals);
		}



	}
}
