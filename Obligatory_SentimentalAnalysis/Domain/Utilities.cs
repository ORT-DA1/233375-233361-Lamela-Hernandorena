

namespace Domain
{
	public class Utilities
	{
		public static bool IsNegativeQuantity(double quantity)
		{
			return quantity <= 0;
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
