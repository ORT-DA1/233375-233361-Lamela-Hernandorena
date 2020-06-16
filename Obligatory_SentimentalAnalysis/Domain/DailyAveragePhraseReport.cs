using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DailyAveragePhraseReport : AuthorReport
    {
        public DateTime ReportDate { get; set; }

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
