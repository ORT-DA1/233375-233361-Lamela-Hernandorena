using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogicExceptions; 


namespace Domain
{
    [Table("Entities_Table")]
	public class Entity
	{
        [Required]
		public string EntityName { get; set; }

        [Key]
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
            Entity entity = obj as Entity;

            if (entity == null || Convert.IsDBNull(entity))
            {
                return false;
            }

            return string.Equals(Utilities.DeleteSpaces(EntityName.Trim()), 
					Utilities.DeleteSpaces(entity.EntityName.Trim()), 
					StringComparison.OrdinalIgnoreCase);
			
		}
	}
}
