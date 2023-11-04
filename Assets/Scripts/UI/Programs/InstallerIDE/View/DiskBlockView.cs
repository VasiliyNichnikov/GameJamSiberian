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
        [SerializeField] private CanvasGroup _canvasGroup = null!;

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
            if (isSelected)
                Debug.Log("yes");
            else
                Debug.Log("no");
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            _viewModel.OnClickHandler();
        }

    }
}