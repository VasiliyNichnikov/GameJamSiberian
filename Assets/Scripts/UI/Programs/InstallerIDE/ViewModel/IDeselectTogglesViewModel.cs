#nullable enable
using System;
using System.Collections.Generic;
using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public interface IDeselectTogglesViewModel
    {
        string TitleText { get; }
        string DescriptionText { get; }
        
        IReactiveProperty<bool> IsButtonVisible { get; }
        IReadOnlyCollection<IDeselectToggleBlockViewModel> Toggles { get; }
    }
}