using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PhraseManagementTest
    {

        PhraseManagement management;
        EntityManagement entityManagement;
        AuthorManagement authorManagement; 
        Author author;

        [TestInitialize]
        public void SetUp()
        {
            management = new PhraseManagement();
            entityManagement = new EntityManagement();
            authorManagement = new AuthorManagement(); 
            author = new Author()
            {
                UserName = "Josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            management.DeleteAllPhrases();
            entityManagement.DeleteAllEntities();
            authorManagement.EmptyAll(); 
        }
        

        [TestCleanup]
        public void CleanUp()
        {
            management = new PhraseManagement();
            management.DeleteAllPhrases();
            entityManagement = new EntityManagement();
            entityManagement.DeleteAllEntities();
            authorManagement.EmptyAll();
        }


        [TestMethod]
        public void AddValidPhrase()
        {
            authorManagement.AddAuthor(author);
            Entity entity = new Entity()
            {
                EntityName = "Mc donalds"
            };
            entityManagement.AddEntity(entity);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Me encanta Mc Donalds",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
            CollectionAssert.Contains(management.AllPhrases, phrase);
        }

        [TestMethod]
        public void AddValidPhrase2()
        {
            authorManagement.AddAuthor(author);
            Entity entity = new Entity()
            {
                EntityName = "Disney"
            };
            entityManagement.AddEntity(entity);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "No me gusta Disney",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
            CollectionAssert.Contains(management.AllPhrases, phrase);
        }

        [TestMethod]
        public void AddValidPhrase3()
        {
            authorManagement.AddAuthor(author);
            Entity entity = new Entity()
            {
                EntityName = "Disney"
            };
            entityManagement.AddEntity(entity);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "No       me      gusta   Disney",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
            CollectionAssert.Contains(management.AllPhrases, phrase);
        }

        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddInvalidPhrase2()
        {
            Phrase phrase = new Phrase()
            {
                TextPhrase = ""
            };
            management.AddPhrase(phrase);
        }

        [TestMethod]
        public void AddPhraseWithTodayDate()
        {
            authorManagement.AddAuthor(author);
            Entity entity = new Entity()
            {
                EntityName = "Burger King"
            };
            entityManagement.AddEntity(entity);
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Amo Burger King",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
            CollectionAssert.Contains(management.AllPhrases, phrase);
        }

        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddPhraseWithDateAfterToday()
        {
            authorManagement.AddAuthor(author);
            DateTime aDate = new DateTime(2020, 12, 29);
            Entity entity = new Entity()
            {
                EntityName = "Burger King"
            };
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Amo Burger King",
                PhraseDate = aDate,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
        }


        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddInvalidEmptyPhrases()
        {
            authorManagement.AddAuthor(author);
            Entity entity = new Entity();
            Phrase phrase = new Phrase()
            {
                TextPhrase = "           ",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
        }


        [TestMethod]
        [ExpectedException(typeof(PhraseManagementException))]
        public void AddPhraseWithDateBeforeOneYear()
        {
            authorManagement.AddAuthor(author);
            DateTime aDate = new DateTime(2019, 03, 22);
            Entity entity = new Entity()
            {
                EntityName = "Burger King"
            };

            Phrase phrase = new Phrase()
            {
                TextPhrase = "Amo Burger King",
                PhraseDate = aDate,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
        }

        [TestMethod]
        public void TryingEqualsMethod()
        {
            authorManagement.AddAuthor(author);
            DateTime aDate = new DateTime(2020, 03, 22);

            Entity entity = new Entity()
            {
                EntityName = "Burger King"
            };
            Phrase phrase = new Phrase()
            {
                TextPhrase = "Amo Burger King",
                PhraseDate = aDate,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "Amo Burger King",
                PhraseDate = aDate,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            bool areEquals = phrase.Equals(phrase2);
            Assert.IsTrue(areEquals);
        }


        [TestMethod]
        public void TryingNotEquals()
        {
            authorManagement.AddAuthor(author);
            DateTime aDate = new DateTime(2020, 03, 22);
            Entity entity = new Entity()
            {
                EntityName = "Burger King"
            };
            Entity entity2 = new Entity()
            {
                EntityName = "Mc Donalds"
            };

            Phrase phrase = new Phrase()
            {
                TextPhrase = "Amo Burger King",
                PhraseDate = aDate,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "Amo Mc Donalds",
                PhraseDate = aDate,
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            bool areEquals = phrase.Equals(phrase2);
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void DeleteAllPhrasesOfAuthor()
        {
            authorManagement.AddAuthor(author);
            DateTime aDate = new DateTime(2020, 03, 22);
            Entity entity = new Entity()
            {
                EntityName = "Burger King"
            };
            entityManagement.AddEntity(entity);

            Entity entity2 = new Entity()
            {
                EntityName = "Mc Donalds"
            };
            entityManagement.AddEntity(entity2);

            Phrase phrase = new Phrase()
            {
                TextPhrase = "Amo Burger King",
                PhraseDate = aDate,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            }; 
            Phrase phrase2 = new Phrase()
            {
                TextPhrase = "Amo Mc Donalds",
                PhraseDate = aDate,
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            management.AddPhrase(phrase);
            management.AddPhrase(phrase2);
            management.DeletePhrasesOfAuthor(author);

            CollectionAssert.DoesNotContain(management.AllPhrases, phrase);
            CollectionAssert.DoesNotContain(management.AllPhrases, phrase2);
        }
    }
}
