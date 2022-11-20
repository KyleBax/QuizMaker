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
                UI.Guess(testQuestion);
            }
            else
            {
                QuestionAndAnswers question = new();
                question = UI.AddQuestions();
                UI.PrintQuestionAndAnswers(question);
                UI.Guess(question);
            }

        }
    }
}