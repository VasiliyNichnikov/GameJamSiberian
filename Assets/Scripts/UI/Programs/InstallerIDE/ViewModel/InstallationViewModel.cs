#nullable enable
using System;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class InstallationViewModel : IInstallationViewModel
    {
        public string TitleText { get; }
        public string DescriptionText { get; }

        private readonly Action _onCompletingInstallation;
        
        public InstallationViewModel(Action onCompletingInstallation)
        {
            var simulationInstallationData = DataHelper.Instance.InstallerData.GetSimulationInstallationData();
            TitleText = simulationInstallationData.TitleText;
            DescriptionText = simulationInstallationData.DescriptionText;
            _onCompletingInstallation = onCompletingInstallation;
        }
        
        public void OnClickCloseHandler()
        {
            _onCompletingInstallation.Invoke();
        }
    }
}