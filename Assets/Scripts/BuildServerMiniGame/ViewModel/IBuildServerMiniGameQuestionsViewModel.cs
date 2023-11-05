using System.Collections.Generic;

namespace BuildServerMiniGame.ViewModel
{
    public interface IBuildServerMiniGameQuestionsViewModel
    {
        IReadOnlyCollection<BuildServerMiniGameQuestionViewModel> Question { get; }
        List<bool> GetQuestionsStatus();
        void EditSelected(int id, bool value);
    }
}