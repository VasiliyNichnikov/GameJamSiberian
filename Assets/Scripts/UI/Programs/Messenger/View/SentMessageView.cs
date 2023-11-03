#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.Messenger.View
{
    public class SentMessageView : MonoBehaviour
    {
        [SerializeField] private Text _messageText = null!;
        
        public void Init(SentMessage data)
        {
            _messageText.text = data.MessageText;
        }
    }
}