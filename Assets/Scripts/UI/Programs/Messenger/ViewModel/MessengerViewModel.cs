using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public class MessengerViewModel : IMessengerViewModel
    {
        private enum PageState
        {
            Login,
            Chat
        }

        public IReactiveProperty<bool> IsLoginState => _isLoginState;
        public IReactiveProperty<bool> IsChatState => _isChatState;
        
        public IMessengerLoginViewModel LoginViewModel => _loginViewModel;
        public ILeftPanelViewModel LeftPanelViewModel => _leftPanelViewModel;
        public IChatViewModel ChatViewModel => _chatViewModel;

        private readonly ReactiveProperty<bool> _isLoginState = new ReactiveProperty<bool>();
        private readonly ReactiveProperty<bool> _isChatState = new ReactiveProperty<bool>();

        private readonly MessengerLoginViewModel _loginViewModel;
        private readonly LeftPanelViewModel _leftPanelViewModel;
        private readonly ChatViewModel _chatViewModel;
        
        public MessengerViewModel(MessengerManager manager)
        {
            _loginViewModel = new MessengerLoginViewModel(() =>
            {
                SetPage(PageState.Chat);
                manager.EndLogin();
            });
            _leftPanelViewModel = new LeftPanelViewModel(manager);
            _chatViewModel = new ChatViewModel(manager);

            SetPage(manager.State == MessengerState.Blocked ? PageState.Login : PageState.Chat);
        }

        private void SetPage(PageState state)
        {
            _isChatState.Value = state == PageState.Chat;
            _isLoginState.Value = state == PageState.Login;
        }

        public void Dispose()
        {
            _chatViewModel?.Dispose();
        }
    }
}