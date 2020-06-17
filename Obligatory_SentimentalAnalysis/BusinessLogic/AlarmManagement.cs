using Domain;
using Persistence;
using System.Collections.Generic;


namespace BusinessLogic
{
	public class AlarmManagement
	{
		private AlarmPersistence alarmPersistence;
        
		public AlarmManagement()
		{
            alarmPersistence = new AlarmPersistence();  
		}

		
        
        // Unico metodo de agregar alarma en Persistence,
        //que pregunto por el tipo y ahi mande a la tabla correspondiente.
        public void AddAlarm(IAlarm alarm)
		{
			alarm.VerifyFormat();
            alarmPersistence.AddAlarm(alarm);
            //if (alarm.GetType().Equals(typeof(AuthorAlarm)))
            //{
            //    alarmPersistence.AddAuthorAlarm((AuthorAlarm)alarm);
            //}
            //else
            //{
            //    alarmPersistence.AddSentimentAlarm((Alarm)alarm); 
            //}
		}

        public void Update(IAlarm alarm)
        {
            if (alarm.GetType().BaseType.Equals(typeof(AuthorAlarm)))
            {

                alarmPersistence.UpdateStateOfAuthorAlarm((AuthorAlarm)alarm);
            }
            else
            {
                alarmPersistence.UpdateStateOfSentimentAlarm((Alarm)alarm); 
            }
 
        }

        public AuthorAlarm GetAuthorAlarm(AuthorAlarm alarm)
        {
            return alarmPersistence.GetAuthorAlarmById(alarm); 
        }

        public Alarm GetSentimentAlarm(Alarm alarm)
        {
            return alarmPersistence.GetSentimentAlarmById(alarm);
        }


        public IAlarm[] AllAlarms
		{
			get { return alarmPersistence.AllAlarms();  }
		}

        public void DeleteAll()
        {
            alarmPersistence.DeleteAllAuthorsAlarms();
            alarmPersistence.DeleteSentimentAlarms(); 
        }

        public AuthorAlarm[] AllAuthorAlarms()
        {
            return alarmPersistence.AllAuthorAlarms();
        }
	}
}
