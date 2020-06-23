using System;

namespace Domain
{
    public class DailyAveragePhraseReport : AuthorReport
    {
        public DateTime ReportDate { get; set; }

        public DailyAveragePhraseReport()
        {
            ReportDate = DateTime.Now;
        }

        public override void GenerateReport(Author[] AuthorsExistents)
        {
            foreach (Author author in AuthorsExistents)
            {
                Tuple<Author, double> tupleOfAuthor = new Tuple<Author, double>(author, author.AverageOfDailyPhrases(ReportDate));
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            OrderReport();
        }
    }
}
