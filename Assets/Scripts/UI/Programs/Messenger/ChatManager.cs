#nullable enable
using System.Collections.Generic;
using Configs;

namespace UI.Programs.Messenger
{
    public class ChatManager
    {
        public IReadOnlyCollection<SentMessage> SentMessages => _sentMessages;

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

        public void AddMessage(MessageSendingData sendingData)
        {
            _unprocessedMessages.Enqueue(new ResponseMessage(sendingData.Text, sendingData.TimeOfWriting));
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