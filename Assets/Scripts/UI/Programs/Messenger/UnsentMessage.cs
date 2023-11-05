#nullable enable
using UnityEngine;

namespace UI.Programs.Messenger
{
    public abstract class UnsentMessage
    {
        public abstract float TimeOfWriting { get; }
        public abstract SentMessage ConvertToSentMessage();
    }

    /// <summary>
    /// Отправленное сообщение
    /// </summary>
    public class SentMessage
    {
        public UserType FromUser { get; }
        public string MessageText { get; }
        public Sprite SendingUserIcon { get; }

        public SentMessage(string text, Sprite sendingUserIcon, UserType fromUser)
        {
            MessageText = text;
            SendingUserIcon = sendingUserIcon;
            FromUser = fromUser;
        }
    }

    /// <summary>
    /// Еще не отправленное сообщение
    /// Не отрисовываем
    /// </summary>
    public class ResponseMessage : UnsentMessage
    {
        public override float TimeOfWriting { get; }
        private readonly string _text;
        private readonly UserType _fromMessage;
        private readonly Sprite _sendingUserImage;

        public ResponseMessage(string text, Sprite sendingUserImage, UserType fromMessage, float timeOfWriting)
        {
            _sendingUserImage = sendingUserImage;
            _text = text;
            _fromMessage = fromMessage;
            TimeOfWriting = timeOfWriting;
        }

        public override SentMessage ConvertToSentMessage() => new SentMessage(_text, _sendingUserImage, _fromMessage);
    }
}