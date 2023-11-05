#nullable enable
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace UI.Programs.Messenger
{
    public class ChatManager
    {
        public IReadOnlyCollection<SentMessage> SentMessages => _sentMessages;

        public MessengerData.UserData UserData => _sendingUserData;
        
        /// <summary>
        /// Отправленные сообщения
        /// </summary>
        private readonly List<SentMessage> _sentMessages = new();

        /// <summary>
        /// Не обработанные
        /// Это может быть сообщение ожидающее отправки
        /// Так и сообщение которое должен отправить игрок на выбор
        /// </summary>
        private readonly Queue<UnsentMessage> _unprocessedMessages = new();

        private readonly MessengerData.UserData _sendingUserData;
        
        public ChatManager(UserType sendingUserType)
        {
            _sendingUserData = DataHelper.Instance.MessengerData.GetUserDataByType(sendingUserType);
        }
        
        public void AddMessage(MessageSendingData sendingData)
        {
            _unprocessedMessages.Enqueue(new ResponseMessage(sendingData.Text, _sendingUserData.Icon, _sendingUserData.Type, sendingData.TimeOfWriting));
        }

        public void AddMessage(MessageResponseData responseData)
        {
            _unprocessedMessages.Enqueue(new AnswerFromPlayerMessage(responseData.MessageSelection));
        }

#if UNITY_EDITOR
        /// <summary>
        /// Этот метод должен быть удален после введения общей логики движения игрока по сюжета
        /// Пока для проверки
        /// </summary>
        public void ConvertAllMessagesDebug()
        {
            while (_unprocessedMessages.Count > 0)
            {
                var package = _unprocessedMessages.Dequeue();
                _sentMessages.Add(package.ConvertToSentMessage());
            }
        }
#endif

        public bool TryGetMessage(out UnsentMessage? message)
        {
            if (_unprocessedMessages.Count == 0)
            {
                message = null;
                return false;
            }

            message = _unprocessedMessages.Dequeue();
            return true;
        }
    }
}