using BusinessLogicExceptions;
using Domain;
using System.Collections.Generic;


namespace BusinessLogic
{
	public class EntityManagement
	{
		private List<Entity> entityList;

		public EntityManagement()
		{
			entityList = new List<Entity>(); 
		}

		public bool IsEmpty()
		{
			return entityList.Count == 0; 
		}


		public void AddEntity(Entity entity)
		{
			entity.EntityName = Utilities.DeleteSpaces(entity.EntityName.Trim());
			entity.VerifyFormat(); 
			VerifyFormatAdd(entity);
			entityList.Add(entity); 
		}

		private void VerifyFormatAdd(Entity entity)
		{
			if (IsContained(entity))
			{
				throw new EntityManagementException(MessagesExceptions.ErrorIsContained);
			}
		}

		private bool IsContained(Entity entity)
		{
			return entityList.Contains(entity); 
		}

		public void DeleteEntity(Entity entity)
		{
			VerifyFormatDelete(entity);
			entityList.Remove(entity);
		}

		private void VerifyFormatDelete(Entity entity)
		{
			if (!IsContained(entity))
			{
				throw new EntityManagementException(MessagesExceptions.ErrorDontExist);
			}
		}

		public Entity [] AllEntities
		{
			get { return entityList.ToArray(); }
		}
	}
}
