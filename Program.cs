namespace QuizMaker
{
    internal class Program
    {
        private static readonly int QUESTION_COUNT = 10;

        static void Main(string[] args)
        {
            bool questionsAdded = false;
            int score = 0;
            int questionsAsked = 0;

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

            for (int i = 0; i < QUESTION_COUNT; i++)
            {
                if (i >= listOfQuestionsAndAnswers.Count)
                {
                    break;
                }
                UI.PrintQuestionAndAnswers(listOfQuestionsAndAnswers[i]);
                int guess = UI.GetGuess();
                bool result = Logic.CheckResultOfGuess(listOfQuestionsAndAnswers[i], guess);
                UI.PrintResultOfGuess(listOfQuestionsAndAnswers[i], result);
                questionsAsked++;
                score = Logic.IncreaseScoreCount(score, result);
            }
            UI.PrintScore(score, questionsAsked);
        }
    }
}