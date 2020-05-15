using System;


namespace BusinessLogic
{
	public class Phrase
	{
		public string TextPhrase { get; set; }

        public DateTime PhraseDate { get; set; }

		public Entity Entity { get; set;  }

		public enum TypePhrase { Positive, Neutral, Negative} 

		public TypePhrase PhraseType { get; set;  }

       
        public Phrase ()
        {
          
        }


		public override bool Equals(object obj)
		{
			if(obj == null)
			{
				return false;
			}
			else
			{
				if(GetType() != obj.GetType())
				{
					return false;
				}
				else
				{
					Phrase phrase = (Phrase)obj;
					return string.Equals(TextPhrase, phrase.TextPhrase, StringComparison.OrdinalIgnoreCase) && Entity.Equals(phrase.Entity)
						&& PhraseType.Equals(phrase.PhraseType);
				}
			}
		}
	}
}
