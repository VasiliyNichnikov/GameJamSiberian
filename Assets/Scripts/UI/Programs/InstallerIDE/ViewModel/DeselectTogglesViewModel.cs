#nullable enable
using System.Collections.Generic;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class DeselectTogglesViewModel : IDeselectTogglesViewModel
    {
        public string TitleText { get; }
        public string DescriptionText { get; }
        public IReadOnlyCollection<IDeselectToggleBlockViewModel> Toggles => _toggles;
        
        private readonly List<DeselectToggleViewModel> _toggles = new List<DeselectToggleViewModel>();

        public DeselectTogglesViewModel()
        {
            var data = DataHelper.Instance.InstallerData.GetDeselectTogglesData();
            var togglesData = data.TogglesData;
            TitleText = data.TitleText;
            DescriptionText = data.DescriptionText;
            foreach (var item in togglesData)
            {
                _toggles.Add(new DeselectToggleViewModel(item.Description));
            }
        }

        public List<DeselectToggleViewModel> GetToggles()
        {
            return _toggles;
        }
    }
}