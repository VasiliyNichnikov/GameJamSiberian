#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Programs.InstallerIDE.View
{
    public class DiskBlockView : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Text _nameDisk = null!;
        [SerializeField] private Text _amountOfSpace = null!;
        [SerializeField] private Slider _spaceSlider = null!;
        [SerializeField] private GameObject _selectableObject = null!;

        private IDiskBlockViewModel _viewModel = null!;

        public void Init(IDiskBlockViewModel viewModel)
        {
            _viewModel = viewModel;
            _nameDisk.text = _viewModel.NameDisk;
            _amountOfSpace.text = _viewModel.AmountOfSpace;
            _spaceSlider.value = _viewModel.OccupiedSpace;
            _viewModel.IsSelected.ObserveEveryValueChanged(x => x.Value).Subscribe(OnSelectedDisk);
        }

        private void OnSelectedDisk(bool isSelected)
        {
            _selectableObject.SetActive(isSelected);
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            _viewModel.OnClickHandler();
        }

    }
}