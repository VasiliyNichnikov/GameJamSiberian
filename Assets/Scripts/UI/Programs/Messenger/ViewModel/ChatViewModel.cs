using System.Collections.Generic;
using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public class ChatViewModel : IChatViewModel
    {
        public IReactiveProperty<IReadOnlyCollection<SentMessage>> SentMessages => _sentMessages;

        private readonly ReactiveProperty<IReadOnlyCollection<SentMessage>> _sentMessages = new();
        private readonly MessengerFacade _facade;

        public ChatViewModel(MessengerFacade facade)
        {
            _facade = facade;
            _facade.OnChatSelected += UpdateMessages;
        }

        private void UpdateMessages(IReadOnlyCollection<SentMessage> messages) => _sentMessages.Value = messages;

        public void Dispose() => _facade.OnChatSelected -= UpdateMessages;
    }
}