#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.InstallerIDE.View
{
    public class DeselectTogglesView : MonoBehaviour
    {
        [SerializeField] private Text _description = null!;
        [SerializeField] private RectTransform _togglesHolder = null!;
        [SerializeField] private DeselectToggleBlockView _deselectToggleBlockPrefab = null!;
        [SerializeField] private Button _continueButton = null!;

        private IDeselectTogglesViewModel _viewModel = null!;
        
        public void Init(IDeselectTogglesViewModel viewModel)
        {
            gameObject.UpdateViewModel(ref _viewModel, viewModel);
            gameObject.Subscribe(_viewModel.OnAllDeselected, SetInteractableButton);
            _description.text = _viewModel.DescriptionText;
            CreateDeselectToggles();
        }
        
        private void CreateDeselectToggles()
        {
            _togglesHolder.DestroyChildren();
            foreach (var viewModel in _viewModel.Toggles)
            {
                var view = Instantiate(_deselectToggleBlockPrefab, _togglesHolder, false);
                view.Init(viewModel);
            }
        }

        private void SetInteractableButton(bool value) => _continueButton.interactable = value;
    }
}