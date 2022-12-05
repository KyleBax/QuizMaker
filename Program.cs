﻿namespace QuizMaker
{
    internal class Program
    {
        static readonly bool TEST = false;
        static void Main(string[] args)
        {
            //Store the QNA in a xml file
            //Call questions from the xml file to ask
            //Randomise the output of the QNA so you don't know the order
            UI.WelcomeMessage();
            if (TEST == true)
            {
                QuestionAndAnswers testQuestion = new();
                testQuestion.Question = "What colour are bananas?";
                testQuestion.Answers.Add("Blue");
                testQuestion.Answers.Add("Red");
                testQuestion.Answers.Add("Yellow");
                testQuestion.Answers.Add("Pink");
                testQuestion.CorrectAnswerIndex = 2;
                UI.PrintQuestionAndAnswers(testQuestion);
                int guess = UI.GetGuess();
                UI.ResultOfUsersGuess(testQuestion, guess);
            }
            else
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<QuestionAndAnswers>));
                var path = @"C:\Repos\Rakete mentoring work\QuizMaker\Questions";
                List<QuestionAndAnswers> listOfQuestionsAndAnswers = new List<QuestionAndAnswers>();
                using (FileStream file = File.OpenRead(path))
                {
                    listOfQuestionsAndAnswers = xmlSerializer.Deserialize(file) as List<QuestionAndAnswers>;
                }
                //work out a way to only call ChoiceToAddQuestions once
                string addQuestions = UI.ChoiceToAddQuestions();
                while (addQuestions == "y")
                {
                    QuestionAndAnswers question = UI.CreateQuestionsAndAnswers();
                    listOfQuestionsAndAnswers.Add(question);
                    addQuestions = UI.ChoiceToAddQuestions();
                }

                using (FileStream file = File.Create(path))
                {
                    xmlSerializer.Serialize(file, listOfQuestionsAndAnswers);
                }
                using (FileStream file = File.OpenRead(path))
                {
                    listOfQuestionsAndAnswers = xmlSerializer.Deserialize(file) as List<QuestionAndAnswers>;
                }
                foreach (QuestionAndAnswers question in listOfQuestionsAndAnswers)
                {
                    Console.WriteLine();
                    UI.PrintQuestionAndAnswers(question);
                    int guess = UI.GetGuess();
                    UI.ResultOfUsersGuess(question, guess);
                }
            }
        }
    }
}