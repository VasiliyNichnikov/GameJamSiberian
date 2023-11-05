#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using UI.Programs.Messenger.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.Messenger.View
{
    public class ChatView : MonoBehaviour, IDisposable
    {
        [SerializeField] private ChatUserView _chatUserView = null!;
        [SerializeField] private RectTransform _contentHolder = null!;
        [SerializeField] private SentMessageView _messageViewPrefab = null!;
        [SerializeField] private GameObject _hintToChooseChatText = null!;
        [SerializeField] private Text _animationOfWritingMessageText = null!;
        private IChatViewModel _viewModel = null!;

        private IEnumerator? _animationOfWriting;
        
        public void Init(IChatViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.SentMessages.ObserveEveryValueChanged(x => x.Value).Subscribe(CreateSentMessages);
            _viewModel.SelectedUser.ObserveEveryValueChanged(x => x.Value).Subscribe(UpdateUserData);
        }

        private void UpdateUserData(MessengerData.UserData? data)
        {
            _hintToChooseChatText.gameObject.SetActive(data == null);
            if (data == null)
            {
                _chatUserView.DeselectUser();
                return;
            }
            
            _chatUserView.SetUserData(data.Value.Name);
            // Так же попытаемся запустить анимацию
            if (_animationOfWriting != null)
            {
                Debug.LogError("ChatView.UpdateUserData: animation is running");
                return;
            }

            _animationOfWriting = AnimationSendingMessageToChat(_viewModel.ReceiveUnsentMessages());
            StartCoroutine(_animationOfWriting);
        }
        
        private void CreateSentMessages(IReadOnlyCollection<SentMessage>? messages)
        {
            if (messages == null)
            {
                return;
            }
            
            _contentHolder.transform.DestroyChildren();
            foreach (var message in messages)
            {
                var view = Instantiate(_messageViewPrefab, _contentHolder);
                view.Init(message);
            }
        }

        private IEnumerator AnimationSendingMessageToChat(IEnumerable<UnsentMessage> unsentMessages)
        {
            foreach (var unsentMessage in unsentMessages)
            {
                yield return new WaitForSeconds(unsentMessage.TimeOfWriting);
                _viewModel.MarkFirstMessageAsSent();
            }
            
            _animationOfWriting = null;
        }

        public void Dispose()
        {
            _viewModel.Dispose();
        }
    }
}