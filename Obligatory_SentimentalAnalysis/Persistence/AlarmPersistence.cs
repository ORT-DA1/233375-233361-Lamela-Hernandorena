using System;
using System.Linq;
using BusinessLogicExceptions;
using Domain;

namespace Persistence
{
    public class AlarmPersistence
    {
        public AlarmPersistence()
        {

        }
        
        public void AddAlarm(IAlarm alarm)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    if (alarm.GetType().Equals(typeof(AuthorAlarm)))
                    {
                        ctx.AuthorAlarms.Add((AuthorAlarm)alarm);
                    }
                    else
                    {
                        EntityAlarm sentimentAlarm = (EntityAlarm)alarm;
                        ctx.SentimentAlarms.Add(sentimentAlarm);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error agregando alarma.", ex);
            }
        }


        public void UpdateAlarms(IAlarm alarm)
        {
            if (alarm.GetType().BaseType.Equals(typeof(AuthorAlarm)))
            {
                UpdateStateOfAuthorAlarm((AuthorAlarm)alarm);
            }
            else
            {
                UpdateStateOfEntityAlarm((EntityAlarm)alarm);
            }
        }


        private void UpdateStateOfAuthorAlarm(AuthorAlarm alarm)
        {
            try
            {
                using (Context ctx = new Context())
                {

                    AuthorAlarm alarmOfDB = ctx.AuthorAlarms.SingleOrDefault(a => a.Id == alarm.Id);
                    Author authorOfDB;
                    alarmOfDB.ParticipantsAuthors.Clear();

                    foreach (Author currentAuthor in alarm.ParticipantsAuthors)
                    {
                        authorOfDB = ctx.Authors.SingleOrDefault(author => author.Id == currentAuthor.Id &&
                        !currentAuthor.IsDeleted);
                        alarmOfDB.ParticipantsAuthors.Add(authorOfDB);
                    }
                    alarmOfDB.IsActive = alarm.IsActive;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error actualizando alarma.", ex);
            }
        }

        private void UpdateStateOfEntityAlarm(EntityAlarm alarm)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var alarmOfSentiment = ctx.SentimentAlarms.SingleOrDefault(a => a.Id == alarm.Id);
                    alarmOfSentiment.IsActive = alarm.IsActive;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error actualizando alarma.", ex);
            }
        }

        public IAlarm[] AllAlarms()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    AuthorAlarm[] allAuthorsAlarms = ctx.AuthorAlarms.Include("ParticipantsAuthors").ToArray();
                    EntityAlarm[] allEntitiesAlarms = ctx.SentimentAlarms.Include("Entity").ToArray();
                    IAlarm[] union = new IAlarm[allEntitiesAlarms.Length + allAuthorsAlarms.Length];
                    allEntitiesAlarms.CopyTo(union, 0);
                    allAuthorsAlarms.CopyTo(union, allEntitiesAlarms.Length);
                    return union;
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo todas las alarmas.", ex);
            }
        }

        public AuthorAlarm GetAuthorAlarmById(AuthorAlarm alarm)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.AuthorAlarms.Include("ParticipantsAuthors").SingleOrDefault(a => a.Id == alarm.Id);
                }

            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo alarma.", ex);
            }
        }

        public EntityAlarm GetEntityAlarmById(EntityAlarm alarm)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.SentimentAlarms.Include("Entity").SingleOrDefault(a => a.Id == alarm.Id);
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo alarma.", ex);
            }
        }

        public void DeleteAllAuthorsAlarms()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    foreach (AuthorAlarm authorAlarm in ctx.AuthorAlarms.ToList())
                    {
                        ctx.AuthorAlarms.Remove(authorAlarm);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando las alarmas de autor", ex);
            }
        }

        public void DeleteEntitiesAlarms()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    foreach (EntityAlarm sentimentAlarm in ctx.SentimentAlarms.ToList())
                    {
                        ctx.SentimentAlarms.Remove(sentimentAlarm);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando las alarmas de sentimiento", ex);
            }
        }
    }
}
