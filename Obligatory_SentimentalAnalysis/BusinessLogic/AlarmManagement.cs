using Domain;
using System.Collections.Generic;


namespace BusinessLogic
{
	public class AlarmManagement
	{
		private List<IAlarm> alarmList;

		public AlarmManagement()
		{
			alarmList = new List<IAlarm>(); 
		}

		public void AddAlarm(IAlarm alarm)
		{
			alarm.VerifyFormatAlarm();
			alarmList.Add(alarm); 
		}

		public IAlarm[] AllAlarms
		{
			get { return alarmList.ToArray(); }
		}
	}
}
