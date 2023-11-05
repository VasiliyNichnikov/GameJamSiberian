using System;
using Configs;
using UnityEngine;

namespace UI.Programs.Messenger.ViewModel
{
    public class MessengerLoginViewModel : IMessengerLoginViewModel
    {
        private readonly string _rightLogin;
        private readonly string _rightPassword;

        private readonly Action _onCompleteLogin;
        
        public MessengerLoginViewModel(Action onCompleteLogin)
        {
            var data = DataHelper.Instance.MessengerData.GetLoginData();
            _onCompleteLogin = onCompleteLogin;
            _rightLogin = data.RightLogin;
            _rightPassword = data.RightPassword;
        }
        
        public void TryToLogInChat(string login, string password)
        {
            // Вход выполнен
            if (login == _rightLogin && password == _rightPassword)
            {
                _onCompleteLogin.Invoke();
                return;
            }

            Debug.LogWarning("MessengerLoginViewModel.TryToLogInChat: доделать окно с информацией что пароль/логин не подошли");
        }
    }
}