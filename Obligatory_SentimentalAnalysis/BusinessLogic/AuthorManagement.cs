using BusinessLogicExceptions;
using Domain;
using System.Collections.Generic;


namespace BusinessLogic
{
    public class AuthorManagement
    {
        private List<Author> authorList; 

        public AuthorManagement()
        {
            authorList = new List<Author>(); 
        }

        public void AddAuthor(Author author)
        {
            FormatFields(author); 
            author.VerifyFormat();
            VerifyFormatAdd(author);
            authorList.Add(author); 
        }
        
        public void DeleteAuthor(Author author)
        {
            VerifyFormatDelete(author);
            authorList.Remove(author);
        }

        private void VerifyFormatDelete(Author author)
        {
            if (IsNotContained(author))
            {
                throw new AuthorException(MessagesExceptions.ErrorDontExist);
            }

        }
        
        private bool IsNotContained(Author author)
        {
            return !authorList.Contains(author);
        }

        private void VerifyFormatAdd(Author author)
        {
            if (IsContained(author))
            {
                throw new AuthorException(MessagesExceptions.ErrorAuthorExist);
            }
        }

        private bool IsContained(Author author)
        {
            return authorList.Contains(author);
        }

        private void FormatFields(Author author)
        {
            author.UserName = Utilities.DeleteSpaces(author.UserName);
            author.Name = Utilities.DeleteSpaces(author.Name);
            author.LastName = Utilities.DeleteSpaces(author.LastName);
        }

        public Author[] AllAuthors
        {
            get { return authorList.ToArray(); }
        }

    }
}
