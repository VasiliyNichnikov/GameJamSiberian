#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Programs.Messenger
{
    public class MessengerFacade : IMessengerFacade
    {
        /// <summary>
        /// Срабатывает при добавление нового сообщения в чат
        /// </summary>
        public event Action<UserType, UnsentMessage>? OnNewMessageAdded;

        /// <summary>
        /// Срабатывает при выборе чата и отдает в него уже отправленные сообщения
        /// </summary>
        public event Action<IReadOnlyCollection<SentMessage>>? OnChatSelected;
        
        private readonly Dictionary<UserType, ChatManager> _chats = new Dictionary<UserType, ChatManager>();
        
        public IReadOnlyCollection<UserType> AllUserTypes => Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();

        public MessengerFacade() => InitializeChats();

        public void SelectUserChat(UserType type)
        {
            _chats[type].ConvertAllMessagesDebug();
            OnChatSelected?.Invoke(GetAllSentChatMessages(type));
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
                var chat = new ChatManager();
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