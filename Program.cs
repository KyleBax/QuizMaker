namespace QuizMaker
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            UI.WelcomeMessage();
            List<QuestionAndAnswers> listOfQuestionsAndAnswers = new List<QuestionAndAnswers>();
            listOfQuestionsAndAnswers = Logic.Deserialize(listOfQuestionsAndAnswers);
            //work out a way to only call ChoiceToAddQuestions once
            string addQuestions = UI.ChoiceToAddQuestions();
            while (addQuestions == "y")
            {
                QuestionAndAnswers question = UI.CreateQuestionsAndAnswers();
                listOfQuestionsAndAnswers.Add(question);
                addQuestions = UI.ChoiceToAddQuestions();
            }

            Logic.Serialize(listOfQuestionsAndAnswers);
            listOfQuestionsAndAnswers = Logic.Deserialize(listOfQuestionsAndAnswers);

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