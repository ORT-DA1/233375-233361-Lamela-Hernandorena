using BusinessLogicExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class EntityPersistence
    {
        public EntityPersistence()
        {

        }


        public bool IsEmpty()
        {
            using (Context ctx = new Context())
            {
                return ctx.Entities.Count() == 0;
            }
        }

        public bool IsContained(Entity entity)
        {
            using (Context ctx = new Context())
            {
                return ctx.Entities.Any(e => !e.IsDeleted && e.EntityName.ToLower().Equals(entity.EntityName.ToLower()));
            }
        }

        public void AddEntity(Entity entity)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    ctx.Entities.Add(entity);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error agregando entidad.", ex);
                }
            }
        }

        public void DeleteEntity(Entity entity)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    var entityOfDb = ctx.Entities.SingleOrDefault(e => e.Id == entity.Id);
                    entityOfDb.IsDeleted = true;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando entidad.", ex);
                }
            }
        }


        public Entity[] AllEntities()
        {
            using (Context ctx = new Context())
            {
                return ctx.Entities.Where(e => !e.IsDeleted).ToArray();
            }
        }

        public void DeleteAll()
        {
            using (Context ctx = new Context())
            {                                     
                try
                {
                    foreach (Entity entity in ctx.Entities.ToList())
                    {
                        ctx.Entities.Remove(entity);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando las entidades", ex);
                }
            }
        }
    }
}
