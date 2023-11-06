#nullable enable
using System;
using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class DeselectToggleViewModel : IDeselectToggleBlockViewModel
    {
        public string Description { get; }
        
        public IReactiveProperty<bool> OnChangeToggle => _onChangeToggle;

        private readonly ReactiveProperty<bool> _onChangeToggle = new ReactiveProperty<bool>();

        private readonly Action _onAdditionClickHandler;
        public DeselectToggleViewModel(string description, Action onAdditionClickHandler)
        {
            Description = description;
            _onChangeToggle.Value = true;
            _onAdditionClickHandler = onAdditionClickHandler;
        }

        public void OnToggleClickHandler()
        {
            _onChangeToggle.Value = !_onChangeToggle.Value;
            _onAdditionClickHandler?.Invoke();
        }
    }
}