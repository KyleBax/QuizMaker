namespace QuizMaker
{
    internal class Logic
    {
        private static readonly string PATH = @"C:\Repos\Rakete mentoring work\QuizMaker\Questions";

        /// <summary>
        /// Gets questions and answers that are stored in an xml file
        /// </summary>
        /// <param name="listOfQuestionsAndAnswers"></param>
        /// <returns></returns>
        public static List<QuestionAndAnswers> Deserialize(List<QuestionAndAnswers> listOfQuestionsAndAnswers)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<QuestionAndAnswers>));
            try
            {
                using (FileStream file = File.OpenRead(PATH))
                {
                    listOfQuestionsAndAnswers = xmlSerializer.Deserialize(file) as List<QuestionAndAnswers>;
                }
                return listOfQuestionsAndAnswers;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }

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
    }
}
