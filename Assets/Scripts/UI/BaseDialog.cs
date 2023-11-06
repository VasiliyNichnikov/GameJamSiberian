using System;
using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
    public abstract class BaseDialog : MonoBehaviour, IDisposable
    {
        private DialogsManager _manager;

        public virtual bool CanCloseWithAllDialogs { get; } = true;
        
        [CanBeNull] private Action _onHideAction;
        
        public void BaseInit(DialogsManager manager)
        {
            _manager = manager;
        }

        public virtual void Show()
        {
        }

        public virtual void Hide()
        {
            _onHideAction?.Invoke();
            _manager.RemoveDialog(this);
        }

        /// <summary>
        /// Выставить действие которое вызовится при скрытие объекта
        /// </summary>
        public void SetHideAction(Action action)
        {
            _onHideAction = action;
        }

        public virtual void Dispose()
        {
            // override me
        }
    }
}