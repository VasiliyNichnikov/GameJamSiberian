using System;
using UI.Desktop.View;

namespace Utils
{
    public static class SimpleDialogsHelper
    {
        public static void OpenWarningDialog(string title, string description)
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<WarningDialog>();
            dialog.Init(title, description, "Хорошо", dialog.Hide);
        }
    }
}