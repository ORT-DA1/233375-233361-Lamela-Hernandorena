using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Phrase
	{
		public string TextPhrase { get; set; }

        public DateTime PhraseDate { get; set; }



        public Phrase(string phrase)
		{
			TextPhrase = phrase; 
		}

        public Phrase (string phrase, DateTime date)
        {
            TextPhrase = phrase;
            PhraseDate = date;
        }
	}
}
