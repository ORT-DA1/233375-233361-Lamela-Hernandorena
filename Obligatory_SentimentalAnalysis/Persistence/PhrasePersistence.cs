using BusinessLogicExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistence
{
    public class PhrasePersistence
    {
        public PhrasePersistence()
        {

        }

        public void AddPhrase(Phrase phrase)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    ctx.Authors.Attach(phrase.PhraseAuthor);
                    
                    ctx.Phrases.Add(phrase);

                    
                    if (phrase.Entity != null)
                    {
                       ctx.Entry(phrase.Entity).State = EntityState.Unchanged;
                    } 
                    
                    ctx.Entry(phrase.PhraseAuthor).State = EntityState.Modified;

                    
                    
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new PhraseManagementException("Error agregando frase", ex);
                }
            }
        }

        public void Update(Phrase phrase)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    Phrase phraseOfDb = ctx.Phrases.SingleOrDefault(p => p.Id == phrase.Id);
                    phraseOfDb.PhraseType = phrase.PhraseType;
                    if (phrase.Entity != null)
                    {
                        phraseOfDb.Entity = ctx.Entities.SingleOrDefault(entity => entity.Id == phrase.Entity.Id);
                    }
                    else
                    {
                        phraseOfDb.Entity = null; 
                    }
                    ctx.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    throw new PhraseManagementException("Error actualizando frase", ex);
                }
            }
        }

        public void DeletePhrasesOfAuthor(Author author)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    List<Phrase> authorPhrases = ctx.Phrases.Where(p => p.PhraseAuthor.Id == author.Id).Include("Entity").Include("PhraseAuthor").ToList();
                    foreach (Phrase phrase in authorPhrases)
                    {
                        phrase.IsDeleted = true;
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new PhraseManagementException("Error eliminado frases", ex);
                }
            }
        }

        public void DeleteAll()
        {
            using (Context ctx = new Context())
            {
                try
                {
                    foreach (Phrase phrase in ctx.Phrases.ToList())
                    {
                        ctx.Phrases.Remove(phrase);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new PhraseManagementException("Error eliminando las phrases", ex);
                }
            }
        }
        
        public Phrase[] AllPhrases()
        {
            using (Context ctx = new Context())
            {
                return ctx.Phrases.Where(p => !p.IsDeleted).Include("Entity").Include("PhraseAuthor").ToArray();
            }
        }
    }
}

    

