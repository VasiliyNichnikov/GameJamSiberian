#nullable enable
using System;
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
        public bool IsFile { get; }
        
        private readonly Action? _onClickFileButton;
        
        public SentMessage(string text, Sprite sendingUserIcon, UserType fromUser, bool isFile, Action? onClickFileButton)
        {
            MessageText = text;
            SendingUserIcon = sendingUserIcon;
            FromUser = fromUser;
            IsFile = isFile;
            _onClickFileButton = onClickFileButton;
        }

        public void OnClickFileHandler()
        {
            if (!IsFile)
            {
                Debug.LogError("SentMessage.OnClickFileHandler: only files can be clicked on");
                return;
            }
            
            if (_onClickFileButton == null)
            {
                Debug.LogError("SentMessage.OnClickFileHandler: _onClickFileButton is null");
                return;
            }

            _onClickFileButton.Invoke();
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
        private readonly Action? _onClickFileHandler;
        private bool _isFile;
        
        private ResponseMessage(string text, Sprite sendingUserImage, UserType fromMessage, float timeOfWriting, bool isFile)
        {
            _sendingUserImage = sendingUserImage;
            _text = text;
            _fromMessage = fromMessage;
            TimeOfWriting = timeOfWriting;
            _isFile = isFile;
        }

        private ResponseMessage(string text, Sprite sendingUserImage, UserType fromMessage, float timeOfWriting,
            Action onClickFileHandler) : this(text, sendingUserImage, fromMessage, timeOfWriting, true)
        {
            _onClickFileHandler = onClickFileHandler;
        }

        public static ResponseMessage MessageWithMessage(string text, Sprite sendingUserImage, UserType fromMessage, float timeOfWriting)
        {
            return new ResponseMessage(text, sendingUserImage, fromMessage, timeOfWriting, false);
        }
        
        public static ResponseMessage MessageWithFile(string text, Sprite sendingUserImage, UserType fromMessage, float timeOfWriting,
            Action onClickFileHandler)
        {
            return new ResponseMessage(text, sendingUserImage, fromMessage, timeOfWriting, onClickFileHandler);
        }

        public override SentMessage ConvertToSentMessage() => new SentMessage(_text, _sendingUserImage, _fromMessage, _isFile, _onClickFileHandler);
    }
}