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

			Entity entity = new Entity()
			{
				EntityName = "Mc donalds"
			};
			Phrase phrase = new Phrase()
			{
				TextPhrase = "Me encanta Mc Donalds",
				PhraseDate= DateTime.Now,
				Entity=entity,
				PhraseType = Phrase.TypePhrase.Positive
			};
			management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
			Assert.IsFalse(management.IsEmpty());
		}

		[TestMethod]
		public void AddValidPhrase2()
		{
			Entity entity = new Entity()
			{
				EntityName = "Disney"
			};
			Phrase phrase = new Phrase()
			{
				TextPhrase = "No me gusta Disney",
				PhraseDate= DateTime.Now,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Negative
			};
			management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
		}

        [TestMethod]
        public void AddValidPhrase3()
        {

			Entity entity = new Entity()
			{
				EntityName = "Disney"
			};
			Phrase phrase = new Phrase()
			{
				TextPhrase= "No       me      gusta   Disney",
				PhraseDate= DateTime.Now,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Negative
			};
            management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
			Assert.IsFalse(management.IsEmpty()); 
		}

        [TestMethod]
		[ExpectedException(typeof(PhraseManagementException))]
		public void AddInvalidPhrase2()
		{
			Phrase phrase = new Phrase()
			{
				TextPhrase= ""
			};
			management.AddPhrase(phrase); 
		}

        [TestMethod]
        public void AddPhraseWithTodayDate()
        {
			Entity entity = new Entity()
			{
				EntityName = "Burger King"
			};
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Amo Burger King",
				PhraseDate= DateTime.Now,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive
			};
            management.AddPhrase(phrase);
			CollectionAssert.Contains(management.AllPhrases, phrase);
		}

        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddPhraseWithDateAfterToday()
        {
			DateTime aDate = new DateTime(2020, 12, 29);
			Entity entity = new Entity()
			{
				EntityName = "Burger King"
			};
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Amo Burger King",
				PhraseDate= aDate,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive
			};
			management.AddPhrase(phrase);
        }


        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddInvalidEmptyPhrase()
        {
			Entity entity = new Entity();
			Phrase phrase = new Phrase()
			{
				TextPhrase= "           ",
				PhraseDate= DateTime.Now,
				Entity= entity,
			    PhraseType= Phrase.TypePhrase.Neutral
			};
            management.AddPhrase(phrase);
        }


		[TestMethod]
		[ExpectedException(typeof(PhraseManagementException))]
		public void AddPhraseWithDateBeforeOneYear()
		{
			DateTime aDate = new DateTime(2019, 03, 22);
			Entity entity = new Entity()
			{
				EntityName = "Burger King"
			};

			Phrase phrase = new Phrase()
			{
				TextPhrase= "Amo Burger King",
				PhraseDate= aDate,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive
			};
			management.AddPhrase(phrase);
		}

		[TestMethod]
		public void TryingEqualsMethod()
		{
			DateTime aDate = new DateTime(2020, 03, 22);

			Entity entity = new Entity()
			{
				EntityName = "Burger King"
			};
			Phrase phrase = new Phrase()
			{
				TextPhrase= "Amo Burger King",
				PhraseDate= aDate,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive
			};
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Amo Burger King",
				PhraseDate= aDate,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive
			};
			bool areEquals = phrase.Equals(phrase2);
			Assert.IsTrue(areEquals); 
		}


		[TestMethod]
		public void TryingNotEquals()
		{
			DateTime aDate = new DateTime(2020, 03, 22);
			Entity entity = new Entity()
			{
				EntityName = "Burger King"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "Mc Donalds"
			};

			Phrase phrase = new Phrase()
			{
				TextPhrase= "Amo Burger King",
				PhraseDate= aDate,
				Entity= entity,
				PhraseType= Phrase.TypePhrase.Positive
			};
			Phrase phrase2 = new Phrase()
			{
				TextPhrase= "Amo Mc Donalds",
				PhraseDate= aDate,
				Entity= entity2,
				PhraseType= Phrase.TypePhrase.Positive
			};
			bool areEquals = phrase.Equals(phrase2);
			Assert.IsFalse(areEquals);
		}
	}
}
