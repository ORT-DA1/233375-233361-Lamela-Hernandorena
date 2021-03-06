﻿using BusinessLogicExceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Sentiments_Alarms_Table")]
    public class EntityAlarm : IAlarm
    {
        [Required]
        public virtual Entity Entity { get; set; }

        public enum Type { Positive, Negative }

        [Required]
        public int QuantityPost { get; set; }

        [Required]
        public int QuantityTime { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public bool IsInHours { get; set; }

        [Required]
        public Type TypeOfAlarm { get; set; }

        [Key]
        public int Id { get; set; }

        public EntityAlarm()
        {
            IsActive = false;
        }

        public void UpdateState(Phrase[] phrases, DateTime date)
        {
            int counterPost = 0;
            IsActive = false;
            DateTime minDate = DeterminateMinDate(date); ;
            foreach (Phrase phrase in phrases)
            {
                if (phrase.Entity != null)
                {
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
            return "Alarma con entidad asociada: " + Entity.ToString() + ", con tipo: " 
                + TranslateTypeOfAlarm() + " y estado: " + state;
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

        public override bool Equals(Object obj)
        {
            EntityAlarm sentimentAlarm = obj as EntityAlarm;

            if (sentimentAlarm == null || Convert.IsDBNull(sentimentAlarm))
            {
                return false;
            }

            return QuantityPost == sentimentAlarm.QuantityPost && QuantityTime == sentimentAlarm.QuantityTime
                && Entity.Equals(sentimentAlarm.Entity)
                && TypeOfAlarm.Equals(sentimentAlarm.TypeOfAlarm);
        }


    }
}
