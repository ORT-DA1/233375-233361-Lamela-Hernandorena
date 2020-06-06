using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Id { get; set; }

        private List<Phrase> authorPhraseList; 
        
        public Author()
        {
            authorPhraseList = new List<Phrase>(); 
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
            if(Name.Length > 15 || LastName.Length > 15)
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
            if(CalculateAge(BirthDate)< 13 || CalculateAge(BirthDate) > 100)
            {
                throw new AuthorException(MessagesExceptions.ErrorAge); 
            }
            
        }

        public static int CalculateAge(DateTime BirthDate)
        {
            DateTime actualDate  = DateTime.Today;
            int age = actualDate.Year - BirthDate.Year;
            if (BirthDate.Month > actualDate.Month)
            {
                --age;
            }

            return age;
        } 

        public void AddPhrase(Phrase phrase)
        {
            authorPhraseList.Add(phrase); 
        }

        public Phrase[] AllAuthorPhrases
        {
            get { return authorPhraseList.ToArray(); }
        }

        public void DeleteAllPhrases()
        {
            authorPhraseList.Clear(); 
        }

        public override string ToString()
        {
            return " Usuario: " + UserName + " con nombre: " + Name; 
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Author author = (Author)obj;
                return string.Equals(Utilities.DeleteSpaces(UserName.Trim()),
                    Utilities.DeleteSpaces(author.UserName.Trim()),
                    StringComparison.OrdinalIgnoreCase);
            }
        }



    }
}
