#nullable enable
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Configs
{
    /// <summary>
    /// Сообщения которые может отправлять игрок
    /// </summary>
    [CreateAssetMenu(fileName = "MessageResponseData", menuName = "Configs/MessageResponseData", order = 0)]
    public class MessageResponseData : ScriptableObject
    {
        public ReadOnlyCollection<string> MessageSelection => new (_messageSelection);
        
        [SerializeField]
        private string[] _messageSelection = null!;
    }
}