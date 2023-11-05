#nullable enable
using UI.Programs.Messenger.ViewModel;
using UniRx;
using UnityEngine;

namespace UI.Programs.Messenger.View
{
    public class MessengerDialog : BaseDialog
    {
        [SerializeField] private MessengerLoginView _loginView = null!;
        [SerializeField] private GameObject _chatHolder = null!;
        [SerializeField] private LeftPanelView _leftPanel = null!;
        [SerializeField] private ChatView _chatView = null!;
        
        private IMessengerViewModel _viewModel = null!;
        
        public void Init(IMessengerViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.IsLoginState.ObserveEveryValueChanged(x => x.Value).Subscribe(isActive =>
            {
                _loginView.gameObject.SetActive(isActive);
                if (isActive)
                {
                    _loginView.Init(_viewModel.LoginViewModel);
                }
            });
            
            _viewModel.IsChatState.ObserveEveryValueChanged(x => x.Value).Subscribe(isActive =>
            {
                _chatHolder.SetActive(isActive);
                if (isActive)
                {
                    _leftPanel.Init(_viewModel.LeftPanelViewModel);
                    _chatView.Init(_viewModel.ChatViewModel);
                }
            });
        }

        public override void Dispose()
        {
            _viewModel.Dispose();
            _chatView.Dispose();
        }
    }
}