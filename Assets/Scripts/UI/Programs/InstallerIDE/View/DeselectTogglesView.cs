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

        private IDeselectTogglesViewModel _viewModel = null!;
        
        public void Init(IDeselectTogglesViewModel viewModel)
        {
            _viewModel = viewModel;
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
    }
}