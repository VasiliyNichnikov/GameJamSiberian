#nullable enable
using UI.Programs.Messenger.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.Messenger.View
{
    public class UserBlockView : MonoBehaviour
    {
        [SerializeField] private Text _nameUser = null!;
        [SerializeField] private Image _iconUser = null!;
        [SerializeField] private GameObject _selectableImage = null!;
        
        private IUserBlockViewModel _viewModel = null!;
        
        public void Init(IUserBlockViewModel viewModel)
        {
            gameObject.UpdateViewModel(ref _viewModel, viewModel);
            _iconUser.sprite = viewModel.Icon;
            _nameUser.text = viewModel.NameUser;

            gameObject.Subscribe(_viewModel.IsSelected, isSelected =>
            {
                _selectableImage.SetActive(isSelected);
            });
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