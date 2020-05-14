using BusinessLogicExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				throw new AlarmManagementException(MessagesExceptions.ErrorIsNegativePosts); 
			}

			if (ExistAlarm(alarm))
			{
				throw new AlarmManagementException(MessagesExceptions.ErrorIsContained); 
			}

			if (AlarmEntityIsNull(alarm))
            {
                throw new AlarmManagementException(MessagesExceptions.ErrorIsNull); 
            }

            if (Utilities.IsNegativeQuantity(alarm.QuantityTime))
            {
                throw new AlarmManagementException(MessagesExceptions.ErrorIsNegativeTime); 
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
