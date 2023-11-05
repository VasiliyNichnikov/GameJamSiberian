#nullable enable
using System;
using UniRx;
using UnityEngine;

namespace UI.Programs.Messenger.ViewModel
{
    public class UserBlockViewModel : IUserBlockViewModel
    {
        public IReactiveProperty<bool> IsSelected => _isSelected;
        
        public string NameUser { get; }
        public Sprite Icon { get; }

        private readonly ReactiveProperty<bool> _isSelected = new ReactiveProperty<bool>();
        private readonly Action _onClickHandler;

        public UserType User { get; }
        
        public UserBlockViewModel(UserType type, Action onClickHandler)
        {
            var userData = DataHelper.Instance.MessengerData.GetUserDataByType(type);
            User = type;
            NameUser = userData.Name;
            Icon = userData.Icon;
            _onClickHandler = onClickHandler;
        }

        public void Select()
        {
            _isSelected.Value = true;
        }
        
        public void RemoveSelection()
        {
            _isSelected.Value = false;
        }
        
        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnClickHandler()
        {
            _onClickHandler?.Invoke();
        }
    }
}