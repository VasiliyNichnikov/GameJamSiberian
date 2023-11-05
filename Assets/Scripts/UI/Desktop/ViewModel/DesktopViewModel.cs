#nullable enable
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Configs;
using ProgramsLogic;
using UniRx;
using UnityEngine;

namespace UI.Desktop.ViewModel
{
    public class DesktopViewModel : IDesktopViewModel
    {
        public IReactiveProperty<IReadOnlyCollection<IProgram>> Programs => _programsProp;

        private readonly ReactiveProperty<IReadOnlyCollection<IProgram>> _programsProp = new ();
        
        private readonly ProgramStorage _storage;
        
        public DesktopViewModel(ProgramStorage storage)
        {
            _storage = storage;
            _storage.OnInstalledProgram += UpdateView;
            _storage.OnUpdatedProgram += UpdateView;
            _storage.OnRemovedProgram += UpdateView;
        }

        private void UpdateView(ProgramType type)
        {
            _programsProp.Value = _storage.Programs;
        }
        
        public void Dispose()
        {
            _storage.OnInstalledProgram -= UpdateView;
            _storage.OnUpdatedProgram -= UpdateView;
            _storage.OnRemovedProgram -= UpdateView;
        }
    }
}