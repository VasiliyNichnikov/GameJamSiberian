#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.Messenger.View
{
    public class SentMessageView : MonoBehaviour
    {
        [Header("Left message")] 
        [SerializeField] private Image _iconImage = null!;
        [SerializeField] private Text _messageLeftText = null!;
        [SerializeField] private GameObject _leftMessageHolder = null!;

        [Header("Right message")] 
        [SerializeField] private Text _messageRightText = null!;
        [SerializeField] private GameObject _rightMessageHolder = null!;
        
        public void Init(SentMessage data)
        {
            ChangeMessageHolder(data.FromUser == UserType.Player);
            
            // Показываем сообщение справой стороны
            if (data.FromUser == UserType.Player)
            {
                _messageRightText.text = data.MessageText;
            }
            else
            {
                _messageLeftText.text = data.MessageText;
                _iconImage.sprite = data.SendingUserIcon;
            }
        }

        private void ChangeMessageHolder(bool showRightHolder)
        {
            _rightMessageHolder.SetActive(showRightHolder);
            _leftMessageHolder.SetActive(!showRightHolder);
        }
    }
}