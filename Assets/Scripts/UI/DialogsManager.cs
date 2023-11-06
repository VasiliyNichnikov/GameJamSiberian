#nullable enable
using System.Collections.Generic;
using UI.Bluer;
using UnityEngine;

namespace UI
{
    public class DialogsManager : MonoBehaviour, IDialogsManager
    {
        private readonly List<BaseDialog> _openDialogs = new ();

        private DialogFactory _factory = null!;
        private Transform _parentDialogs = null!;
        private Transform _bluerParent = null!;
        
        public void Init(Transform parentDialogs, Transform bluerParent)
        {
            _parentDialogs = parentDialogs;
            _bluerParent = bluerParent;
            _factory = new DialogFactory();
        }
        
        public BluerDialog ShowBluer() => ShowDialog<BluerDialog>(_bluerParent);

        public T ShowDialog<T>() where T : BaseDialog => ShowDialog<T>(_parentDialogs);

        private T ShowDialog<T>(Transform parent) where T : BaseDialog
        {
            var dialog = _factory.CreateDialog<T>(parent);
            if (dialog == null)
            {
                Debug.LogError("DialogsManager.ShowDialog dialog is null");
                return null!;
            }
            
            _openDialogs.Add(dialog);
            dialog.BaseInit(this);
            dialog.Show();
            
            return dialog;
        }

        public void RemoveDialog(BaseDialog dialog)
        {
            if (!_openDialogs.Contains(dialog))
            {
                Debug.LogError("DialogsManager.RemoveDialog dialog not contains in list");
                return;
            }
            
            dialog.gameObject.SetActive(false);
            _openDialogs.Remove(dialog);
            Destroy(dialog.gameObject);
        }
    }
}