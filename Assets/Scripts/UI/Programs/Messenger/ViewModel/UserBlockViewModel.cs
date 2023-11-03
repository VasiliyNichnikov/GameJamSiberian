#nullable enable
using System;
using UnityEngine;

namespace UI.Programs.Messenger.ViewModel
{
    public class UserBlockViewModel : IUserBlockViewModel
    {
        public string NameUser { get; }
        public Sprite Icon { get; }

        private readonly Action _onClickHandler;

        public UserBlockViewModel(UserType type, Action onClickHandler)
        {
            var userData = DataHelper.Instance.MessengerData.GetUserDataByType(type);
            NameUser = userData.Name;
            Icon = userData.Icon;
            _onClickHandler = onClickHandler;
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