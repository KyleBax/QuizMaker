namespace QuizMaker
{
    internal class Logic
    {
        public static readonly string PATH = @"C:\Repos\Rakete mentoring work\QuizMaker\Questions";
        public static List<QuestionAndAnswers> Deserialize(List<QuestionAndAnswers> listOfQuestionsAndAnswers)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<QuestionAndAnswers>));
            using (FileStream file = File.OpenRead(PATH))
            {
                listOfQuestionsAndAnswers = xmlSerializer.Deserialize(file) as List<QuestionAndAnswers>;
            }
            return listOfQuestionsAndAnswers;
        }
        public static void Serialize(List<QuestionAndAnswers> listOfQuestionsAndAnswers)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<QuestionAndAnswers>));
            using (FileStream file = File.Create(PATH))
            {
                xmlSerializer.Serialize(file, listOfQuestionsAndAnswers);
            }
        }
    }
}
