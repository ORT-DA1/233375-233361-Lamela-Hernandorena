using BusinessLogicExceptions;
using Domain;
using System;
using System.Linq;

namespace Persistence
{
    public class AuthorPersistence
    {
        public AuthorPersistence()
        {
        }

        public void AddAuthor(Author author)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Authors.Add(author);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error agregando autor.", ex);
            }
        }

        public bool ContainsAuthor(Author author)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Authors.Any(a => !a.IsDeleted && a.UserName.ToLower().Equals(author.UserName.ToLower()));
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error verificando si autor esta contenido.", ex);
            }
        }

        public Author[] AllAuthorsForReport()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Authors.Include("ListOfPhraseOfAuthor").Include("ListOfPhraseOfAuthor.Entity").Where(e => !e.IsDeleted).ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo todos los autores.", ex);
            }
        }

        public Author[] AllAuthors()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Authors.Include("ListOfPhraseOfAuthor").Where(e => !e.IsDeleted).ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo todos los autores.", ex);
            }
        }

        public void ModifyInformationAuthor(Author authorToModificate, Author authorCopy)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var authorOfDb = ctx.Authors.SingleOrDefault(a => a.Id == authorToModificate.Id);
                    authorOfDb.Name = authorCopy.Name;
                    authorOfDb.LastName = authorCopy.LastName;
                    authorOfDb.UserName = authorCopy.UserName;
                    authorOfDb.BirthDate = authorCopy.BirthDate;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error modificando autor.", ex);
            }
        }

        public Author GetAuthorById(Author author)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Authors.SingleOrDefault(a => a.Id == author.Id && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo autor.", ex);
            }
        }


        public void DeleteAuthor(Author author)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var authorOfDb = ctx.Authors.SingleOrDefault(a => a.Id == author.Id);
                    authorOfDb.IsDeleted = true;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando autor.", ex);
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    foreach (Author author in ctx.Authors.ToList())
                    {
                        ctx.Authors.Remove(author);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando los autores", ex);
            }
        }
    }
}
