#nullable enable
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class DeselectTogglesViewModel : IDeselectTogglesViewModel
    {
        public string TitleText { get; }
        public string DescriptionText { get; }

        public IReactiveProperty<bool> IsButtonVisible => _isButtonVisible;
        public IReadOnlyCollection<IDeselectToggleBlockViewModel> Toggles => _toggles;

        private readonly ReactiveProperty<bool> _isButtonVisible = new ReactiveProperty<bool>();
        private readonly List<DeselectToggleViewModel> _toggles = new List<DeselectToggleViewModel>();

        public DeselectTogglesViewModel()
        {
            var data = DataHelper.Instance.InstallerData.GetDeselectTogglesData();
            var togglesData = data.TogglesData;
            TitleText = data.TitleText;
            DescriptionText = data.DescriptionText;
            foreach (var item in togglesData)
            {
                _toggles.Add(new DeselectToggleViewModel(item.Description, CheckLevelExecution));
            }
        }

        private void CheckLevelExecution()
        {
            _isButtonVisible.Value = _toggles.All(toggle => !toggle.OnChangeToggle.Value);
        }
        
    }
}