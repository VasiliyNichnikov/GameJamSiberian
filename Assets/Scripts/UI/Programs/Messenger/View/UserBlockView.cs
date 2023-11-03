#nullable enable
using UI.Programs.Messenger.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.Messenger.View
{
    public class UserBlockView : MonoBehaviour
    {
        [SerializeField] private Text _nameUser = null!;
        [SerializeField] private Image _iconUser = null!;

        private IUserBlockViewModel _viewModel = null!;
        
        public void Init(IUserBlockViewModel viewModel)
        {
            _viewModel = viewModel;
            _iconUser.sprite = viewModel.Icon;
            _nameUser.text = viewModel.NameUser;
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnClickButton()
        {
            _viewModel.OnClickHandler();
        }
    }
}