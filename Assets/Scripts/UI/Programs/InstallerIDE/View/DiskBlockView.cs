#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.InstallerIDE.View
{
    public class DiskBlockView : MonoBehaviour
    {
        [SerializeField] private Text _nameDisk = null!;
        [SerializeField] private Text _amountOfSpace = null!;
        [SerializeField] private Slider _spaceSlider = null!;
        
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
            
        }
    }
}