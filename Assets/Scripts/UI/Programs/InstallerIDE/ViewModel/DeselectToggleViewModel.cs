#nullable enable
using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class DeselectToggleViewModel : IDeselectToggleBlockViewModel
    {
        public string Description { get; }
        
        public IReactiveProperty<bool> OnChangeToggle => _onChangeToggle;

        private readonly ReactiveProperty<bool> _onChangeToggle = new ReactiveProperty<bool>();

        public DeselectToggleViewModel(string description)
        {
            Description = description;
            _onChangeToggle.Value = true;
        }

        public void OnToggleClickHandler()
        {
            _onChangeToggle.Value = !_onChangeToggle.Value;
        }
    }
}