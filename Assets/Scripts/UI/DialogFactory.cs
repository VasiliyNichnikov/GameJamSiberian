#nullable enable
using System;
using System.Collections.Generic;
using UI.Bluer;
using UI.Desktop.View;
using UI.Programs.InstallerIDE.View;
using UI.Programs.Messenger.View;
using UI.Programs.TrelloMiniGame.View;
using UI.Programs.PDF.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    public class DialogFactory
    {
        private readonly Dictionary<Type, string> _dialogsPath = new()
        {
            { typeof(MessengerDialog), "Prefabs/UI/Messenger/MessengerDialog" },
            { typeof(TrelloMiniGameDialog), "Prefabs/UI/TrelloMiniGame/TrelloMiniGameDialog" },
            { typeof(DesktopDialog), "Prefabs/UI/Desktop/DesktopDialog" },
            { typeof(InstallerIDEDialog), "Prefabs/UI/InstallerIDE/InstallerIdeDialog" },
            { typeof(PDFDialog), "Prefabs/UI/PDF/PDFDialog" },
            { typeof(BluerDialog), "Prefabs/UI/BluerDialog" },
            {typeof(ErrorDialog), "Prefabs/UI/Desktop/ErrorDialog"}
        };
        
        public T CreateDialog<T>(Transform parentDialog) where T : BaseDialog
        {
            if (!_dialogsPath.TryGetValue(typeof(T), out var path))
            {
                throw new Exception($"DialogFactory.CreateDialog not found path for dialog: {typeof(T)}");
            }

            var prefab = Resources.Load<T>(path);
            var dialog = Object.Instantiate(prefab, parentDialog, false);
            dialog.transform.SetAsLastSibling();
            return dialog;
        }
    }
}