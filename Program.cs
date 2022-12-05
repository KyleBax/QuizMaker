namespace QuizMaker
{
    internal class Program
    {
        public static readonly string PATH = @"C:\Repos\Rakete mentoring work\QuizMaker\Questions";
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