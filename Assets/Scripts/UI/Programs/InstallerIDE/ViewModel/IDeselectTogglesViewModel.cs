#nullable enable
using System.Collections.Generic;
using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public interface IDeselectTogglesViewModel
    {
        string TitleText { get; }
        string DescriptionText { get; }
        IReadOnlyCollection<IDeselectToggleBlockViewModel> Toggles { get; }
        IReactiveProperty<bool> OnAllDeselected { get; }
    }
}