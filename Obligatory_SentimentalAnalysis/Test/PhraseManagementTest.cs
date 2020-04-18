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
			Phrase phrase = new Phrase("Me encanta Mc Donalds");
			management.AddPhrase(phrase);
			Assert.IsFalse(management.IsEmpty()); 
		}

		[TestMethod]
		public void AddValidPhrase2()
		{
			Phrase phrase = new Phrase("No me gusta Disney");
			management.AddPhrase(phrase);
			Assert.AreEqual("No me gusta Disney", management.PhraseList[0].TextPhrase);  
		}


		[TestMethod]
		[ExpectedException(typeof(PhraseManagementException))]
		public void AddInvalidPhrase()
		{
			Phrase phrase = new Phrase("");
			management.AddPhrase(phrase); 
		}

        [TestMethod]
        public void AddPhraseWithTodayDate()
        {
            Phrase phrase = new Phrase("Amo Burger King", DateTime.Now);
            management.AddPhrase(phrase);
            Assert.IsFalse(management.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddPhraseWithDateAfterToday()
        {

            DateTime aDate = new DateTime(2020, 12, 29);
            Phrase phrase = new Phrase("Amo Burger King", aDate);
            management.AddPhrase(phrase);
        }


        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddInvalidEmptyPhrase()
        {
            Phrase phrase = new Phrase("           ", DateTime.Now);
            management.AddPhrase(phrase);
            
        }
    }
}
