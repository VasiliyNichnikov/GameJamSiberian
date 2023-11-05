#nullable enable
using System.Collections.ObjectModel;
using UnityEngine;

namespace UI.Programs.Messenger
{
    public abstract class UnsentMessage
    {
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
        public float TimeOfWriting;
        private readonly string _text;
        private readonly UserType _fromMessage;
        private readonly Sprite _sendingUserImage;

        public ResponseMessage(string text, Sprite sendingUserImage, UserType fromMessage,  float timeOfWriting)
        {
            _sendingUserImage = sendingUserImage;
            _text = text;
            _fromMessage = fromMessage;
            TimeOfWriting = timeOfWriting;
        }

        public override SentMessage ConvertToSentMessage() => new SentMessage(_text, _sendingUserImage, _fromMessage);
    }

    /// <summary>
    /// Сообщение на выбор от игрока
    /// Отрисовывам
    /// </summary>
    public class AnswerFromPlayerMessage : UnsentMessage
    {
        private int _variantId;

        private readonly ReadOnlyCollection<string> _variants;
        private readonly Sprite _sendingUserImage;

        public AnswerFromPlayerMessage(ReadOnlyCollection<string> variants)
        {
            _variants = variants;
            var iconData = DataHelper.Instance.MessengerData.GetUserDataByType(UserType.Player);
            _sendingUserImage = iconData.Icon;
        }

        public void SetVariant(int variantId)
        {
            if (_variantId < 0 || _variantId > _variants.Count)
            {
                Debug.LogError($"AnswerFromPlayerMessage.SetVariant: not corrected id variant: {_variantId}");
                _variantId = 0;
                return;
            }

            _variantId = variantId;
        }

        public override SentMessage ConvertToSentMessage() =>
            new SentMessage(_variants[_variantId], _sendingUserImage, UserType.Player);
    }
}