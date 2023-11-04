#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.InstallerIDE.View
{
    public class DeselectToggleBlockView : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle = null!;
        [SerializeField] private Text _description = null!;

        private IDeselectToggleBlockViewModel _viewModel = null!;
        
        public void Init(IDeselectToggleBlockViewModel viewModel)
        {
            _viewModel = viewModel;
            _description.text = _viewModel.Description;
            _viewModel.OnChangeToggle.ObserveEveryValueChanged(x => x.Value).Subscribe(ChangeValue);
            _toggle.onValueChanged.AddListener(OnToggleClicked);
        }
        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnToggleClicked(bool isOn) => _viewModel.OnToggleClickHandler();
        
        private void ChangeValue(bool value) => _toggle.isOn = value;
    }
}