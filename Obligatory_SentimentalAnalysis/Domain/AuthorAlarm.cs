using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BusinessLogicExceptions; 

namespace Domain
{
    [Table("Authors_Alarms_Table")]
    public class AuthorAlarm : IAlarm
    {
        public enum TypeOfNewAlarm { Positive, Negative }

        [Required]
        public int QuantityPost { get; set; }

        [Required]
        public int QuantityTime { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public bool IsInHours { get; set; }

        [Required]
        public TypeOfNewAlarm TypeOfAlarm { get; set; }

        [Key]
        public int Id { get; set; }
        
        public virtual List<Author> ParticipantsAuthors { get; set; } 

        public AuthorAlarm()
        {
            ParticipantsAuthors = new List<Author>(); 
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

            string returnText = "Alarma de tipo: " + TranslateTypeOfAlarm() + " con estado: " + state;
            if (IsActive)
            {
                returnText = returnText + " con los autores: ";
                foreach (Author author in ParticipantsAuthors)
                {
                    returnText = returnText + " " + author.UserName + " ";
                }
            }
            return returnText;
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
        

        public void UpdateState(Phrase[] phrases, DateTime date)
        {
            ParticipantsAuthors.Clear();
            IsActive = false;
            DateTime minDate = date;
            Author[] participants = new Author[phrases.Length];
            int[] quantity = new int[phrases.Length];
            for (int i=0; i < participants.Length; i++)
            {
                participants[i] = new Author();
            }
            int index = 0;
            foreach (Phrase phrase in phrases)
            {
                minDate = DeterminateMinDate(date);
                if (phrase.PhraseDate >= minDate)
                {
                    if (phrase.PhraseType.ToString().Equals(TypeOfAlarm.ToString()))
                    {
                        int currentIndex = Array.FindIndex(participants, p => p.Equals(phrase.PhraseAuthor));
                        if (currentIndex == -1)
                        {
                            participants[index] = phrase.PhraseAuthor;
                            quantity[index]++;
                        }
                        else
                        {
                            quantity[currentIndex]++;
                        }
                        index++;
                    }
                }
            }
            for(int i=0; i<quantity.Length; i++)
            {
                if(quantity[i] >= QuantityPost)
                {
                    ParticipantsAuthors.Add(participants[i]);
                    IsActive = true;
                }
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
            if (QuantityPost >= 1000)
            {
                throw new AlarmManagementException(MessagesExceptions.ErrorIsNegativePosts);
            }
            if (Utilities.IsNegativeQuantity(QuantityTime))
            {
                throw new AlarmManagementException(MessagesExceptions.ErrorIsNegativeTime);
            }
        }

        public override bool Equals(Object obj)
        {
            AuthorAlarm authorAlarm = obj as AuthorAlarm;

            if (authorAlarm == null || Convert.IsDBNull(authorAlarm))
            {
                return false;
            }

            bool ret= QuantityPost == authorAlarm.QuantityPost && QuantityTime==authorAlarm.QuantityTime 
                && ParticipantsAuthors.SequenceEqual(authorAlarm.ParticipantsAuthors) 
                && TypeOfAlarm.Equals(authorAlarm.TypeOfAlarm);
            return ret;
        }
    }
}
