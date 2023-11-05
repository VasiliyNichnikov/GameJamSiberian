#nullable enable
using UI.Desktop;
using UI.Programs.InstallerIDE.View;
using UI.Programs.InstallerIDE.ViewModel;

namespace UI.ClicksHandler
{
    public class ProgramFileWithIdeClickHandler : IProgramClicksHelper
    {
        public void OnClickHandler(DesktopProgramContext context)
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<InstallerIDEDialog>();
            dialog.Init(new InstallerIDEViewModel(dialog.Hide));
        }
    }
}