using System.Collections.ObjectModel;
using UniRx;

namespace UI.Programs.TrelloMiniGame.ViewModel
{
    public interface ITrelloColumnViewModel
    {
        string TitleColumn { get; }
        
        IReactiveProperty<ReadOnlyCollection<ITrelloTaskViewModel>> Tasks { get; } 
    }
}