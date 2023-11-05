using System.Collections.Generic;
using Configs;
using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public class ChatViewModel : IChatViewModel
    {
        public IReactiveProperty<MessengerData.UserData?> SelectedUser => _userData;
        public IReactiveProperty<IReadOnlyCollection<SentMessage>> SentMessages => _sentMessages;

        private readonly ReactiveProperty<MessengerData.UserData?> _userData = new();
        private readonly ReactiveProperty<IReadOnlyCollection<SentMessage>> _sentMessages = new();
        private readonly MessengerManager _manager;

        public ChatViewModel(MessengerManager manager)
        {
            _manager = manager;
            _manager.OnChatSelected += UpdateChat;
            _userData.Value = null;
        }

        private void UpdateChat(ChatManager chat)
        {
            _sentMessages.Value = chat.SentMessages;
            _userData.Value = chat.UserData;
        }

        public void Dispose() => _manager.OnChatSelected -= UpdateChat;
    }
}