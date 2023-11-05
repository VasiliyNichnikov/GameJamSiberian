namespace BuildServerMiniGame.ViewModel
{
    public interface IBuildServerMiniGameViewModel
    {
        string TaskText { get; }
        string HintText { get; }
        bool CheckAnswer();
        string GetRandomError();
        public string GetSusses();
        public IBuildServerMiniGameQuestionsViewModel QuestionsViewModel { get; }
    }
}