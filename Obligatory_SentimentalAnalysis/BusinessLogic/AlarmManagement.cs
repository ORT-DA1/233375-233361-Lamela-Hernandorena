using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class AlarmManagement
	{
		public List<Alarm> AlarmList { get; set; }

		public AlarmManagement()
		{
			AlarmList = new List<Alarm>(); 
		}

		public void AddAlarm(Alarm alarm, double placedTime, bool isDay)
		{
			ModifyQuantityTime(alarm, placedTime, isDay);
			VerifyFormatAlarm(alarm, placedTime);
			AlarmList.Add(alarm); 
		}


		public bool IsEmpty()
		{
			return AlarmList.Count == 0; 
		}

		public void VerifyFormatAlarm(Alarm alarm, double timeAdded)
		{
			if (IsNegativeQuantity(alarm.QuantityPost))
			{
				throw new AlarmManagementException(MessagesExceptions.ERROR_IS_NEGATIVE); 
			}

			if (ExistAlarm(alarm))
			{
				throw new AlarmManagementException(MessagesExceptions.ERROR_IS_CONTAINED); 
			}

			
		}



		private bool ExistAlarm(Alarm alarm)
		{
			return AlarmList.Contains(alarm); 
		}

		private bool IsNegativeQuantity(double quantity)
		{
			return quantity <= 0; 
		}

		private void ModifyQuantityTime(Alarm alarm, double placedTime, bool isDay)
		{
			if (isDay)
			{
				alarm.QuantityTime = alarm.QuantityTime.AddDays(placedTime);  
			}
			else
			{
				alarm.QuantityTime= alarm.QuantityTime.AddHours(placedTime); 
			}
		}



	}
}
