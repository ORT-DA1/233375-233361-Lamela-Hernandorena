﻿using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public double GeneratePhrasesPercetageReportPositive()
        {
            double totalFindPhrases = 0;
            foreach (Phrase phrase in ListOfPhraseOfAuthor)
            {
                if (phrase.PhraseType.Equals(Phrase.TypePhrase.Positive))
                {
                    totalFindPhrases++;
                }
            }
            
            return totalFindPhrases / (double)ListOfPhraseOfAuthor.Count;
        }

        public double GeneratePhrasesPercetageReportNegative()
        {
            double totalFindPhrases = 0;
            foreach (Phrase phrase in ListOfPhraseOfAuthor)
            {
                if (phrase.PhraseType.Equals(Phrase.TypePhrase.Negative))
                {
                    totalFindPhrases++;
                }
            }

            return totalFindPhrases / (double)ListOfPhraseOfAuthor.Count;
        }

        public int QuantityOfEntityMentioned()
        {
            List<Entity> listOfEntityMentioned = new List<Entity>(); 

            foreach (Phrase phrase in ListOfPhraseOfAuthor)
            {
                if(!(phrase.PhraseType.Equals(Phrase.TypePhrase.Neutral) || listOfEntityMentioned.Contains(phrase.Entity)))
                {
                    listOfEntityMentioned.Add(phrase.Entity); 
                }
            }

            return listOfEntityMentioned.Count;
        }

        public double AverageOfDailyPhrases()
        {
            DateTime dateOfTheFirstPhrase = ListOfPhraseOfAuthor.ElementAt(0).PhraseDate;
            DateTime timeOfNow = DateTime.Now;
            double quantityOfPhrases = ListOfPhraseOfAuthor.Count;

            double differenceOfTime = (timeOfNow - dateOfTheFirstPhrase).TotalDays;

            if (differenceOfTime <= 1)
            {
                return quantityOfPhrases; 
            }
            else
            {
                return quantityOfPhrases / Math.Floor(differenceOfTime);
            }
            
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
            if (CalculateAge(BirthDate) < 13 || CalculateAge(BirthDate) > 100)
            {
                throw new AuthorException(MessagesExceptions.ErrorAge);
            }

        }

        public static int CalculateAge(DateTime BirthDate)
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
