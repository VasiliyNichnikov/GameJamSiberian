#nullable enable
using System.Collections.ObjectModel;
using UniRx;

namespace UI.Programs.TrelloMiniGame.ViewModel
{
    public interface ITrelloMiniGameViewModel
    {
        IReactiveProperty<bool> IsCompleted { get; }
        
        ReadOnlyCollection<ITrelloColumnViewModel> Columns { get; }

        void OnClickSaveDataHandler();
    }
}