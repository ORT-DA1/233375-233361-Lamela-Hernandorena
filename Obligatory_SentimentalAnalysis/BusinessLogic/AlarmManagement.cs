using Domain;
using Persistence;


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

        public void Update(IAlarm alarm)
        {
            alarmPersistence.UpdateAlarms(alarm); 
        }

        public AuthorAlarm GetAuthorAlarm(AuthorAlarm alarm)
        {
            return alarmPersistence.GetAuthorAlarmById(alarm); 
        }

        public EntityAlarm GetEntityAlarm(EntityAlarm alarm)
        {
            return alarmPersistence.GetEntityAlarmById(alarm);
        }


        public IAlarm[] AllAlarms
		{
			get { return alarmPersistence.AllAlarms();  }
		}

        public void DeleteAll()
        {
            alarmPersistence.DeleteAllAuthorsAlarms();
            alarmPersistence.DeleteEntitiesAlarms(); 
        }
	}
}
