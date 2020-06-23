using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain
{
    [Table("Authors_Table")]
    public class Author
    {
        [Required]
        [MaxLength(10)]
        [MinLength(1)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<AuthorAlarm> AlarmsWhoAuthorParticipate { get; set; }

        public virtual List<Phrase> ListOfPhraseOfAuthor { get; set; }

        public Author()
        {
            UserName = "";
            AlarmsWhoAuthorParticipate = new List<AuthorAlarm>();
            ListOfPhraseOfAuthor = new List<Phrase>();
        }

        public double PositivePercentagePhrases()
        {
            double percentage = 0;
            if (ListOfPhraseOfAuthor.Count > 0)
            {
                double totalFindPhrases = 0;
                foreach (Phrase phrase in ListOfPhraseOfAuthor)
                {
                    if (phrase.PhraseType.Equals(Phrase.TypePhrase.Positive))
                    {
                        totalFindPhrases++;
                    }
                }
                percentage = Math.Round(totalFindPhrases / (double)ListOfPhraseOfAuthor.Count, 2);
            }
            return percentage;
        }

        public double NegativePercentagePhrases()
        {
            double totalFindPhrases = 0;
            double percentage = 0;
            if (ListOfPhraseOfAuthor.Count > 0)
            {
                foreach (Phrase phrase in ListOfPhraseOfAuthor)
                {
                    if (phrase.PhraseType.Equals(Phrase.TypePhrase.Negative))
                    {
                        totalFindPhrases++;
                    }
                }
                percentage = Math.Round(totalFindPhrases / (double)ListOfPhraseOfAuthor.Count,2);
            }
            return percentage;

        }

        public int QuantityOfEntityMentioned()
        {
            List<Entity> listOfEntityMentioned = new List<Entity>();

            foreach (Phrase phrase in ListOfPhraseOfAuthor)
            {
                if (phrase.Entity != null)
                {
                    if (!phrase.PhraseType.Equals(Phrase.TypePhrase.Neutral) && !listOfEntityMentioned.Contains(phrase.Entity))
                    {
                        listOfEntityMentioned.Add(phrase.Entity);
                    }
                }
            }

            return listOfEntityMentioned.Count;
        }

        public double AverageOfDailyPhrases(DateTime actualDate)
        {
            double averageDailyPhrases = 0;
            if (ListOfPhraseOfAuthor.Count > 0)
            {
                List<Phrase> phrasesOfAuthor = ListOfPhraseOfAuthor.OrderBy(list => list.PhraseDate).ToList();
                DateTime dateOfTheFirstPhrase = phrasesOfAuthor.ElementAt(0).PhraseDate;
                double quantityOfPhrases = ListOfPhraseOfAuthor.Count;

                double differenceOfTime = (actualDate - dateOfTheFirstPhrase).TotalDays;

                if (differenceOfTime < 1)
                {
                    averageDailyPhrases= quantityOfPhrases;
                }
                else
                {
                    averageDailyPhrases =  Math.Round(quantityOfPhrases / Math.Floor(differenceOfTime), 2);
                }
            }
            return averageDailyPhrases;
        }

        
        public void VerifyFormat()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                throw new AuthorException(MessagesExceptions.ErrorIsEmpty);
            }
            if (UserName.Length > 10)
            {
                throw new AuthorException(MessagesExceptions.ErrorLengthUserName);
            }
            if (Name.Length > 15 || LastName.Length > 15)
            {
                throw new AuthorException(MessagesExceptions.ErrorLengthNameOrLastName);
            }
            if (string.IsNullOrEmpty(Name))
            {
                throw new AuthorException(MessagesExceptions.ErrorIsEmpty);
            }
            if (string.IsNullOrEmpty(LastName))
            {
                throw new AuthorException(MessagesExceptions.ErrorIsEmpty);
            }
            if (CalculateAge() < 13 || CalculateAge() > 100)
            {
                throw new AuthorException(MessagesExceptions.ErrorAge);
            }

        }

        public int CalculateAge()
        {
            DateTime actualDate = DateTime.Today;
            int age = actualDate.Year - BirthDate.Year;
            if (BirthDate.Month > actualDate.Month)
            {
                --age;
            }
            return age;
        }


        public override string ToString()
        {
            return " Usuario: " + UserName + " con nombre: " + Name;
        }

        public override bool Equals(object obj)
        {
            Author author = obj as Author;

            if (author == null || Convert.IsDBNull(author))
            {
                return false;
            }
            return Utilities.DeleteSpaces(UserName.Trim()).Equals(Utilities.DeleteSpaces(author.UserName.Trim()));
        }
    }
}
