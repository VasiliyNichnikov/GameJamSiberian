#nullable enable
using System.Collections.Generic;
using UI.Programs.Messenger.ViewModel;
using UniRx;
using UnityEngine;
using Utils;

namespace UI.Programs.Messenger.View
{
    public class ChatView : MonoBehaviour
    {
        [SerializeField] private RectTransform _contentHolder = null!;
        [SerializeField] private SentMessageView _messageViewPrefab = null!;
        private IChatViewModel _viewModel = null!;

        public void Init(IChatViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.SentMessages.ObserveEveryValueChanged(x => x.Value).Subscribe(CreateSentMessages);
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
    }
}