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
			PhraseList.Add(phrase); 
		}

		public bool IsEmpty()
		{
			return PhraseList.Count == 0; 
		}


	}
}
