using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class AuthorManagementTest
    {

        AuthorManagement management; 

        [TestInitialize]
        public void SetUp()
        {
            management = new AuthorManagement();
            management.EmptyAll();

        }

        [TestCleanup]
        public void CleanUp()
        {
            management = new AuthorManagement();
            management.EmptyAll();
        }

        [TestMethod]
        public void AddNewAuthor()
        {
            Author author = new Author()
            {
                UserName = "josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
            CollectionAssert.Contains(management.AllAuthors, author); 
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddRepeatedAuthor()
        {
            Author author = new Author()
            {
                UserName = "josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
            management.AddAuthor(author);
        }


        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithEmptyUserName()
        {
            Author author = new Author()
            {
                UserName = "",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithLargeUserName()
        {
            Author author = new Author()
            {
                UserName = "AGUSTINHERNANDORENA",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithEmptyName()
        {
            Author author = new Author()
            {
                UserName = "josami1",
                Name = "",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithEmptyLastName()
        {
            Author author = new Author()
            {
                UserName = "josami1",
                Name = "Joaquin",
                LastName = "",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithLargeName()
        {
            Author author = new Author()
            {
                UserName = "josami1",
                Name = "Joaquinnnnnnnnnnnnnnnn",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithLargeLastName()
        {
            Author author = new Author()
            {
                UserName = "josami1",
                Name = "Joaquin",
                LastName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
        }


        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithMinorAge()
        {
            Author author = new Author()
            {
                UserName = "ricardinho",
                Name = "Ricardo",
                LastName = "Milhos",
                BirthDate = new DateTime(2010, 02, 25)
            };
            management.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithAgeWrong()
        {
            Author author = new Author()
            {
                UserName = "ricardinho",
                Name = "Ricardo",
                LastName = "Milhos",
                BirthDate = new DateTime(2010, 09, 25)
            };
            management.AddAuthor(author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void AddAuthorWithAgeWrong100Years()
        {
            Author author = new Author()
            {
                UserName = "ricardinho",
                Name = "Ricardo",
                LastName = "Milhos",
                BirthDate = new DateTime(1910, 09, 25)
            };
            management.AddAuthor(author);
        }
        
        [TestMethod]
        public void DeleteValidAuthor()
        {
            Author author = new Author()
            {
                UserName = "josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
            management.DeleteAuthor(author); 
            CollectionAssert.DoesNotContain(management.AllAuthors, author);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void DeleteAuthorNotContained()
        {
            Author author = new Author()
            {
                UserName = "ricardinho",
                Name = "Ricardo",
                LastName = "Milhos",
                BirthDate = new DateTime(1910, 09, 25)
            };
            management.DeleteAuthor(author);
        }

        
        [TestMethod]
        public void UpdateAuthorInfo()
        {
            Author authorToModificate = new Author()
            {
                Name = "Agustin",
                LastName = "Hernandorena",
                UserName = "agus",
                BirthDate = new DateTime(2000, 04, 01)
            };
            management.AddAuthor(authorToModificate); 

            Author copyAuthor = new Author()
            {
                Name = "Agustin",
                LastName = "Hernandorena",
                UserName = "agush2000",
                BirthDate = new DateTime(2000, 04, 01)
            };

            management.UpdateAuthorInformation(authorToModificate, copyAuthor);

            Assert.AreEqual(management.GetAuthor(authorToModificate), copyAuthor);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorException))]
        public void UpdateAuthorWithIncorrectInfo()
        {
            Author author = new Author()
            {
                Name = "Agustin",
                LastName = "Hernandorena",
                UserName = "agustin1",
                BirthDate = new DateTime(2000, 04, 01)
            };
            management.AddAuthor(author);

            Author authorToModificate = new Author()
            {
                Name = "Agustin",
                LastName = "Hernandorena",
                UserName = "agus",
                BirthDate = new DateTime(2000, 04, 01)
            };
            management.AddAuthor(authorToModificate); 
            
            Author copyAuthor = new Author()
            {
                Name = "Agustin",
                LastName = "Hernandorena",
                UserName = "agustin1",
                BirthDate = new DateTime(2000, 04, 01)
            };
            management.UpdateAuthorInformation(authorToModificate, copyAuthor);
        }

        [TestMethod]
        public void UpdateAuthorWithTheSameInfo()
        {
            Author authorToModificate = new Author()
            {
                Name = "Agustin",
                LastName = "Hernandorena",
                UserName = "agus",
                BirthDate = new DateTime(2000, 04, 01)
            };
            management.AddAuthor(authorToModificate); 
            Author copyAuthor = new Author()
            {
                Name = "Agustin",
                LastName = "Hernandorena",
                UserName = "agus",
                BirthDate = new DateTime(2000, 04, 01)
            };
            management.UpdateAuthorInformation(authorToModificate, copyAuthor);
            Assert.AreEqual(authorToModificate, copyAuthor);
        }
    }
}
