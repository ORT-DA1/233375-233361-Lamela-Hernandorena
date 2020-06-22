using BusinessLogicExceptions;
using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace BusinessLogic
{
    public class AuthorManagement
    {
        private AuthorPersistence authorPersistence;

        public AuthorManagement()
        {
            authorPersistence = new AuthorPersistence();
        }

        public void AddAuthor(Author author)
        {
            FormatFields(author);
            author.VerifyFormat();
            VerifyFormatAdd(author);
            authorPersistence.AddAuthor(author);
        }

        public void DeleteAuthor(Author author)
        {
            VerifyFormatDelete(author);
            authorPersistence.DeleteAuthor(author);
        }

        public void UpdateAuthorInformation(Author authorToModificate, Author copyAuthor)
        {
            FormatFields(copyAuthor);
            copyAuthor.VerifyFormat();
            VerifyFormatModificateAuthor(copyAuthor, authorToModificate);
            CopyInformationAuthorToAuthor(authorToModificate, copyAuthor);
        }

        private void VerifyFormatModificateAuthor(Author copyAuthor, Author authorToModificate)
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
            authorPersistence.ModifyInformationAuthor(authorToModificate, copyAuthor);
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
            return !authorPersistence.ContainsAuthor(author);
        }

        private void VerifyFormatAdd(Author author)
        {
            if (IsContained(author))
            {
                throw new AuthorException(MessagesExceptions.ErrorAuthorExist);
            }
        }

        public Author[] AllAuthorsForReports()
        {
            return authorPersistence.AllAuthorsForReport(); 
        }

        public Author GetAuthor(Author authorToGet)
        {
            return authorPersistence.GetAuthorById(authorToGet);
        }

        private bool IsContained(Author author)
        {
            return authorPersistence.ContainsAuthor(author);
        }

        private void FormatFields(Author author)
        {
            author.UserName = Utilities.DeleteSpaces(author.UserName.Trim());
            author.Name = Utilities.DeleteSpaces(author.Name.Trim());
            author.LastName = Utilities.DeleteSpaces(author.LastName.Trim());
        }

        public Author[] AllAuthors
        {
            get { return authorPersistence.AllAuthors(); }
        }

        public void EmptyAll()
        {
            authorPersistence.DeleteAll();
        }

        public void GenerateReportOfAuthor(AuthorReport report)
        {
            report.GenerateReport(AllAuthorsForReports());
        }

    }

}