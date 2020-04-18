using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Entity
	{
		public string EntityName { get; set; }

		public Entity(string name)
		{
			EntityName = name;
		}


		public override bool Equals(object obj)
		{
			Entity entity = (Entity)obj;
			return string.Equals(EntityName, entity.EntityName, StringComparison.OrdinalIgnoreCase); 
		}


	}
}
