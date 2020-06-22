using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            using (Context ctx = new Context())
            {
                try
                {
                    if (alarm.GetType().Equals(typeof(AuthorAlarm)))
                    {
                        ctx.AuthorAlarms.Add((AuthorAlarm)alarm);
                    }
                    else
                    {

                        Alarm sentimentAlarm = (Alarm)alarm;
                        ctx.SentimentAlarms.Add(sentimentAlarm);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new AlarmManagementException("Error agregando alarma.", ex);
                }
            }
        }


        public void UpdateStateOfAuthorAlarm(AuthorAlarm alarm)
        {
            using (Context ctx = new Context())
            {
                try
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
                catch (Exception ex)
                {
                    throw new AlarmManagementException("Error actualizando alarma.", ex);
                }
            }
        }

        public void UpdateStateOfSentimentAlarm(Alarm alarm)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    var alarmOfSentiment = ctx.SentimentAlarms.SingleOrDefault(a => a.Id == alarm.Id);
                    alarmOfSentiment.IsActive = alarm.IsActive;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new AlarmManagementException("Error actualizando alarma.", ex);
                }
            }
        }

        public IAlarm[] AllAlarms()
        {
            using (Context ctx = new Context())
            {
                AuthorAlarm[] allAuthorsAlarms = ctx.AuthorAlarms.Include("ParticipantsAuthors").ToArray();
                Alarm[] allSentimentAlarm = ctx.SentimentAlarms.Include("Entity").ToArray();
                IAlarm[] union = new IAlarm[allSentimentAlarm.Length + allAuthorsAlarms.Length];
                allSentimentAlarm.CopyTo(union, 0);
                allAuthorsAlarms.CopyTo(union, allSentimentAlarm.Length);
                return union;
            }
        }

        

        public AuthorAlarm GetAuthorAlarmById(AuthorAlarm alarm)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    return ctx.AuthorAlarms.Include("ParticipantsAuthors").SingleOrDefault(a => a.Id == alarm.Id);
                }
                catch (Exception ex)
                {
                    throw new AlarmManagementException("Error obteniendo alarma.", ex);
                }
            }
        }

        public Alarm GetSentimentAlarmById(Alarm alarm)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    return ctx.SentimentAlarms.Include("Entity").SingleOrDefault(a => a.Id == alarm.Id);
                }
                catch (Exception ex)
                {
                    throw new AlarmManagementException("Error obteniendo alarma.", ex);
                }
            }
        }

        public void DeleteAllAuthorsAlarms()
        {
            using (Context ctx = new Context())
            {
                try
                {
                    foreach (AuthorAlarm authorAlarm in ctx.AuthorAlarms.ToList())
                    {
                        ctx.AuthorAlarms.Remove(authorAlarm);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando las alarmas de autor", ex);
                }
            }
        }

        public void DeleteSentimentAlarms()
        {
            using (Context ctx = new Context())
            {
                try
                {
                    foreach (Alarm sentimentAlarm in ctx.SentimentAlarms.ToList())
                    {
                        ctx.SentimentAlarms.Remove(sentimentAlarm);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando las alarmas de sentimiento", ex);
                }
            }
        }
    }
}
