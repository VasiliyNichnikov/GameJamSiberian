#nullable enable
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Configs;
using UniRx;
using UnityEngine;

namespace UI.Desktop.ViewModel
{
    public class DesktopViewModel : IDesktopViewModel
    {
        public IReactiveProperty<IReadOnlyCollection<IProgramIconViewModel>> Programs => _programs;

        private readonly ReactiveProperty<IReadOnlyCollection<IProgramIconViewModel>> _programs = new ();
        private readonly List<ProgramIconViewModel> _viewModels = new ();
        
        private readonly ProgramStorage _storage;
        
        public DesktopViewModel(ProgramStorage storage)
        {
            _storage = storage;
            _storage.OnInstalledProgram += OnInstalledProgram;
            _storage.OnUpdatedProgram += OnUpdatedProgram;
            _storage.OnRemovedProgram += OnRemovedProgram;
        }

        private void OnInstalledProgram(ProgramType type)
        {
            if(!_storage.TryGetLoadedProgram(type, out var result))
            {
                Debug.LogError("DesktopViewModel.OnInstalledProgram: not found program");
                return;
            }

            _viewModels.Add(new ProgramIconViewModel(result));
            _programs.Value = _viewModels.Cast<IProgramIconViewModel>().ToList();
        }

        private void OnUpdatedProgram(ProgramType type)
        {
            if(!_storage.TryGetLoadedProgram(type, out var result))
            {
                Debug.LogError("DesktopViewModel.OnUpdatedProgram: not found program");
                return;
            }

            var viewModel = GetProgramViewModel(type);
            viewModel?.UpdateProgram(result);
            _programs.Value = _viewModels.Cast<IProgramIconViewModel>().ToList();
        }

        private void OnRemovedProgram(ProgramType type)
        {
            if(!_storage.TryGetLoadedProgram(type, out var result))
            {
                Debug.LogError("DesktopViewModel.OnRemovedProgram: not found program");
                return;
            }

            var viewModel = GetProgramViewModel(type);
            if (viewModel != null)
            {
                _viewModels.Remove(viewModel);
            }
            _programs.Value = _viewModels.Cast<IProgramIconViewModel>().ToList();
        }

        private ProgramIconViewModel? GetProgramViewModel(ProgramType programType)
        {
            var viewModel = _viewModels.FirstOrDefault(info => info.Type == programType);
            if (viewModel == null)
            {
                Debug.LogError($"DesktopViewModel.GetProgramViewModel: {viewModel}");
                return null;
            }

            return viewModel;
        }
        
        public void Dispose()
        {
            _storage.OnInstalledProgram -= OnInstalledProgram;
            _storage.OnUpdatedProgram -= OnUpdatedProgram;
            _storage.OnRemovedProgram -= OnRemovedProgram;
        }
    }
}