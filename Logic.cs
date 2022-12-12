﻿namespace QuizMaker
{
    internal class Logic
    {
        private static readonly string PATH = @"C:\Repos\Rakete mentoring work\QuizMaker\Questions";

        /// <summary>
        /// Gets questions and answers that are stored in an xml file
        /// </summary>
        /// <param name="listOfQuestionsAndAnswers"></param>
        /// <returns></returns>
        public static List<QuestionAndAnswers> Deserialize()
        {
            List<QuestionAndAnswers> listOfQuestionsAndAnswers = new List<QuestionAndAnswers>();
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<QuestionAndAnswers>));
            try
            {       
                using (FileStream file = File.OpenRead(PATH))
                {
                    listOfQuestionsAndAnswers = xmlSerializer.Deserialize(file) as List<QuestionAndAnswers>;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);           
            }
            return listOfQuestionsAndAnswers;

        }

        /// <summary>
        /// Stores questions and answers into an xml file
        /// </summary>
        /// <param name="listOfQuestionsAndAnswers"></param>
        public static void Serialize(List<QuestionAndAnswers> listOfQuestionsAndAnswers)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<QuestionAndAnswers>));
            try
            {
                using (FileStream file = File.Create(PATH))
                {
                    xmlSerializer.Serialize(file, listOfQuestionsAndAnswers);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Determines whether the users guess was right or wrong
        /// </summary>
        /// <param name="questionAndAnswers"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static bool CheckResultOfGuess(QuestionAndAnswers questionAndAnswers, int guess)
        {
            if (guess == questionAndAnswers.CorrectAnswerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int IncreaseScoreCount(int score, bool result)
        {
            if (result)
            {
                score++;
            }
            return score;
        }
    }
}
