using System.Collections.Generic;
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
        public string MessageText { get; }
        
        public SentMessage(string text)
        {
            MessageText = text;
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
        
        public ResponseMessage(string text, float timeOfWriting)
        {
            _text = text;
            TimeOfWriting = timeOfWriting;
        }

        public override SentMessage ConvertToSentMessage() => new SentMessage(_text);
    }
     
    /// <summary>
    /// Сообщение на выбор от игрока
    /// Отрисовывам
    /// </summary>
    public class AnswerFromPlayerMessage : UnsentMessage
    {
        private int _variantId;

        private readonly ReadOnlyCollection<string> _variants;
        
        public AnswerFromPlayerMessage(ReadOnlyCollection<string> variants)
        {
            _variants = variants;
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

        public override SentMessage ConvertToSentMessage() => new SentMessage(_variants[_variantId]);
    }
}