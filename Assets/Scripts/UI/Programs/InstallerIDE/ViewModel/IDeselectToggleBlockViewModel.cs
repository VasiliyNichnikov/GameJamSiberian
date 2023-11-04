using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public interface IDeselectToggleBlockViewModel
    {
        IReactiveProperty<bool> OnChangeToggle { get; }
        string Description { get; }

        void OnToggleClickHandler();
    }
}