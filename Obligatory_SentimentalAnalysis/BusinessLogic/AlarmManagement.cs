using BusinessLogicExceptions;
using Domain;
using System.Collections.Generic;


namespace BusinessLogic
{
	public class AlarmManagement
	{
		private List<Alarm> alarmList;

		public AlarmManagement()
		{
			alarmList = new List<Alarm>(); 
		}

		public void AddAlarm(Alarm alarm)
		{
			VerifyFormatAlarm(alarm);
			alarmList.Add(alarm); 
		}

		private void VerifyFormatAlarm(Alarm alarm)
		{
			if (Utilities.IsNegativeQuantity(alarm.QuantityPost))
			{
				throw new AlarmManagementException(MessagesExceptions.ERROR_IS_NEGATIVE_POSTS); 
			}

			if (ExistAlarm(alarm))
			{
				throw new AlarmManagementException(MessagesExceptions.ERROR_IS_CONTAINED); 
			}

			if (AlarmEntityIsNull(alarm))
            {
                throw new AlarmManagementException(MessagesExceptions.ERROR_IS_NULL); 
            }

            if (Utilities.IsNegativeQuantity(alarm.QuantityTime))
            {
                throw new AlarmManagementException(MessagesExceptions.ERROR_IS_NEGATIVE_TIME); 
            }
		}

		private bool AlarmEntityIsNull(Alarm alarm)
		{
			return alarm.Entity == null;
		}

		private bool ExistAlarm(Alarm alarm)
		{
			return alarmList.Contains(alarm); 
		}

		public Alarm[] AllAlarms
		{
			get { return alarmList.ToArray(); }
		}
	}
}
