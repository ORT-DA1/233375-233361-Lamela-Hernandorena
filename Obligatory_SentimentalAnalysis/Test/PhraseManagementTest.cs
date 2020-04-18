using System;
using BusinessLogic;
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
	}
}
