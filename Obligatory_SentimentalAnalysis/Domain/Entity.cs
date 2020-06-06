using System;
using BusinessLogicExceptions; 


namespace Domain
{
	public class Entity
	{
		public string EntityName { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Entity()
		{
			EntityName = "";
		}

		public override string ToString()
		{
			return EntityName;
		}

		public void VerifyFormat()
		{
			if (String.IsNullOrEmpty(EntityName.Trim()))
			{
				throw new EntityManagementException(MessagesExceptions.ErrorIsEmpty);
			}
		}

		public bool IsEmptyEntity()
		{
			return EntityName.Equals("");  
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
