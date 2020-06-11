using BusinessLogicExceptions;
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
        
        public Author()
        {
            UserName = ""; 
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
