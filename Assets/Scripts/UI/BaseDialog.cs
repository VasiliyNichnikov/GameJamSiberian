using System;
using UnityEngine;

namespace UI
{
    public abstract class BaseDialog : MonoBehaviour, IDisposable
    {
        private DialogsManager _manager;

        public void BaseInit(DialogsManager manager)
        {
            _manager = manager;
        }

        public virtual void Show()
        {
            transform.SetAsFirstSibling();
        }

        public virtual void Hide()
        {
            _manager.RemoveDialog(this);
        }

        public virtual void Dispose()
        {
            // override me
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}