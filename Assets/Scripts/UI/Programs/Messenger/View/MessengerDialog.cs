#nullable enable
using UI.Programs.Messenger.ViewModel;
using UnityEngine;

namespace UI.Programs.Messenger.View
{
    public class MessengerDialog : BaseDialog
    {
        [SerializeField] private LeftPanelView _leftPanel = null!;
        [SerializeField] private ChatView _chatView = null!;
        
        private IMessengerViewModel _viewModel = null!;
        
        public void Init(IMessengerViewModel viewModel)
        {
            _viewModel = viewModel;

            _leftPanel.Init(_viewModel.LeftPanelViewModel);
            _chatView.Init(_viewModel.ChatViewModel);
        }

        public override void Dispose()
        {
            _viewModel.Dispose();
        }
    }
}