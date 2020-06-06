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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sentiment>().ToTable("Sentiment_Table");
            modelBuilder.Entity<Sentiment>().Property(t => t.SentimientText).IsRequired();
            modelBuilder.Entity<Sentiment>().Property(t => t.SentimentType).IsRequired();
            modelBuilder.Entity<Sentiment>().HasKey(t => t.Id);

            modelBuilder.Entity<Author>().ToTable("Author_Table");
            modelBuilder.Entity<Author>().Property(a => a.UserName).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Author>().Property(a => a.Name).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Author>().Property(a => a.LastName).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Author>().Property(a => a.BirthDate).IsRequired();
            //modelBuilder.Entity<Author>().HasMany(a => a.AllAuthorPhrases).WithRequired(p => p.PhraseAuthor);
            modelBuilder.Entity<Author>().HasKey(a => a.Id);

            modelBuilder.Entity<Phrase>().ToTable("Phrase_Table");
            modelBuilder.Entity<Phrase>().Property(p => p.TextPhrase).IsRequired();
            modelBuilder.Entity<Phrase>().Property(p => p.PhraseType).IsRequired();
            modelBuilder.Entity<Phrase>().Property(p => p.PhraseDate).IsRequired();
            //modelBuilder.Entity<Phrase>().HasRequired(p => p.PhraseAuthor).WithMany(a => a.AllAuthorPhrases);
            modelBuilder.Entity<Phrase>().HasKey(p => p.Id);

            modelBuilder.Entity<Entity>().ToTable("Entity_Table");
            modelBuilder.Entity<Entity>().Property(e => e.EntityName).IsRequired();
            modelBuilder.Entity<Entity>().HasKey(e => e.Id);


            modelBuilder.Entity<Alarm>().ToTable("Alarm_Table");
            modelBuilder.Entity<Alarm>().HasRequired(al => al.Entity);
            modelBuilder.Entity<Alarm>().Property(al => al.TypeOfAlarm).IsRequired();
            modelBuilder.Entity<Alarm>().Property(al => al.QuantityPost).IsRequired();
            modelBuilder.Entity<Alarm>().Property(al => al.QuantityTime).IsRequired();
            modelBuilder.Entity<Alarm>().Property(al => al.IsInHours).IsRequired();
            modelBuilder.Entity<Alarm>().HasKey(al => al.Id);
            modelBuilder.Entity<Alarm>().Property(al => al.TypeOfAlarm).HasColumnName("Prueba");

            modelBuilder.Entity<AuthorAlarm>().ToTable("AuthorAlarm_Table");
            modelBuilder.Entity<AuthorAlarm>().Property(a => a.TypeOfAlarm).IsRequired();
            modelBuilder.Entity<AuthorAlarm>().Property(a => a.QuantityPost).IsRequired();
            modelBuilder.Entity<AuthorAlarm>().Property(a => a.QuantityTime).IsRequired();
            modelBuilder.Entity<AuthorAlarm>().Property(a => a.IsInHours).IsRequired();
            //modelBuilder.Entity<AuthorAlarm>().HasMany(a => a.AllAuthorsWhoActiveAlarm);    //ESTA ES LA LINEA QUE HACE QUE TIRE LA EXCEPCION
            modelBuilder.Entity<AuthorAlarm>().HasKey(a => a.Id);

        }
    }
}
