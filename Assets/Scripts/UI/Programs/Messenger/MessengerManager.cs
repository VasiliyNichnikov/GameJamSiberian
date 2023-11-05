#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Plot;
using UI.Desktop;
using UI.Programs.Messenger.View;
using UI.Programs.Messenger.ViewModel;
using UnityEngine;

namespace UI.Programs.Messenger
{
    public class MessengerManager : IMessengerManager
    {
        /// <summary>
        /// Срабатывает при добавление нового сообщения в чат
        /// </summary>
#pragma warning disable CS0067
        public event Action<UserType, UnsentMessage>? OnNewMessageAdded;
#pragma warning disable

        public MessengerState State { get; private set; }

        /// <summary>
        /// Срабатывает при выборе чата и отдает в него уже отправленные сообщения
        /// </summary>
        public event Action<ChatManager>? OnChatSelected;

        private readonly Dictionary<UserType, ChatManager> _chats = new ();

        public static IReadOnlyCollection<UserType> AllUserTypes => Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();
        
        public MessengerManager()
        {
            InitializeChats();
        }
        

        public void SelectUserChat(UserType type)
        {
            if (!_chats.ContainsKey(type))
            {
                Debug.LogError($"MessengerManager.SelectUserChat: not found chat with user {type}");
                return;
            }

            var chat = _chats[type];
            OnChatSelected?.Invoke(chat);
        }

        public void OpenMessenger()
        {
            var viewModel = new MessengerViewModel(this);
            var dialog = Main.Instance.GuiManager.ShowDialog<MessengerDialog>();
            dialog.Init(viewModel);
        }

        public bool AllMessagesSendInChat(UserType user)
        {
            if (!_chats.ContainsKey(user))
            {
                Debug.LogError($"MessengerManager.AllMessagesSendInChat: not found chat with user {user}");
                return false;
            }

            return _chats[user].AllMessagesSendInChat;
        }
        
        public void LoadMessagesInChats(MessengerPlotData data)
        {
            if (!_chats.ContainsKey(data.UserType))
            {
                Debug.LogError($"MessengerManager.LoadMessagesInChats: chat with user {data.UserType} not found");
                return;
            }

            var chat = _chats[data.UserType];
            foreach (var messageData in data.Messages)
            {
                chat.AddMessage(messageData);
            }
        }

        public void EndLogin()
        {
            if (State == MessengerState.Opened)
            {
                Debug.LogError("MessengerManager.EndLogin: manager is already opened");
                return;
            }

            State = MessengerState.Opened;
        }
        
        private void InitializeChats()
        {
            foreach (var userType in AllUserTypes)
            {
                var chat = new ChatManager(Main.Instance.ComputerFacade, userType);
                _chats[userType] = chat;
            }
        }
    }
}