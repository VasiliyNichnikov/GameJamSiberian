#nullable enable
using System;
using System.Linq;
using UniRx;
using UnityEngine;
using Utils;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class InstallerIDEViewModel : IInstallerIDEViewModel
    {
        private enum PageState
        {
            Welcome,
            SelectionDisk,
            DeselectToggles,
            Installation,
            Completion
        }

        public IReactiveProperty<bool> IsWelcomeState => _isWelcomeState;
        public IReactiveProperty<bool> IsSelectionDiskState => _isSelectionDiskState;
        public IReactiveProperty<bool> IsDeselectTogglesState => _isDeselectToggles;
        public IReactiveProperty<bool> IsInstallationState => _isInstallationState;
        public IReactiveProperty<bool> IsCompletionState => _isCompletion;
        public IWelcomeViewModel WelcomeViewModel => _welcomeViewModel;
        public IDiskSelectionViewModel DiskSelectionViewModel => _diskSelectionViewModel;
        public IDeselectTogglesViewModel DeselectTogglesViewModel => _deselectTogglesViewModel;
        public IInstallationViewModel InstallationViewModel => _installationViewModel;

        private readonly ReactiveProperty<bool> _isWelcomeState = new ();
        private readonly ReactiveProperty<bool> _isSelectionDiskState = new ();
        private readonly ReactiveProperty<bool> _isDeselectToggles = new ();
        private readonly ReactiveProperty<bool> _isInstallationState = new ();
        private readonly ReactiveProperty<bool> _isCompletion = new ();

        private readonly WelcomeViewModel _welcomeViewModel;
        private readonly DiskSelectionViewModel _diskSelectionViewModel;
        private readonly DeselectTogglesViewModel _deselectTogglesViewModel;
        private readonly InstallationViewModel _installationViewModel;
        private PageState _currentState = PageState.Welcome;

        private readonly Action _onHideDialog;
        
        public InstallerIDEViewModel(Action hideDialog)
        {
            _onHideDialog = hideDialog;
            _welcomeViewModel = new WelcomeViewModel();
            _diskSelectionViewModel = new DiskSelectionViewModel();
            _deselectTogglesViewModel = new DeselectTogglesViewModel();
            _installationViewModel = new InstallationViewModel(CompletingInstallation);


            SetPageView(_currentState);
        }
        
        public void OnContinueClickHandler()
        {
            switch (_currentState)
            {
                case PageState.Welcome:
                    _currentState = PageState.SelectionDisk;
                    break;
                case PageState.SelectionDisk:
                    var missionIsCompleteSelectionDisk = _diskSelectionViewModel.GetSelectedDiskState();
                    if (missionIsCompleteSelectionDisk)
                    {
                        _currentState = PageState.DeselectToggles;
                    }
                    else
                    {
                        SimpleDialogsHelper.OpenWarningDialog("Сторож", "Свободное место не найдено");
                    }
                    break;
                case PageState.DeselectToggles:
                    var missionIsCompleteDeselectToggles = _deselectTogglesViewModel.Toggles.All(toggle => !toggle.OnChangeToggle.Value);
                    if (missionIsCompleteDeselectToggles)
                    {
                        _currentState = PageState.Installation;
                    }
                    break;
                default:
                    Debug.LogError(
                        $"InstallerIDEViewModel.OnContinueClickHandler: not supported type: {_currentState}");
                    _currentState = PageState.Welcome;
                    break;
            }

            SetPageView(_currentState);
        }

        private void CompletingInstallation()
        {
            _onHideDialog?.Invoke();
        }
        
        private void SetPageView(PageState state)
        {
            _isWelcomeState.Value = state == PageState.Welcome;
            _isSelectionDiskState.Value = state == PageState.SelectionDisk;
            _isDeselectToggles.Value = state == PageState.DeselectToggles;
            _isInstallationState.Value = state == PageState.Installation;
            _isCompletion.Value = state == PageState.Completion;
        }
    }
}