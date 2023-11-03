#nullable enable
using System.Collections.Generic;
using UI.Programs;
using UnityEngine;

namespace UI
{
    public class DialogsManager : MonoBehaviour, IDialogsManager
    {
        private readonly List<BaseDialog> _openDialogs = new ();

        private DialogFactory _factory = null!;
        
        public void Init(Transform parentDialogs)
        {
            _factory = new DialogFactory(parentDialogs);
        }
        
        
        public T ShowDialog<T>() where T : BaseDialog
        {
            var dialog = _factory.CreateDialog<T>();
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

            dialog.Dispose();
            dialog.gameObject.SetActive(false);
            _openDialogs.Remove(dialog);
            Destroy(dialog.gameObject);
        }
    }
}