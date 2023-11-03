namespace UI.Programs.Messenger.ViewModel
{
    public class MessengerViewModel : IMessengerViewModel
    {
        public ILeftPanelViewModel LeftPanelViewModel => _leftPanelViewModel;
        public IChatViewModel ChatViewModel => _chatViewModel;

        private readonly LeftPanelViewModel _leftPanelViewModel;
        private readonly ChatViewModel _chatViewModel;
        
        public MessengerViewModel(MessengerFacade facade)
        {
            _leftPanelViewModel = new LeftPanelViewModel(facade);
            _chatViewModel = new ChatViewModel(facade);
        }

        public void Dispose()
        {
            _chatViewModel?.Dispose();
        }
    }
}