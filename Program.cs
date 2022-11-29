namespace QuizMaker
{
    internal class Program
    {
        static readonly bool TEST = false;
        static void Main(string[] args)
        {
            //Make a program that gets the input from the user to add questions and answers, having the user point which answer is the correct one 
            //Store the QNA in a xml file
            //Call questions from the xml file to ask
            //Randomise the output of the QNA so you don't know the order
            //Update after getting the basics of the program running
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
                int guess = UI.GetGuess(testQuestion);
                UI.ResultOfUsersGuess(testQuestion, guess);
            }
            else
            {
                QuestionAndAnswers question = new QuestionAndAnswers();
                question = UI.AddQuestions();
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(QuestionAndAnswers));
                var path = @"C:\Repos\Rakete mentoring work\QuizMaker\Questions";
                using (FileStream file = File.Create(path))
                {
                    xmlSerializer.Serialize(file, question);
                }
                Console.WriteLine();
                Console.ReadLine();
                UI.PrintQuestionAndAnswers(question);
                int guess = UI.GetGuess(question);
                UI.ResultOfUsersGuess(question, guess);
            }

        }
    }
}