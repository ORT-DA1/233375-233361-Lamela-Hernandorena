﻿using Domain;
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

		
        public void AddAlarm(IAlarm alarm)
		{
			alarm.VerifyFormat();
            alarmPersistence.AddAlarm(alarm);
		}

        //Poner un solo metodo
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
	}
}
