#nullable enable
using System.Collections.ObjectModel;
using UniRx;

namespace UI.Programs.TrelloMiniGame.ViewModel
{
    public interface ITrelloMiniGameViewModel
    {
        ReadOnlyCollection<ITrelloColumnViewModel> Columns { get; }
    }
}