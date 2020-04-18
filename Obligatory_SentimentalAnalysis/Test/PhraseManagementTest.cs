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






























































































































	}
}
