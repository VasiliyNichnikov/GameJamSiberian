#nullable enable
using System.Collections.Generic;
using Configs;
using Configs.Plot;
using UnityEngine;

namespace UI.Programs.Messenger
{
    public class ChatManager
    {
        public IReadOnlyCollection<SentMessage> SentMessages => _sentMessages;

        public MessengerData.UserData UserData { get; }

        public bool AllMessagesSendInChat => _unsentMessages.Count == 0;

        /// <summary>
        /// Отправленные сообщения
        /// </summary>
        private readonly List<SentMessage> _sentMessages = new();

        /// <summary>
        /// Не обработанные
        /// Это может быть сообщение ожидающее отправки
        /// Так и сообщение которое должен отправить игрок на выбор
        /// </summary>
        private readonly Queue<UnsentMessage> _unsentMessages = new();

        private readonly UserType _sendingUserType;
        
        public ChatManager(UserType sendingUserType)
        {
            _sendingUserType = sendingUserType;
            UserData = DataHelper.Instance.MessengerData.GetUserDataByType(sendingUserType);
        }

        public void AddMessage(MessengerPlotData.MessageData messageData)
        {
            var fromMessage = messageData.IdUser == 1 ? _sendingUserType : UserType.Player;
            _unsentMessages.Enqueue(new ResponseMessage(messageData.Text, UserData.Icon, fromMessage, messageData.TimeOfWriting));
        }

        public bool TryGetMessage(out UnsentMessage? message)
        {
            if (_unsentMessages.Count == 0)
            {
                message = null;
                return false;
            }

            message = _unsentMessages.Peek();
            return true;
        }

        /// <summary>
        /// TODO
        /// тут не помешают проверки на случай отсутсвия чего либо
        /// </summary>
        public void MarkFirstMessageAsSent()
        {
            var sentMessage = _unsentMessages.Dequeue().ConvertToSentMessage();
            if (_sentMessages.Contains(sentMessage))
            {
                Debug.LogError("ChatManager.MarkMessageAsSent: sentMessage is already contains in list");
                return;
            }

            _sentMessages.Add(sentMessage);
        }
    }
}