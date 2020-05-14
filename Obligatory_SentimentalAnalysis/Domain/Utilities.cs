using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Utilities
	{
<<<<<<< Updated upstream:Obligatory_SentimentalAnalysis/Domain/Utilities.cs
		public static bool IsNegativeQuantity(double quantity)
		{
			return quantity <= 0;
=======
		public string EntityName { get; set; }

		public Entity()
		{
			EntityName = "";
>>>>>>> Stashed changes:Obligatory_SentimentalAnalysis/BusinessLogic/Entity.cs
		}

		public static string DeleteSpaces(string text)
		{
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}

	}
}
