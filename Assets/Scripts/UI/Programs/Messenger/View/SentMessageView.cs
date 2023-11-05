#nullable enable
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.Messenger.View
{
    public class SentMessageView : MonoBehaviour
    {
        private enum ViewType
        {
            LeftUser,
            LeftUserWithFile,
            RightUser
        }
        
        [Header("Left message")] 
        [SerializeField] private Image _iconUser = null!;
        [SerializeField] private Text _messageLeftText = null!;
        [SerializeField] private GameObject _leftMessageHolder = null!;

        [Header("File")] 
        [SerializeField] private Text _messageFileLeftText = null!;
        [SerializeField] private GameObject _leftFileHolder = null!;
        
        
        [Header("Right message")] 
        [SerializeField] private Text _messageRightText = null!;
        [SerializeField] private GameObject _rightMessageHolder = null!;

        private SentMessage _data = null!;
        
        public void Init(SentMessage data)
        {
            _data = data;
            var viewType = data.FromUser == UserType.Player ? ViewType.RightUser :
                data.IsFile ? ViewType.LeftUserWithFile : ViewType.LeftUser;
            ChangeMessageHolder(viewType);
            
            // Показываем сообщение справой стороны
            switch (viewType)
            {
                case ViewType.LeftUser:
                    _iconUser.sprite = data.SendingUserIcon;
                    _messageLeftText.text = data.MessageText;
                    break;
                case ViewType.LeftUserWithFile:
                    _iconUser.sprite = data.SendingUserIcon;
                    _messageFileLeftText.text = data.MessageText;
                    break;
                case ViewType.RightUser:
                    _messageRightText.text = data.MessageText;
                    break;
            }
        }

        private void ChangeMessageHolder(ViewType viewType)
        {
            _rightMessageHolder.SetActive(viewType == ViewType.RightUser);
            _leftMessageHolder.SetActive(viewType == ViewType.LeftUser || viewType == ViewType.LeftUserWithFile);
            
            _messageLeftText.gameObject.SetActive(viewType == ViewType.LeftUser);
            _leftFileHolder.gameObject.SetActive(viewType == ViewType.LeftUserWithFile);
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnFileClickButton()
        {
            _data.OnClickFileHandler();
        }
    }
}