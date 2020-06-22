using Domain;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Persistence;
using System;

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


        public void UpdateAssociatedSentiment(Sentiment[] sentimentsContainedInPhrase)
        {
            sentimentPersistence.UpdateAssociatedSentiment(sentimentsContainedInPhrase);
        }

        private void VerifyFormatAdd(Sentiment sentiment)
        {
            if (IsPartOfAnotherSentiment(sentiment))
            {
                throw new TextManagementException(MessagesExceptions.ErrorIsContained);
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
            bool toReturn = false;

            string sentimentText = Utilities.DeleteSpaces(sentiment.SentimientText.ToLower().Trim());

            for (int i = 0; i < QuantityOfAllSentiments() && !toReturn; i++)
            {
                string currentSentiment = AllSentiments[i].SentimientText;
                currentSentiment = Utilities.DeleteSpaces(currentSentiment.ToLower().Trim());

                if (sentimentText.Contains(currentSentiment) || currentSentiment.Contains(sentimentText))
                {
                    toReturn = true;
                }

            }
            return toReturn;
        }

        private void VerifyFormatDelete(Sentiment sentiment)
        {
            if (IsNotContained(sentiment))
            {
                throw new TextManagementException(MessagesExceptions.ErrorDontExist);
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

        public void EmptySentiment()
        {
            sentimentPersistence.DeleteAll();
        }
    }
}
