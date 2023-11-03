#nullable enable
using UI.Programs.Messenger;
using UnityEngine;

namespace Configs
{
    /// <summary>
    /// Сообщения которые приходят от ботов или в избранном
    /// </summary>
    [CreateAssetMenu(fileName = "MessageSendingData", menuName = "Configs/MessageSendingData", order = 0)]
    public class MessageSendingData : ScriptableObject
    {
        public string Text => _text;
        public float TimeOfWriting => _timeOfWriting;

        [SerializeField, Header("Сообщение")] private string _text;
        [SerializeField, Header("Сколько времени пройдет перед отправкой (Не учитывается для игрока)")] private float _timeOfWriting;
    }
}