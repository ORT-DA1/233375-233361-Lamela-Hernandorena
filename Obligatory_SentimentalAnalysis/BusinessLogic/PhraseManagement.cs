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
		public List<Phrase> PhraseList { get; set;  }


		public PhraseManagement()
		{
			PhraseList = new List<Phrase>(); 
		}


		public void AddPhrase(Phrase phrase)
		{
			phrase.TextPhrase = DeleteSpaces(phrase.TextPhrase.Trim()); 
			VerifyFormatAdd(phrase); 
			PhraseList.Add(phrase); 
		}

		public bool IsEmpty()
		{
			return PhraseList.Count == 0; 
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
		}

		private string DeleteSpaces(string text)
		{
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}





	}
}
