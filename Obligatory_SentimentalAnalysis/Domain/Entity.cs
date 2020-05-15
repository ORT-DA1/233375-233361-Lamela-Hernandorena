using System;
using Domain; 


namespace Domain
{
	public class Entity
	{
		public string EntityName { get; set; }

		public Entity()
		{
			EntityName = "";
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
				return string.Equals(Utilities.DeleteSpaces(EntityName.Trim()), 
					Utilities.DeleteSpaces(entity.EntityName.Trim()), 
					StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}
