using Domain;
using System.Data.Entity;

namespace Persistence
{
    public class Context : DbContext
    {
        public DbSet<Sentiment> Sentiments { get; set; }

        public DbSet<Phrase> Phrases { get; set; }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<EntityAlarm> SentimentAlarms { get; set; }

        public DbSet<AuthorAlarm> AuthorAlarms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
            .HasMany<AuthorAlarm>(author => author.AlarmsWhoAuthorParticipate)
            .WithMany(alarm => alarm.ParticipantsAuthors);

            modelBuilder.Entity<Author>()
            .HasMany<Phrase>(author => author.ListOfPhraseOfAuthor)
            .WithRequired(phrase => phrase.PhraseAuthor); 
        }

    }
}
