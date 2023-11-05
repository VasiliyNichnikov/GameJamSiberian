namespace UI.Programs.Messenger.ViewModel
{
    public class MessengerViewModel : IMessengerViewModel
    {
        public ILeftPanelViewModel LeftPanelViewModel => _leftPanelViewModel;
        public IChatViewModel ChatViewModel => _chatViewModel;

        private readonly LeftPanelViewModel _leftPanelViewModel;
        private readonly ChatViewModel _chatViewModel;
        
        public MessengerViewModel(MessengerManager manager)
        {
            _leftPanelViewModel = new LeftPanelViewModel(manager);
            _chatViewModel = new ChatViewModel(manager);
        }

        public void Dispose()
        {
            _chatViewModel?.Dispose();
        }
    }
}