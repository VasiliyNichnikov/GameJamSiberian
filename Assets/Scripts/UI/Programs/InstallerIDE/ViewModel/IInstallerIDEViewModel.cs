#nullable enable
using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public interface IInstallerIDEViewModel
    {
        IReactiveProperty<bool> IsWelcomeState { get; }
        IReactiveProperty<bool> IsSelectionDiskState { get; }
        IReactiveProperty<bool> IsDeselectTogglesState { get; }
        IReactiveProperty<bool> IsInstallationState { get; }
        IReactiveProperty<bool> IsCompletionState { get; }
        
        IWelcomeViewModel WelcomeViewModel { get; }
        IDiskSelectionViewModel DiskSelectionViewModel { get; }
        IDeselectTogglesViewModel DeselectTogglesViewModel { get; }
        IInstallationViewModel InstallationViewModel { get; }
        
        void OnContinueClickHandler();
    }
}