#nullable enable
using UI.Programs.Messenger.ViewModel;
using UniRx;
using UnityEngine;
using Utils;

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
            gameObject.UpdateViewModelWithDisposable(ref _viewModel, viewModel);

            gameObject.Subscribe(_viewModel.IsLoginState, isActive =>
            {
                _loginView.gameObject.SetActive(isActive);
                if (isActive)
                {
                    _loginView.Init(_viewModel.LoginViewModel);
                }
            });

            gameObject.Subscribe(_viewModel.IsChatState, isActive =>
            {
                _chatHolder.SetActive(isActive);
                if (isActive)
                {
                    _leftPanel.Init(_viewModel.LeftPanelViewModel);
                    _chatView.Init(_viewModel.ChatViewModel);
                }
            });
        }
    }
}