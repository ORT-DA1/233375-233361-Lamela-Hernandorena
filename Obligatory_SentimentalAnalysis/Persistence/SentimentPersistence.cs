using BusinessLogicExceptions;
using Domain;
using System;
using System.Data.Entity;
using System.Linq;

namespace Persistence
{
    public class SentimentPersistence
    {
        public SentimentPersistence()
        {

        }

        public void AddSentiment(Sentiment sentiment)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Sentiments.Add(sentiment);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error agregando sentimiento.", ex);
            }
        }

        public void UpdateAssociatedSentiments(Sentiment[] sentimentsContainedInPhrase)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    foreach (Sentiment sentiment in sentimentsContainedInPhrase)
                    {
                        ctx.Entry(sentiment).State = EntityState.Modified;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error asociando sentimiento.", ex);
            }
        }

        public void DeleteSentiment(Sentiment sentiment)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var sentimentOfDb = ctx.Sentiments.SingleOrDefault(s => s.Id == sentiment.Id);
                    sentimentOfDb.IsDeleted = true;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando sentimiento.", ex);
            }
        }

        public void UpdateSentiment(Sentiment sentiment)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    Sentiment sentimentOfDb = ctx.Sentiments.SingleOrDefault(sentim => sentim.Id == sentiment.Id);
                    sentimentOfDb.IsAssociatedToPhrase = sentiment.IsAssociatedToPhrase;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error actualizando sentimiento.", ex);
            }
        }

        public bool IsContained(Sentiment sentiment)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Sentiments.Any(s => !s.IsDeleted && s.Id == sentiment.Id && s.SentimientText.ToLower().Equals(sentiment.SentimientText.ToLower()));
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error verificando que el sentimiento este contenido.", ex);
            }
        }

        public Sentiment[] AllSentiments()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Sentiments.Where(e => !e.IsDeleted).ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo todos los sentimientos.", ex);
            }
        }

        public int QuantityOfAllSentiments()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    return ctx.Sentiments.Where(e => !e.IsDeleted).ToArray().Length;
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error obteniendo la cantidad de sentimientos.", ex);
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (Context ctx = new Context())
                {
                    foreach (Sentiment sentiment in ctx.Sentiments.ToList())
                    {
                        ctx.Sentiments.Remove(sentiment);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Error eliminando los sentimientos.", ex);
            }
        }
    }
}
