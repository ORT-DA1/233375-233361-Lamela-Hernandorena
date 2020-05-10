using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Entity
	{
		public string EntityName { get; set; }

		public Entity()
		{
			EntityName = "";
		}

		private string DeleteSpaces(string text)
		{
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}

		public override string ToString()
		{
			return EntityName;
		}


		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else if (this.GetType() != obj.GetType())
			{
				return false;
			}
			else
			{
				Entity entity = (Entity)obj;
				return string.Equals(DeleteSpaces(EntityName.Trim()), DeleteSpaces(entity.EntityName.Trim()), StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}
