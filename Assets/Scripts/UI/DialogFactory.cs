#nullable enable
using System;
using System.Collections.Generic;
using UI.Programs.Messenger.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    public class DialogFactory
    {
        private readonly Dictionary<Type, string> _dialogsPath = new()
        {
            { typeof(MessengerDialog), "Prefabs/UI/Messenger/MessengerDialog" },
        };

        private readonly Transform _parentDialogs;

        public DialogFactory(Transform parentDialogs)
        {
            _parentDialogs = parentDialogs;
        }

        public T CreateDialog<T>() where T : BaseDialog
        {
            if (!_dialogsPath.TryGetValue(typeof(T), out var path))
            {
                throw new Exception($"DialogFactory.CreateDialog not found path for dialog: {typeof(T)}");
            }

            var prefab = Resources.Load<T>(path);
            var dialog = Object.Instantiate(prefab, _parentDialogs, false);
            dialog.transform.SetAsLastSibling();
            return dialog;
        }
    }
}