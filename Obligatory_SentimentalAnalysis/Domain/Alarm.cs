using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Alarm
	{
		public Entity Entity { get; set; }
		public enum Type { Positive, Negative }
		public int QuantityPost { get; set; }
		public int QuantityTime { get; set; }
		public bool Active { get; set; }
		public bool IsInHours { get; set; }
		public Type TypeOfAlarm { get; set; }

		public Alarm()
		{
			Active = false;
		}

		public override bool Equals(object obj)
		{
			Alarm a = (Alarm)obj;
			return Entity.Equals(a.Entity) && QuantityPost.Equals(a.QuantityPost) && QuantityTime.Equals(a.QuantityTime)
			&& IsInHours.Equals(a.IsInHours) && TypeOfAlarm.Equals(a.TypeOfAlarm);
		}





	} 
}
