#nullable enable
using System.Collections.Generic;
using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public interface IDiskSelectionViewModel
    {
        string Title { get; }
        string DescriptionText { get; }
        IReactiveProperty<IDiskBlockViewModel?> SelectedDisk { get; }
        IReadOnlyCollection<IDiskBlockViewModel> Disks { get; }
    }
}