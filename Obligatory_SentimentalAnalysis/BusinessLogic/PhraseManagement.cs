using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			phrase.TextPhrase = DeleteSpaces(phrase.TextPhrase.Trim()); 
			VerifyFormatAdd(phrase); 
			phraseList.Add(phrase); 
		}

		public bool IsEmpty()
		{
			return phraseList.Count == 0; 
		}


		public void VerifyFormatAdd(Phrase phrase)
		{
			if (String.IsNullOrEmpty(phrase.TextPhrase))
			{
				throw new PhraseManagementException(MessagesExceptions.ERROR_IS_EMPTY); 
			}
            if (phrase.PhraseDate > DateTime.Now)
            {
                throw new PhraseManagementException(MessagesExceptions.ERROR_IS_AFTER_TODAY);
            }
			
			if ((DateTime.Now - phrase.PhraseDate).Days > 365) 
			{
				throw new PhraseManagementException(MessagesExceptions.ERROR_IS_ONE_YEAR_BEFORE); 
			}
		}

		private string DeleteSpaces(string text)
		{
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}
		
		public Phrase[] AllPhrases
		{
			get { return phraseList.ToArray();  }
		}


		public IEnumerable<Phrase> PhraseList
		{
			get { return phraseList; }
		}


	}
}
