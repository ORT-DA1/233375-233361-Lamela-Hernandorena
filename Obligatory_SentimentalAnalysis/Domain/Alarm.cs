using BusinessLogicExceptions;
using System;

namespace Domain
{
	public class Alarm : IAlarm
	{
		public Entity Entity { get; set; }
		public enum Type { Positive, Negative }
		public int QuantityPost { get; set; }
		public int QuantityTime { get; set; }
		public bool IsActive { get; set; }
		public bool IsInHours { get; set; }
		public Type TypeOfAlarm { get; set; }
        public int Id { get; set; }
        public Alarm()
		{
			IsActive = false;
		}

		public void UpdateState(Phrase[] phrases, DateTime date)
		{
			int counterPost = 0;
			IsActive = false; 
			DateTime minDate = date;
			foreach (Phrase phrase in phrases)
			{
				minDate = DeterminateMinDate(date);
				if (phrase.PhraseDate >= minDate)
				{
					if (phrase.Entity.Equals(Entity) && phrase.PhraseType.ToString().Equals(TypeOfAlarm.ToString()))
					{
						counterPost++;
					}
				}
			}
			if (counterPost >= QuantityPost)
			{
				IsActive = true;
			}
		}

		public string Show()
		{
			string state = "";
			if (IsActive)
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

		public void VerifyFormat()
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
