
using BusinessLogicExceptions;
using Domain;
using System;

namespace BusinessLogic
{
	public class Alarm:IAlarm
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

		public void UpdateState(Phrase[] phrases, DateTime date)
		{
			int counterPost = 0;
			DateTime minDate = date;
			foreach (Phrase p in phrases)
			{
				minDate = DeterminateMinDate(date);
				if (p.PhraseDate >= minDate)
				{
					if (p.Entity.Equals(Entity) && p.PhraseType.ToString().Equals(TypeOfAlarm.ToString()))
					{
						counterPost++;
					}
				}
			}
			if (counterPost >= QuantityPost)
			{
				Active = true;
			}
		}

		public string Show()
		{
			string state = "";
			if (Active)
			{
				state = "activa";
			}
			else
			{
				state = "inactiva";
			}
			return "Alarma con entidad asociada: " + Entity.ToString() + ", con tipo: "  + TranslateTypeOfAlarm() + " y estado: " + state;
		}

		private string TranslateTypeOfAlarm()
		{
			if (TypeOfAlarm.ToString().Equals("Positive"))
			{
				return "positiva";
			}
			else
			{
				return "negativa";
			}
		}

		private DateTime DeterminateMinDate(DateTime date)
		{
			DateTime minDate = date;
			if (IsInHours)
			{
				minDate = date.AddHours(-QuantityTime);
			}
			else
			{
				minDate = date.AddDays(-QuantityTime);
			}
			return minDate;
		}

		public void VerifyFormatAlarm()
		{
			if (Utilities.IsNegativeQuantity(QuantityPost))
			{
				throw new AlarmManagementException(MessagesExceptions.ErrorIsNegativePosts);
			}
			if (string.IsNullOrEmpty(Entity.EntityName)) 
			{
				throw new AlarmManagementException(MessagesExceptions.ErrorIsNull);
			}

			if (Utilities.IsNegativeQuantity(QuantityTime))
			{
				throw new AlarmManagementException(MessagesExceptions.ErrorIsNegativeTime);
			}
		}
	} 
}
