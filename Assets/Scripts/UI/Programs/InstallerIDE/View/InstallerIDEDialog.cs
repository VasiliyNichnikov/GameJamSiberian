#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

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
            gameObject.UpdateViewModel(ref _viewModel, viewModel);
            gameObject.Subscribe(_viewModel.IsWelcomeState, isActive =>
            {
                _welcomeView.gameObject.SetActive(isActive);
                if (isActive)
                {
                    _titleWindow.text = _viewModel.WelcomeViewModel.Title;
                    _welcomeView.Init(_viewModel.WelcomeViewModel);
                }
            });

            gameObject.Subscribe(_viewModel.IsSelectionDiskState, isActive =>
            {
                _diskSelectionView.gameObject.SetActive(isActive);
                if (isActive)
                {
                    _titleWindow.text = _viewModel.DiskSelectionViewModel.Title;
                    _diskSelectionView.Init(_viewModel.DiskSelectionViewModel);
                }
            });

            gameObject.Subscribe(_viewModel.IsDeselectTogglesState, isActive =>
            {
                _deselectToggles.gameObject.SetActive(isActive);
                if (isActive)
                {
                    _titleWindow.text = _viewModel.DeselectTogglesViewModel.TitleText;
                    _deselectToggles.Init(_viewModel.DeselectTogglesViewModel);
                }
            });

            gameObject.Subscribe(_viewModel.IsInstallationState, isActive =>
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