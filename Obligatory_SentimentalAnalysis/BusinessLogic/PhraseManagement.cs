using BusinessLogicExceptions;
using Domain;
using System;
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
			VerifyFormatAdd(phrase); 
			phraseList.Add(phrase); 
		}

		public bool IsEmpty()
		{
			return phraseList.Count == 0; 
		}

		private void VerifyFormatAdd(Phrase phrase)
		{
			const int DaysOfTheYear = 365; 
			if (String.IsNullOrEmpty(phrase.TextPhrase))
			{
				throw new PhraseManagementException(MessagesExceptions.ERROR_IS_EMPTY); 
			}
            if (phrase.PhraseDate > DateTime.Now)
            {
                throw new PhraseManagementException(MessagesExceptions.ERROR_IS_AFTER_TODAY);
            }
			
			if ((DateTime.Now - phrase.PhraseDate).Days > DaysOfTheYear) 
			{
				throw new PhraseManagementException(MessagesExceptions.ERROR_IS_ONE_YEAR_BEFORE); 
			}
		}
		
		public Phrase[] AllPhrases
		{
			get { return phraseList.ToArray();  }
		}
	}
}
