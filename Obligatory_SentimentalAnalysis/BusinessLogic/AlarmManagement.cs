using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class AlarmManagement
	{
		List<Alarm> AlarmList { get; set; }

		public AlarmManagement()
		{
			AlarmList = new List<Alarm>(); 
		}

		public void AddAlarm(Alarm alarm)
		{

		}

		public bool IsEmpty()
		{
			return false; 
		}


	}
}
