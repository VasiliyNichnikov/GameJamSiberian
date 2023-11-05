using System;
using System.Collections.Generic;
using UI.Programs.Messenger;
using UnityEngine;

namespace Configs.Plot
{
    /// <summary>
    /// Храним информацию для одного диалога между игроком и другим участником
    /// Другой участник может быть и игрок (Пишет сам себе в избранном)
    /// </summary>
    [CreateAssetMenu(fileName = "MessengerPlotData", menuName = "Configs/MessengerPlotData", order = 0)]
    public class MessengerPlotData : ScriptableObject
    {
        [Serializable]
        public struct MessageData
        {
            public string Text => _text;
            public float TimeOfWriting => _timeOfWriting;
            public int IdUser => _idUser;
            
            [SerializeField, TextArea, Header("Сообщение")] 
            private string _text;

            [SerializeField, Header("Перед тем как отправить ждем заданное время")]
            private float _timeOfWriting;

            [SerializeField, Range(1, 2), Header("Кто отправит сообщение")]
            private int _idUser;
        }

        public UserType UserType => _userType;
        public IReadOnlyCollection<MessageData> Messages => _messages;
            
        [SerializeField, Header("Пользователь с id 1 (Пользователь с id 2 это игрок)")]
        private UserType _userType;
            
        [SerializeField] 
        private MessageData[] _messages;
        
        
    }
}