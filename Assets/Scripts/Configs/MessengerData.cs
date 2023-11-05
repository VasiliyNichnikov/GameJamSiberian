#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using UI.Programs.Messenger;
using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(fileName = "MessengerData", menuName = "Configs/MessengerData", order = 0)]
    public class MessengerData : ScriptableObject
    {
        public IReadOnlyCollection<ChatData> Chats => _chats;
        public LoginData GetLoginData() => _loginData;
        
        [Serializable]
        public struct UserData
        {
            public string Name => _userName;
            public string Surname => _userSurname;
            public Sprite Icon => _userIcon;
            public UserType Type => _userType;
            
            [SerializeField] private string _userName;
            [SerializeField] private string _userSurname;
            [SerializeField] private Sprite _userIcon;
            [SerializeField] private UserType _userType;
        }
        
        [Serializable]
        public struct MessageData
        {
            public MessageSendingData? MessageSendingData => _messageSendingData;
            public MessageResponseData? MessageResponseData => _messageResponseData;
            
            [SerializeField] private MessageSendingData? _messageSendingData;
            [SerializeField] private MessageResponseData? _messageResponseData;
        }
        
        [Serializable]
        public struct ChatData
        {
            public UserType UserType => _userType;
            public IReadOnlyCollection<MessageData> Messages => _messages;
            
            [SerializeField, Header("С каким пользователем игрок общается")] private UserType _userType;
            [SerializeField] private MessageData[] _messages;
        }
        
        [Serializable]
        public struct LoginData
        {
            public string RightLogin => _rightLogin;
            public string RightPassword => _rightPassword;

            [SerializeField, Header("Правильный логин (Учитывайте регистр и тп)")] private string _rightLogin;
            [SerializeField, Header("Правильный пароль (Учитывайте регистр и тп)")] private string _rightPassword;
        }

        [SerializeField] private ChatData[] _chats = null!;
        [SerializeField] private UserData[] _users = null!;
        [SerializeField] private LoginData _loginData;

        public UserData GetUserDataByType(UserType type)
        {
            var data = _users.FirstOrDefault(data => data.Type == type);
            return data;
        }
    }
}