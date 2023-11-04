#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.InstallerIDE.View
{
    public class InstallerIDEDialog : BaseDialog
    {
        [SerializeField] private Text _titleWindow = null!;
        [SerializeField] private WelcomeView _welcomeView = null!;
        [SerializeField] private DiskSelectionView _diskSelectionView = null!;
        [SerializeField] private DeselectTogglesView _deselectToggles = null!;
        [SerializeField] private InstallationView _installationView = null!;
        
        private IInstallerIDEViewModel _viewModel = null!;
        
        public void Init(IInstallerIDEViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.IsWelcomeState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(isActive =>
                {
                    _welcomeView.gameObject.SetActive(isActive);
                    if (isActive)
                    {
                        _titleWindow.text = _viewModel.WelcomeViewModel.Title;
                        _welcomeView.Init(_viewModel.WelcomeViewModel);
                    }
                });
            
            _viewModel.IsSelectionDiskState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(isActive =>
                {
                    _diskSelectionView.gameObject.SetActive(isActive);
                    if (isActive)
                    {
                        _titleWindow.text = _viewModel.DiskSelectionViewModel.Title;
                        _diskSelectionView.Init(_viewModel.DiskSelectionViewModel);
                    }
                });
            
            _viewModel.IsDeselectTogglesState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(isActive =>
                {
                    _deselectToggles.gameObject.SetActive(isActive);
                    if (isActive)
                    {
                        _titleWindow.text = _viewModel.DeselectTogglesViewModel.TitleText;
                        _deselectToggles.Init(_viewModel.DeselectTogglesViewModel);
                    }
                });
            
            _viewModel.IsInstallationState.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(isActive =>
                {
                    _installationView.gameObject.SetActive(isActive);
                    if (isActive)
                    {
                        _titleWindow.text = _viewModel.InstallationViewModel.TitleText;
                        _installationView.Init(_viewModel.InstallationViewModel);
                    }
                });
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnContinueButtonClick()
        {
            _viewModel.OnContinueClickHandler();
        }
    }
}