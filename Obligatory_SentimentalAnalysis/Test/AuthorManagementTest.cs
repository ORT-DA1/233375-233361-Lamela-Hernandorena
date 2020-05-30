﻿using System;
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
        public void AddPhraseToAuthor()
        {
            Author author = new Author()
            {
                UserName = "josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
            Entity entity = new Entity()
            {
                EntityName = "Disney"
            };
            Phrase phrase = new Phrase()
            {
                TextPhrase = "No me gusta Disney",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
            author.AddPhrase(phrase); 
            CollectionAssert.Contains(author.AllAuthorPhrases, phrase);
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
        public void DeleteAllPhrasesOfAuthor()
        {
            Author author = new Author()
            {
                UserName = "josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.AddAuthor(author);
            Entity entity = new Entity()
            {
                EntityName = "Disney"
            };
            Phrase phrase = new Phrase()
            {
                TextPhrase = "No me gusta Disney",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
            author.AddPhrase(phrase);
            author.DeleteAllPhrases(); 
            Assert.IsTrue(author.AllAuthorPhrases.Length==0);
        }



    }
}
