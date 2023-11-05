namespace BuildServerMiniGame.ViewModel
{
    public class BuildServerMiniGameQuestionViewModel 
    {
        public readonly string QuestionText;
        public bool IsSelect = false;

        public int Id;
        public BuildServerMiniGameQuestionViewModel(string questionText)
        {
            QuestionText = questionText;
        }
    }
}