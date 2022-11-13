namespace QuizMaker
{
    internal class UI
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine(@"Welcome to THE QUIZMAKER!!!
All you need to play are: Some questions, of which you know the answer to.
A bit of creativity for some fake answers.
And some friends to challenge (well not really, but I'm sure it's more fun with friends).
Let's get started");
        }
        public static string GetUserInput()
        {
            string input = Console.ReadLine();
            return input;
        }
        public static void AddQuestions()
        {
            Console.WriteLine("Would you like to add questions?\nY/N");
            if (Console.ReadLine().ToLower() == "y")
            {
                QuestionAndAnswers newQuestion = new();
                Console.WriteLine("Please enter the question you would like to ask");
                newQuestion.Question = Console.ReadLine();
                Console.WriteLine("How many answers would you like to provide?");
                int i = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine("Now enter some answers");
                    newQuestion.Answers.Add(Console.ReadLine());
                }
                //work out how to reword this so it makes more sense
                Console.WriteLine("Now enter a number correspoonding to which answer you gave was correct");
            }
        }
    }
}
