using BusinessLogicExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class AuthorPersistence
    {
        public AuthorPersistence()
        {
        }

        public void AddAuthor(Author author)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    ctx.Authors.Add(author);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new AuthorException("Error agregando autor.", ex);
                }
            }
        }

        public bool ContainsAuthor(Author author)
        {
            using (Context ctx = new Context())
            {
                return ctx.Authors.Any(a => !a.IsDeleted && a.UserName.ToLower().Equals(author.UserName.ToLower()));
            }
        }

        public Author[] AllAuthorsForReport()
        {
            using (Context ctx = new Context())
            {
                return ctx.Authors.Include("ListOfPhraseOfAuthor").Include("ListOfPhraseOfAuthor.Entity").Where(e => !e.IsDeleted).ToArray();
            }
        }

        public Author[] AllAuthors()
        {
            using (Context ctx = new Context())
            {
                return ctx.Authors.Include("ListOfPhraseOfAuthor").Where(e => !e.IsDeleted).ToArray();
            }
        }

        public void ModifyInformationAuthor(Author authorToModificate, Author authorCopy)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    var authorOfDb = ctx.Authors.SingleOrDefault(a => a.Id == authorToModificate.Id);
                    authorOfDb.Name = authorCopy.Name;
                    authorOfDb.LastName = authorCopy.LastName;
                    authorOfDb.UserName = authorCopy.UserName;
                    authorOfDb.BirthDate = authorCopy.BirthDate;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando autor.", ex);
                }
            }
        }

        public Author GetAuthorById(Author author)
        {
            using (Context ctx = new Context())
            {
               Author authorToReturn = ctx.Authors.SingleOrDefault(a => a.Id == author.Id && !a.IsDeleted);
               return authorToReturn; 
            }
        }


        public void DeleteAuthor(Author author)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    var authorOfDb = ctx.Authors.SingleOrDefault(a => a.Id == author.Id);
                    authorOfDb.IsDeleted = true;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando autor.", ex);
                }
            }
        }

        public void DeleteAll()
        {
            using (Context ctx = new Context())
            {
                try
                {
                    foreach (Author author in ctx.Authors.ToList())
                    {
                        ctx.Authors.Remove(author);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando los autor", ex);
                }
            }
        }

        
    }
}
