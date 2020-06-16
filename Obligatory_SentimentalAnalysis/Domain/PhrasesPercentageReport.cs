using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PhrasesPercentageReport : AuthorReport
    {
        public bool IsPercentageOfPositivePhrases { get; set; }


        public override void GenerateReport(Author[] AuthorsExistents)
        {
            Tuple<Author, double> tupleOfAuthor;
            foreach (Author author in AuthorsExistents)
            {
                if (IsPercentageOfPositivePhrases)
                {
                    tupleOfAuthor = new Tuple<Author, double>(author, author.GeneratePhrasesPercetageReportPositive());
                }
                else
                {
                    tupleOfAuthor = new Tuple<Author, double>(author, author.GeneratePhrasesPercetageReportNegative());
                }
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            OrderReport();
        }
    }
}
