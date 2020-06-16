using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class AuthorReport
    {

        protected List<Tuple<Author, double>> listOfAuthorsParticipants;

        public enum SortingType { Asc, Desc }

        public SortingType TypeOfSort { get; set; }

        public abstract void GenerateReport(Author[] AuthorsExistents);

        public AuthorReport()
        {
            listOfAuthorsParticipants = new List<Tuple<Author, double>>();
        }

        protected void OrderReport()
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
