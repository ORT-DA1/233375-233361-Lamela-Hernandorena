using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReportOfAuthors
    {
        private List<Tuple<Author, double>> listOfAuthorsParticipants;

        public enum SortingCriterion { PositivePhrasesPercentage, NegativePhrasesPercentage, QuantityOfEntities, PhrasesAverage }

        public enum SortingType { Asc, Desc }

        public SortingCriterion CriterionOfSort { get; set; }

        public SortingType TypeOfSort { get; set; }


        public ReportOfAuthors()
        {
            listOfAuthorsParticipants = new List<Tuple<Author, double>>(); 
        }

        public void GenerateReport(Author[] AuthorsExistents)
        {
            if (CriterionOfSort.Equals(SortingCriterion.PositivePhrasesPercentage))
            {
                GeneratePhrasesPercetageReportPositive(AuthorsExistents); 
            }
            else if (CriterionOfSort.Equals(SortingCriterion.NegativePhrasesPercentage)){ 
                GeneratePhrasesPercetageReportNegative(AuthorsExistents);
            }
            else if(CriterionOfSort.Equals(SortingCriterion.QuantityOfEntities)){
                QuantityOfEntitiesTalkedOnPhrases(AuthorsExistents); 
            }
            else
            {
                AverageOfDailyPhrases(AuthorsExistents); 
            }

            OrderReport(); 
            
        }

        private void GeneratePhrasesPercetageReportPositive(Author[] AuthorsExistents)
        {
            foreach (Author author in AuthorsExistents)
            {
                Tuple<Author, double> tupleOfAuthor = new Tuple<Author, double>(author, author.GeneratePhrasesPercetageReportPositive());
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            
        }

        private void GeneratePhrasesPercetageReportNegative(Author[] AuthorsExistents)
        {
            foreach (Author author in AuthorsExistents)
            {
                Tuple<Author, double> tupleOfAuthor = new Tuple<Author, double>(author, author.GeneratePhrasesPercetageReportNegative());
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            
        }


        public void QuantityOfEntitiesTalkedOnPhrases(Author[] AuthorsExistents)
        {

            foreach (Author author in AuthorsExistents)
            {
                Tuple<Author, double> tupleOfAuthor = new Tuple<Author, double>(author, author.QuantityOfEntityMentioned());
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            
        }

        public void AverageOfDailyPhrases(Author[] AuthorsExistents)
        {
            foreach (Author author in AuthorsExistents)
            {
                Tuple<Author, double> tupleOfAuthor = new Tuple<Author, double>(author, author.AverageOfDailyPhrases());
                listOfAuthorsParticipants.Add(tupleOfAuthor);
            }
            
        }

        private void OrderReport()
        {
            if (TypeOfSort.Equals(SortingType.Asc))
            {
                listOfAuthorsParticipants = listOfAuthorsParticipants.OrderBy(list => list.Item2).ToList();
            }
            else
            {
                listOfAuthorsParticipants = listOfAuthorsParticipants.OrderByDescending(list => list.Item2).ToList();
            }
        }

        public Tuple<Author, double>[] AllAuthorsParticipants
        {
            get { return listOfAuthorsParticipants.ToArray(); }
        }



    }
}
