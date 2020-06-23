using System;

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
                    tupleOfAuthor = new Tuple<Author, double>(author, author.PositivePercentagePhrases());
                }
                else
                {
                    tupleOfAuthor = new Tuple<Author, double>(author, author.NegativePercentagePhrases());
                }
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            OrderReport();
        }
    }
}
