using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class EntityManagement
	{
		public List<Entity> EntityList{ get; set;  }

		public EntityManagement()
		{
			EntityList = new List<Entity>(); 
		}

		public bool IsEmpty()
		{
			return EntityList.Count == 0; 
		}


		public void AddEntity(Entity entity)
		{
			VerifyFormatAdd(entity); 
			entity.EntityName = DeleteSpaces(entity.EntityName.Trim()); 
			EntityList.Add(entity); 
		}



		private string DeleteSpaces(string text)
		{
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

			return text;
		}


		private void VerifyFormatAdd(Entity entity)
		{
				if (String.IsNullOrEmpty(entity.EntityName.Trim()))
				{
					throw new EntityManagementException(MessagesExceptions.ERROR_IS_EMPTY);
				}

				if (IsContained(entity))
				{
					throw new EntityManagementException(MessagesExceptions.ERROR_IS_CONTAINED);
				}

		}


		private bool IsContained(Entity entity)
		{
			return EntityList.Contains(entity); 
		}




		public void DeleteEntity(Entity entity)
		{
			VerifyFormatDelete(entity);
			EntityList.Remove(entity);
		}


		private void VerifyFormatDelete(Entity entity)
		{
			if (!IsContained(entity))
			{
				throw new EntityManagementException(MessagesExceptions.ERROR_DONT_EXIST);
			}
		}


	









	}
}
