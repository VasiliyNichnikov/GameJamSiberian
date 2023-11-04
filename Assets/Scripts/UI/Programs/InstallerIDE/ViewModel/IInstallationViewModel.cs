#nullable enable
namespace UI.Programs.InstallerIDE.ViewModel
{
    public interface IInstallationViewModel
    {
        string TitleText { get; }
        string DescriptionText { get; }

        void OnClickCloseHandler();
    }
}