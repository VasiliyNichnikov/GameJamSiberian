using System.Collections.Generic;
using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public class ChatViewModel : IChatViewModel
    {
        public IReactiveProperty<IReadOnlyCollection<SentMessage>> SentMessages => _sentMessages;

        private readonly ReactiveProperty<IReadOnlyCollection<SentMessage>> _sentMessages = new();
        private readonly MessengerManager _manager;

        public ChatViewModel(MessengerManager manager)
        {
            _manager = manager;
            _manager.OnChatSelected += UpdateMessages;
        }

        private void UpdateMessages(IReadOnlyCollection<SentMessage> messages) => _sentMessages.Value = messages;

        public void Dispose() => _manager.OnChatSelected -= UpdateMessages;
    }
}