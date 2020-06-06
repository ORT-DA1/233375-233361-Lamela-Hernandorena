using BusinessLogicExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class SentimentPersistence
    {
        public SentimentPersistence()
        {

        }

        public void AddSentiment(Sentiment sentiment)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    ctx.Sentiments.Add(sentiment);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new TextManagementException("Error agregando sentimiento.", ex);
                }
            }
        }

        public bool IsEmpty()
        {
            using (Context ctx = new Context())
            {
                return ctx.Sentiments.Count() == 0;
            }
        }

        public void DeleteSentiment(Sentiment sentiment)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    var sentimentOfDb = ctx.Sentiments.SingleOrDefault(s => s.Id == sentiment.Id);
                    sentimentOfDb.IsDeleted = true;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando sentimiento.", ex);
                }
            }
        }

        public bool IsContained(Sentiment sentiment)
        {
            using (Context ctx = new Context())
            {
                return ctx.Sentiments.Any(s => !s.IsDeleted && s.Id==sentiment.Id && s.SentimientText.ToLower().Equals(sentiment.SentimientText.ToLower()));
            }
        }

        public Sentiment[] AllSentiments()
        {
            using (Context ctx = new Context())
            {
                return ctx.Sentiments.Where(e => !e.IsDeleted).ToArray();
            }
        }

        public int QuantityOfAllSentiments()
        {
            using (Context ctx = new Context())
            {
                return ctx.Sentiments.Where(e => !e.IsDeleted).ToArray().Length;
            }
        }

        public void DeleteAll()
        {
            using (Context ctx = new Context())
            {
                try
                {
                    foreach (Sentiment sentiment in ctx.Sentiments.ToList())
                    {
                        ctx.Sentiments.Remove(sentiment);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new EntityManagementException("Error eliminando los sentimientos", ex);
                }
            }
        }
    }
}
