#nullable enable
using UnityEngine;

namespace UI.Desktop.ViewModel
{
    public interface IProgramIconViewModel
    {
        Sprite Icon { get; }
        string Name { get; }

        void OnClickHandler();
    }
}