﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
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
        public event Action<UserType, UnsentMessage>? OnNewMessageAdded;

        /// <summary>
        /// Срабатывает при выборе чата и отдает в него уже отправленные сообщения
        /// </summary>
        public event Action<ChatManager>? OnChatSelected;

        private readonly Dictionary<UserType, ChatManager> _chats = new Dictionary<UserType, ChatManager>();

        public IReadOnlyCollection<UserType> AllUserTypes => Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();

        public MessengerManager() => InitializeChats();

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

        /// <summary>
        /// Получаем все сообщения которые уже были отправлены в чате
        /// </summary>
        private IReadOnlyCollection<SentMessage> GetAllSentChatMessages(UserType type) => _chats[type].SentMessages;

        private void InitializeChats()
        {
            var chats = DataHelper.Instance.MessengerData.Chats;
            foreach (var chatData in chats)
            {
                var chat = new ChatManager(chatData.UserType);
                foreach (var messageData in chatData.Messages)
                {
                    if (messageData.MessageSendingData != null)
                    {
                        chat.AddMessage(messageData.MessageSendingData);
                    }
                    else if (messageData.MessageResponseData != null)
                    {
                        chat.AddMessage(messageData.MessageResponseData);
                    }
                    else
                    {
                        Debug.LogError("MessengerFacade: all data is null");
                    }
                }

                _chats[chatData.UserType] = chat;
            }
        }
    }
}