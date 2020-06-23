using BusinessLogicExceptions;
using Domain;
using Persistence;


namespace BusinessLogic
{
	public class EntityManagement
	{
        private EntityPersistence entityPersistence;

        public EntityManagement()
		{
            entityPersistence = new EntityPersistence();
        }

		public bool IsEmpty()
		{
            return entityPersistence.IsEmpty();
        }

		public void AddEntity(Entity entity)
		{
			entity.EntityName = Utilities.DeleteSpaces(entity.EntityName.Trim());
			entity.VerifyFormat(); 
			VerifyFormatAdd(entity);
            entityPersistence.AddEntity(entity);
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
            return entityPersistence.IsContained(entity);
        }

		public void DeleteEntity(Entity entity)
		{
			VerifyFormatDelete(entity);
            entityPersistence.DeleteEntity(entity);
        }

		public void AssociateEntityToPhrase(Phrase phrase)
		{
			phrase.AssociateEntity(AllEntities);
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
            get { return entityPersistence.AllEntities(); }
        }
 
        public void DeleteAllEntities()
        {
            entityPersistence.DeleteAll();
        }
    }
}
