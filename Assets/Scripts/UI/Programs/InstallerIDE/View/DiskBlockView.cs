#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

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
            gameObject.UpdateViewModel(ref _viewModel, viewModel);
            gameObject.Subscribe(_viewModel.IsSelected, OnSelectedDisk);
            
            _nameDisk.text = _viewModel.NameDisk;
            _amountOfSpace.text = _viewModel.AmountOfSpace;
            _spaceSlider.value = _viewModel.OccupiedSpace;
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