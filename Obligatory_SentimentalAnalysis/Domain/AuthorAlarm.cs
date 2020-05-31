using System;
using System.Collections.Generic;
using BusinessLogicExceptions; 

namespace Domain
{
    public class AuthorAlarm : IAlarm
    {
        public enum Type { Positive, Negative }
        public int QuantityPost { get; set; }
        public int QuantityTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsInHours { get; set; }
        public Type TypeOfAlarm { get; set; }

        private List<Author> participantsAuthors;

        public AuthorAlarm()
        {
            participantsAuthors = new List<Author>(); 
        }
        
        public string Show()
        {
            throw new NotImplementedException();
        }

        public Author[] AllAuthorsWhoActiveAlarm
        {
            get { return participantsAuthors.ToArray(); }
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
                    if (phrase.PhraseType.ToString().Equals(TypeOfAlarm.ToString()))
                    {
                        counterPost++;
                        participantsAuthors.Add(phrase.PhraseAuthor);
                    }
                }
            }
            if (counterPost >= QuantityPost)
            {
                IsActive = true;
            }
            else
            {
                participantsAuthors.Clear();
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
    }
}
