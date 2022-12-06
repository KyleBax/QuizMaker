namespace QuizMaker
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool questionsAdded = false;

            UI.PrintWelcomeMessage();
            UI.PrintInstructions();
            List<QuestionAndAnswers> listOfQuestionsAndAnswers = Logic.Deserialize();
        
            while (true)
            {
                string addQuestions = UI.ChoiceToAddQuestions();
                if (addQuestions != "y")
                {
                    break;
                }
                QuestionAndAnswers question = UI.CreateQuestionsAndAnswers();
                listOfQuestionsAndAnswers.Add(question);
                questionsAdded = true;
            }

            if (questionsAdded)
            {
                Logic.Serialize(listOfQuestionsAndAnswers);
            }

            foreach (QuestionAndAnswers question in listOfQuestionsAndAnswers)
            {
                UI.PrintQuestionAndAnswers(question);
                int guess = UI.GetGuess();
                UI.ResultOfUsersGuess(question, guess);
            }
        }
    }
}