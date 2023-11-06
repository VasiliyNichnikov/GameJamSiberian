#nullable enable
using UI.Programs.Messenger.ViewModel;
using UnityEngine;
using Utils;

namespace UI.Programs.Messenger.View
{
    public class LeftPanelView : MonoBehaviour
    {
        [SerializeField] private RectTransform _userBlocksHolder = null!;
        [SerializeField] private UserBlockView _userBlockPrefab = null!;
        
        private ILeftPanelViewModel _viewModel = null!;
        
        public void Init(ILeftPanelViewModel viewModel)
        {
            gameObject.UpdateViewModel(ref _viewModel, viewModel);
            CreateUserBlocks();
        }

        private void CreateUserBlocks()
        {
            foreach (var viewModel in _viewModel.UsersViewModel)
            {
                var view = Instantiate(_userBlockPrefab, _userBlocksHolder, false);
                view.Init(viewModel);
            }
        }
    }
}