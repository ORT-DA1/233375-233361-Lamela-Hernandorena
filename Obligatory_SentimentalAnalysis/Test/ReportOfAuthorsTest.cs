using BusinessLogic;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ReportOfAuthorsTest
    {

        GeneralManagement management;
        Author author;
        Author author2;
        Entity entity;
        Entity entity2;
        Entity entity3; 
        Phrase phrase;
        Phrase phrase4;
        Phrase phrase2;
        Phrase phrase3;
        Phrase phrase5;
        Phrase phrase6;
        Phrase phrase1Negative;
        Phrase phrase2Negative;
        Phrase phrase3Negative;
        Phrase phrase4Negative;


        [TestInitialize]
        public void SetUp()
        {
            management = new GeneralManagement();
            author = new Author()
            {
                UserName = "Josami",
                Name = "Joaquin",
                LastName = "Lamela",
                BirthDate = new DateTime(2000, 02, 29)
            };
            author2 = new Author()
            {
                UserName = "agustinh",
                Name = "Agustin",
                LastName = "Hernandorena",
                BirthDate = new DateTime(2000, 04, 01)
            };
            entity = new Entity()
            {
                EntityName = "Mc donalds"
            };
            entity2 = new Entity()
            {
                EntityName = "Pepsi"
            };
            entity3 = new Entity()
            {
                EntityName = "Rappi"
            }; 

             phrase5 = new Phrase()
            {
                TextPhrase = "Me encanta Pepsi",
                PhraseDate = new DateTime(2020, 06, 08),
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };
            phrase = new Phrase()
            {
                TextPhrase = "Me encanta Mc Donalds",
                PhraseDate = new DateTime(2020, 06, 08),
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author
            };

            phrase6 = new Phrase()
            {
                TextPhrase = "Me encanta y Detesto demasiado Mc Donalds",
                PhraseDate = new DateTime(2020, 06, 08),
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };

            phrase4 = new Phrase()
            {
                TextPhrase = "Test sin entidad ni nada",
                PhraseDate = DateTime.Now,
                PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author
            };
            
             phrase2 = new Phrase()
            {
                TextPhrase = "Me encanta Mc Donalds",
                PhraseDate = new DateTime(2020, 03, 11),
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author2
            };

             phrase3 = new Phrase()
            {
                TextPhrase = "Me encanta Pepsi",
                PhraseDate = new DateTime(2020, 06, 05),
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Positive,
                PhraseAuthor = author2
            };

            phrase1Negative = new Phrase()
            {
                TextPhrase = "Odio Pepsi",
                PhraseDate = new DateTime(2020, 06, 13),
                Entity = entity2,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };

            phrase2Negative = new Phrase()
            {
                TextPhrase = "Detesto Mc donalds",
                PhraseDate = DateTime.Now,
                Entity = entity,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author
            };

            phrase3Negative = new Phrase()
            {
                TextPhrase = "Neutral",
                PhraseDate = new DateTime(2020,06,03),
                PhraseType = Phrase.TypePhrase.Neutral,
                PhraseAuthor = author2
            };

            phrase4Negative = new Phrase()
            {
                TextPhrase = "Detesto Rappi",
                PhraseDate = new DateTime(2020, 05, 05),
                Entity = entity3,
                PhraseType = Phrase.TypePhrase.Negative,
                PhraseAuthor = author2
            };


            management.PhraseManagement.DeleteAllPhrases();
            management.AuthorManagement.EmptyAll();
            management.AlarmManagement.DeleteAll();
            management.EntityManagement.DeleteAllEntities();
            management.SentimentManagement.DeleteAllSentiments();
        }

        [TestCleanup]
        public void CleanUp()
        {
            management = new GeneralManagement();
            management.PhraseManagement.DeleteAllPhrases();
            management.AuthorManagement.EmptyAll();
            management.AlarmManagement.DeleteAll();
            management.EntityManagement.DeleteAllEntities();
            management.SentimentManagement.DeleteAllSentiments();
        }
        
        [TestMethod]
        public void CreateAReport()
        {

            PhrasesPercentageReport report = new PhrasesPercentageReport()
            {
                TypeOfSort = AuthorReport.SortingType.Asc,
                IsPercentageOfPositivePhrases = true
            };
   
            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2); 
            
            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase4);
            management.AuthorManagement.GenerateReportOfAuthor(report);

            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[0] = new Tuple<Author, double>(author, 0.5);
            listExcpected[1] = new Tuple<Author, double>(author2, 1.0);
            
            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants); 
        }

        [TestMethod]
        public void CreateAReport1()
        {
            PhrasesPercentageReport report = new PhrasesPercentageReport()
            {
                TypeOfSort = AuthorReport.SortingType.Desc,
                IsPercentageOfPositivePhrases = true
            };

            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase4);
            management.AuthorManagement.GenerateReportOfAuthor(report);

            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[1] = new Tuple<Author, double>(author, 0.5);
            listExcpected[0] = new Tuple<Author, double>(author2, 1.0);

            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants);
        }



        [TestMethod]
        public void CreateANegativeReportASC()
        {
            PhrasesPercentageReport report = new PhrasesPercentageReport()
            {
                TypeOfSort = PhrasesPercentageReport.SortingType.Asc,
                IsPercentageOfPositivePhrases = false
            };
        
           

            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase4);
            management.PhraseManagement.AddPhrase(phrase1Negative);
            management.PhraseManagement.AddPhrase(phrase2Negative);
            management.PhraseManagement.AddPhrase(phrase3Negative);
            management.PhraseManagement.AddPhrase(phrase4Negative);
            management.AuthorManagement.GenerateReportOfAuthor(report);

            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[1] = new Tuple<Author, double>(author, 0.5);
            listExcpected[0] = new Tuple<Author, double>(author2, 0.25);

            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants);


        }

        [TestMethod]
        public void CreateANegativeReportDESC()
        {

            PhrasesPercentageReport report = new PhrasesPercentageReport()
            {
                TypeOfSort = PhrasesPercentageReport.SortingType.Desc,
                IsPercentageOfPositivePhrases = false
            };

            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase4);
           

            management.PhraseManagement.AddPhrase(phrase1Negative);
            management.PhraseManagement.AddPhrase(phrase2Negative);
            management.PhraseManagement.AddPhrase(phrase3Negative);
            management.PhraseManagement.AddPhrase(phrase4Negative);
            management.AuthorManagement.GenerateReportOfAuthor(report);

            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[0] = new Tuple<Author, double>(author, 0.5);
            listExcpected[1] = new Tuple<Author, double>(author2, 0.25);

            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants);

        }


        [TestMethod]
        public void CreateAEntityReportAsc()
        {

            EntitiesMentionedReport report = new EntitiesMentionedReport()
            {
                TypeOfSort = EntitiesMentionedReport.SortingType.Asc
            };
            
            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase4);
            management.PhraseManagement.AddPhrase(phrase6);
            management.PhraseManagement.AddPhrase(phrase1Negative);
            management.PhraseManagement.AddPhrase(phrase2Negative);
            management.PhraseManagement.AddPhrase(phrase3Negative);
            management.PhraseManagement.AddPhrase(phrase4Negative);
            management.AuthorManagement.GenerateReportOfAuthor(report);


            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[0] = new Tuple<Author, double>(author, 2);
            listExcpected[1] = new Tuple<Author, double>(author2, 3);

            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants);

        }


        [TestMethod]
        public void CreateAAverageReportAsc2()
        {

            DailyAveragePhraseReport report = new DailyAveragePhraseReport()
            {
                TypeOfSort = DailyAveragePhraseReport.SortingType.Asc,
                ReportDate = new DateTime(2020, 06, 15)
            };
           

            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase4);
            management.PhraseManagement.AddPhrase(phrase1Negative);
            management.PhraseManagement.AddPhrase(phrase2Negative);
            management.PhraseManagement.AddPhrase(phrase3Negative);
            management.AuthorManagement.GenerateReportOfAuthor(report);

            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[1] = new Tuple<Author, double>(author, Math.Round(4.0/7.0,2));
            listExcpected[0] = new Tuple<Author, double>(author2, Math.Round(3.0 / 96.0,2));
            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants);
        }

        [TestMethod]
        public void CreateAAverageReportDesc()
        {
            DailyAveragePhraseReport report = new DailyAveragePhraseReport()
            {
                TypeOfSort = DailyAveragePhraseReport.SortingType.Desc,
                ReportDate = new DateTime(2020, 06, 15)
            };
            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase4);
            management.PhraseManagement.AddPhrase(phrase1Negative);
            management.PhraseManagement.AddPhrase(phrase2Negative);
            management.PhraseManagement.AddPhrase(phrase3Negative);
            management.AuthorManagement.GenerateReportOfAuthor(report);

            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[0] = new Tuple<Author, double>(author, Math.Round(4.0 / 7.0, 2));
            listExcpected[1] = new Tuple<Author, double>(author2, Math.Round(3.0 / 96.0, 2));

            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants);
        }


        [TestMethod]
        public void CreateAAverageReportDesc22()
        {
            DailyAveragePhraseReport report = new DailyAveragePhraseReport()
            {
                TypeOfSort = DailyAveragePhraseReport.SortingType.Desc,
                ReportDate = new DateTime(2020, 06, 08)
            };
            
            management.AuthorManagement.AddAuthor(author);
            management.AuthorManagement.AddAuthor(author2);

            management.EntityManagement.AddEntity(entity);
            management.EntityManagement.AddEntity(entity2);
            management.EntityManagement.AddEntity(entity3);

            management.PhraseManagement.AddPhrase(phrase);
            management.PhraseManagement.AddPhrase(phrase5);
            management.PhraseManagement.AddPhrase(phrase2);
            management.PhraseManagement.AddPhrase(phrase3);
            management.PhraseManagement.AddPhrase(phrase3Negative);

            management.AuthorManagement.GenerateReportOfAuthor(report);

            Tuple<Author, double>[] listExcpected = new Tuple<Author, double>[2];
            listExcpected[0] = new Tuple<Author, double>(author, 2.00);
            listExcpected[1] = new Tuple<Author, double>(author2, Math.Round(3.0 / 89.0,2));
            CollectionAssert.AreEqual(listExcpected, report.AllAuthorsParticipants);
        }

    }
}
