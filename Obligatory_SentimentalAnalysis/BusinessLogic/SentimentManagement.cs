using Domain;
using BusinessLogicExceptions;
using Persistence;

namespace BusinessLogic
{
    public class SentimentManagement
    {
        private SentimentPersistence sentimentPersistence;

        public SentimentManagement()
        {
            sentimentPersistence = new SentimentPersistence();
        }

        public void AddSentiment(Sentiment sentiment)
        {
            sentiment.VerifyFormat();
            VerifyFormatAdd(sentiment);
            sentiment.SentimientText = Utilities.DeleteSpaces(sentiment.SentimientText).Trim();
            sentimentPersistence.AddSentiment(sentiment);
        }


        public void UpdateAssociatedSentiments(Sentiment[] sentimentsContainedInPhrase)
        {
            sentimentPersistence.UpdateAssociatedSentiments(sentimentsContainedInPhrase);
        }

        private void VerifyFormatAdd(Sentiment sentiment)
        {
            if (IsPartOfAnotherSentiment(sentiment))
            {
                throw new SentimentManagementException(MessagesExceptions.ErrorIsContained);
            }
        }

        public void UpdateSentiments(Phrase[] allPhrasesOfSystem)
        {
            foreach (Sentiment sentiment in AllSentiments)
            {
                sentiment.IsAssociatedToPhrase = false;
                foreach (Phrase phrase in allPhrasesOfSystem)
                {
                    string textOfPhrase = Utilities.DeleteSpaces(phrase.TextPhrase.Trim().ToLower());
                    string textOfSentiment = Utilities.DeleteSpaces(sentiment.SentimientText.Trim().ToLower());
                    if (textOfPhrase.Contains(textOfSentiment))
                    {
                        sentiment.IsAssociatedToPhrase = true;
                    }
                }
                sentimentPersistence.UpdateSentiment(sentiment);
            }
        }

        private bool IsPartOfAnotherSentiment(Sentiment sentiment)
        {
            bool isContained = false;

            string sentimentText = Utilities.DeleteSpaces(sentiment.SentimientText.ToLower().Trim());

            for (int i = 0; i < QuantityOfAllSentiments() && !isContained; i++)
            {
                string currentSentiment = AllSentiments[i].SentimientText;
                currentSentiment = Utilities.DeleteSpaces(currentSentiment.ToLower().Trim());

                if (sentimentText.Contains(currentSentiment) || currentSentiment.Contains(sentimentText))
                {
                    isContained = true;
                }

            }
            return isContained;
        }

        private void VerifyFormatDelete(Sentiment sentiment)
        {
            if (IsNotContained(sentiment))
            {
                throw new SentimentManagementException(MessagesExceptions.ErrorDontExist);
            }
        }

        public void DeleteSentiment(Sentiment sentiment)
        {
            sentiment.VerifyFormatToDelete();
            VerifyFormatDelete(sentiment);
            sentimentPersistence.DeleteSentiment(sentiment);
        }

        private bool IsNotContained(Sentiment sentiment)
        {
            return !sentimentPersistence.IsContained(sentiment);
        }


        public Sentiment[] AllSentiments
        {
            get { return sentimentPersistence.AllSentiments(); }
        }

        private int QuantityOfAllSentiments()
        {
            return sentimentPersistence.QuantityOfAllSentiments();
        }

        public void DeleteAllSentiments()
        {
            sentimentPersistence.DeleteAll();
        }
    }
}
