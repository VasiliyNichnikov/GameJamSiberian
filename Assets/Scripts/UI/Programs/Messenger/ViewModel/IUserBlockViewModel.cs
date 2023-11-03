#nullable enable
using UnityEngine;

namespace UI.Programs.Messenger.ViewModel
{
    public interface IUserBlockViewModel
    {
        string NameUser { get; }
        Sprite Icon { get; }

        void OnClickHandler();
    }
}