using BusinessLogicExceptions;
using Domain;
using System;
using System.Linq;

namespace Persistence
{
    public class EntityPersistence
    {
        public EntityPersistence()
        {

        }

        public bool IsEmpty()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Entities.Count() == 0;
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error verificando si no hay entidades.", ex);
            }
        }

        public bool IsContained(Entity entity)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Entities.Any(e => !e.IsDeleted && e.EntityName.ToLower().Equals(entity.EntityName.ToLower()));
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error verificando si la entidad esta contenida.", ex);
            }

        }

        public void AddEntity(Entity entity)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Entities.Add(entity);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error agregando entidad.", ex);
            }
        }

        public void DeleteEntity(Entity entity)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var entityOfDb = ctx.Entities.SingleOrDefault(e => e.Id == entity.Id);
                    entityOfDb.IsDeleted = true;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando entidad.", ex);
            }
        }


        public Entity[] AllEntities()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Entities.Where(e => !e.IsDeleted).ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo entidades.", ex);
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    foreach (Entity entity in ctx.Entities.ToList())
                    {
                        ctx.Entities.Remove(entity);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando las entidades.", ex);
            }
        }
    }
}
