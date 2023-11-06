#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Configs;
using UniRx;
using UnityEngine;

namespace UI.Programs.Messenger.ViewModel
{
    public class ChatViewModel : IChatViewModel
    {
        public event Action? UploadedMessagesToSend;
        public IReactiveProperty<MessengerData.UserData?> SelectedUser => _userData;
        public IReactiveProperty<ReadOnlyCollection<SentMessage>> SentMessages => _sentMessages;

        private readonly ReactiveProperty<MessengerData.UserData?> _userData = new();
        private readonly ReactiveProperty<ReadOnlyCollection<SentMessage>> _sentMessages = new();
        private readonly MessengerManager _manager;

        private ChatManager? _chatManager;
        
        public ChatViewModel(MessengerManager manager)
        {
            _manager = manager;
            _manager.OnChatSelected += UpdateChat;
            _userData.Value = null;
        }

        private void UpdateChat(ChatManager chat)
        {
            _chatManager = chat;
            _sentMessages.Value = chat.SentMessages.ToList().AsReadOnly();
            _userData.Value = chat.UserData;
            if (!_chatManager.AllMessagesSendInChat)
            {
                UploadedMessagesToSend?.Invoke();
            }
        }
        
        public IEnumerable<UnsentMessage> ReceiveUnsentMessages()
        {
            if (_chatManager == null)
            {
                yield break;
            }

            while (_chatManager.TryGetMessage(out var result))
            {
                yield return result!;
            }
        }

        public void MarkFirstMessageAsSent()
        {
            if (_chatManager == null)
            {
                Debug.LogError("ChatViewModel.SendMessage: chat is not initialized"); 
                return;
            }

            _chatManager.MarkFirstMessageAsSent();
            _sentMessages.Value = _chatManager.SentMessages.ToList().AsReadOnly();
        }

        public void Dispose() => _manager.OnChatSelected -= UpdateChat;
    }
}