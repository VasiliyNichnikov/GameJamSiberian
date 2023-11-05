#nullable enable
using UniRx;
using UnityEngine;

namespace UI.Programs.Messenger.ViewModel
{
    public interface IUserBlockViewModel
    {
        IReactiveProperty<bool> IsSelected { get; }
        
        string NameUser { get; }
        Sprite Icon { get; }

        void OnClickHandler();
    }
}