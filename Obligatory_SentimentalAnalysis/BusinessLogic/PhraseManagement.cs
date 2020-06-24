using Domain;
using Persistence;


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

		public void DeleteAllPhrases()
		{
			phrasePersistence.DeleteAll();
		}

        public void UpdatePhrase(Phrase phrase)
        {
            phrasePersistence.Update(phrase); 
        }
    }
}
	
