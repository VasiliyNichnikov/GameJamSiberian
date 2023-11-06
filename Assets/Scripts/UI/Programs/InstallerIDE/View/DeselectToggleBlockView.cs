#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.InstallerIDE.View
{
    public class DeselectToggleBlockView : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle = null!;
        [SerializeField] private Text _description = null!;

        private IDeselectToggleBlockViewModel _viewModel = null!;
        
        public void Init(IDeselectToggleBlockViewModel viewModel)
        {
            gameObject.UpdateViewModel(ref _viewModel, viewModel);
            gameObject.Subscribe(_viewModel.OnChangeToggle, ChangeValue);
            _description.text = _viewModel.Description;
            
            _toggle.onValueChanged.AddListener(OnToggleClicked);
        }
        
        private void OnToggleClicked(bool isOn) => _viewModel.OnToggleClickHandler(); // 1
        
        private void ChangeValue(bool value) => _toggle.isOn = value; // 3 
    }
}