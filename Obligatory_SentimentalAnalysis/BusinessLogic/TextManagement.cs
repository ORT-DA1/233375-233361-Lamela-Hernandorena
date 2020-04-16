using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TextManagement
    {

		


		public List<Text> TextList { get; set; }
		

		public TextManagement()
		{
			TextList = new List<Text>(); 
		}



		public void AddText(Text text)
		{
			VerifyFormat(text);
			TextList.Add(text); 
			
		}

		public bool IsEmpty()
		{
			return TextList.Count == 0; 
		}


		private void VerifyFormat(Text text)
		{
			if (String.IsNullOrEmpty(text.Content.Trim()))
			{
				throw new ArgumentNullException();
			}
		}

    }
}
