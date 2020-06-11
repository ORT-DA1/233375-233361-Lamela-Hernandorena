using Domain;
using System.Data.Entity;

namespace Persistence
{
    public class Context : DbContext
    {
        public Context() 
        {
        }

        public DbSet<Sentiment> Sentiments { get; set; }

        public DbSet<Phrase> Phrases { get; set; }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Alarm> SentimentAlarms { get; set; }

        public DbSet<AuthorAlarm> AuthorAlarms { get; set; }
        
    }
}
