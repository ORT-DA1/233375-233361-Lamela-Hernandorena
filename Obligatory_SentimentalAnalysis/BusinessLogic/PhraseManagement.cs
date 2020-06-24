using Domain;
using System.Collections.Generic;


namespace BusinessLogic
{
	public class PhraseManagement
	{
		private List<Phrase> phraseList; 

		public PhraseManagement()
		{
			phraseList = new List<Phrase>(); 
		}

		public void AddPhrase(Phrase phrase)
		{
			phrase.TextPhrase = Utilities.DeleteSpaces(phrase.TextPhrase.Trim()); 
			phrase.VerifyFormat(); 
			phraseList.Add(phrase); 
		}

		public bool IsEmpty()
		{
			return phraseList.Count == 0; 
		}
		
		public Phrase[] AllPhrases
		{
			get { return phraseList.ToArray();  }
		}
	}
}
