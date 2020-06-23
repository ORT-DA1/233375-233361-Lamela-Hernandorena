using System;

namespace Domain
{
    public class EntitiesMentionedReport : AuthorReport
    {
        public override void GenerateReport(Author[] AuthorsExistents)
        {
            foreach (Author author in AuthorsExistents)
            {
                Tuple<Author, double> tupleOfAuthor = new Tuple<Author, double>(author, author.QuantityOfEntityMentioned());
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            OrderReport();
        }
    }
}
