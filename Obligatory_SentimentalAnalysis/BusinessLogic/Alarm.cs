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
		public string Type { get; set; }
		public int QuantityPost { get; set; }
		public DateTime QuantityTime { get; set; }
		public bool State { get; set; }

		public Alarm(Entity entity, string type, int quantityPost, DateTime quantityTime)
		{
			Entity = entity;
			Type = type;
			QuantityPost = quantityPost;
			QuantityTime = quantityTime; 
		}


	}
}
