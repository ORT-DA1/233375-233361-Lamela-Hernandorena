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

		public Entity Entity { get; set;  }

		public enum typePhrase { Positive, Neutral, Negative} 

		public typePhrase TypePhrase { get; set;  }

       

        public Phrase ()
        {
          
        }


		public override bool Equals(object obj)
		{
			Phrase phrase = (Phrase)obj;
			return string.Equals(TextPhrase, phrase.TextPhrase, StringComparison.OrdinalIgnoreCase) && Entity.Equals(phrase.Entity) 
				&& TypePhrase.Equals(phrase.TypePhrase);
		}
	}
}
