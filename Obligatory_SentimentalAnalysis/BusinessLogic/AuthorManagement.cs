using BusinessLogicExceptions;
using Domain;
using System.Collections.Generic;
using System.Security.Permissions;

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

        public void UpdateAuthorInformation(Author authorToModificate, Author copyAuthor)
        {
            FormatFields(copyAuthor);
            copyAuthor.VerifyFormat();
            verifyFormatModificateAuthor(copyAuthor, authorToModificate);
            CopyInformationAuthorToAuthor(authorToModificate, copyAuthor);
        }

        private void verifyFormatModificateAuthor(Author copyAuthor, Author authorToModificate)
        {
            if (!copyAuthor.Equals(authorToModificate))
            {
                if (IsContained(copyAuthor))
                {
                    throw new AuthorException(MessagesExceptions.ErrorAuthorExist);
                }
            }

        }

        private void CopyInformationAuthorToAuthor(Author authorToModificate, Author copyAuthor)
        {
            authorToModificate.Name = copyAuthor.Name;
            authorToModificate.LastName = copyAuthor.LastName;
            authorToModificate.UserName = copyAuthor.UserName;
            authorToModificate.BirthDate = copyAuthor.BirthDate;
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
            author.UserName = Utilities.DeleteSpaces(author.UserName.Trim());
            author.Name = Utilities.DeleteSpaces(author.Name.Trim());
            author.LastName = Utilities.DeleteSpaces(author.LastName.Trim());
        }

        public Author[] AllAuthors
        {
            get { return authorList.ToArray(); }
        }

    }
}
