using Domain;
using Persistence;
using System.Collections.Generic;


namespace BusinessLogic
{
	public class PhraseManagement
	{
		private PhrasePersistence phrasePersistence;

		public PhraseManagement()
		{
			phrasePersistence = new PhrasePersistence();
		}

		public void AddPhrase(Phrase phrase)
		{
			phrase.TextPhrase = Utilities.DeleteSpaces(phrase.TextPhrase.Trim()); 
			phrase.VerifyFormat(); 
			phrasePersistence.AddPhrase(phrase);
		}
        

        public void DeletePhrasesOfAuthor(Author author)
        {
			phrasePersistence.DeletePhrasesOfAuthor(author);         
        }
		
		public Phrase[] AllPhrases
		{
			get { return phrasePersistence.AllPhrases(); }
		}

		public void EmptyPhrase()
		{
			phrasePersistence.DeleteAll();
		}
	}
}
	
