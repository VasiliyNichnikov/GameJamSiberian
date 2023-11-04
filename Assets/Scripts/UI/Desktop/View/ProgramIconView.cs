#nullable enable
using UI.Desktop.ViewModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Desktop.View
{
    public class ProgramIconView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _icon = null!;
        [SerializeField] private Text _name = null!;
        [SerializeField] private GameObject _selectionIcon = null!;

        private IProgramIconViewModel _viewModel = null!;
        
        public void Init(IProgramIconViewModel viewModel)
        {
            _viewModel = viewModel;

            _name.text = _viewModel.Name;
            _icon.sprite = _viewModel.Icon;
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnClickButton()
        {
            _viewModel.OnClickHandler();
        }

        public void OnPointerEnter(PointerEventData eventData) => _selectionIcon.SetActive(true);

        public void OnPointerExit(PointerEventData eventData) => _selectionIcon.SetActive(false);
    }
}