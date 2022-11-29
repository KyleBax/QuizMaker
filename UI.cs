namespace QuizMaker
{
    internal class UI
    {
        /// <summary>
        /// Prints the welcome message to the console
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine(@"Welcome to THE QUIZMAKER!!!
All you need to play are: Some questions, of which you know the answer to.
A bit of creativity for some fake answers.
And some friends to challenge (well not really, but I'm sure it's more fun with friends).
Let's get started");
        }
        /// <summary>
        /// Allows the user to enter new questions and answers
        /// </summary>
        /// <returns></returns>
        public static QuestionAndAnswers AddQuestions()
        {
            Console.WriteLine("Would you like to add questions?\nY/N");
            if (Console.ReadLine().ToLower() == "y")
            {
                QuestionAndAnswers newQuestion = new();
                Console.WriteLine("Please enter the question you would like to ask");
                newQuestion.Question = Console.ReadLine();
                Console.WriteLine("How many answers would you like to provide?");
                //TODO fix error where if you don't enter a number the program crashes.
                int i = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine("Now enter some answers");
                    newQuestion.Answers.Add(Console.ReadLine());
                }
                //work out how to reword this so it makes more sense
                Console.WriteLine("Now enter a number correspoonding to which answer you gave was correct");
                newQuestion.CorrectAnswerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                return newQuestion;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// prints a set of questions and answers to the console
        /// </summary>
        /// <param name="questionAndAnswers"></param>
        public static void PrintQuestionAndAnswers(QuestionAndAnswers questionAndAnswers)
        {
            int i = 0;
            Console.WriteLine(questionAndAnswers.Question);
            foreach (string answer in questionAndAnswers.Answers)
            {
                i++;
                Console.WriteLine($"{i}: {answer}");
            }
        }
        /// <summary>
        /// Gets the input guess of the user
        /// </summary>
        /// <param name="questionAndAnswers"></param>
        /// <returns></returns>
        public static int GetGuess(QuestionAndAnswers questionAndAnswers)
        {
            Console.WriteLine("Which answer do you think is correct?\nEnter the corresponding number.");
            int guess = Convert.ToInt32(Console.ReadLine()) - 1;
            return guess;
        }
        /// <summary>
        /// Tells the user if their guess was right or wrong
        /// </summary>
        /// <param name="questionAndAnswers"></param>
        /// <param name="guess"></param>
        public static void ResultOfUsersGuess(QuestionAndAnswers questionAndAnswers, int guess)
        {
            if (guess == questionAndAnswers.CorrectAnswerIndex)
            {
                Console.WriteLine("You are correct");
            }
            else
            {
                Console.WriteLine($"Sorry, that is not the correct answer, the correct answer was {questionAndAnswers.Answers[questionAndAnswers.CorrectAnswerIndex]}");
            }
        }
    }
}
