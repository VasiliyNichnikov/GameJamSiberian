#nullable enable
using System.Collections.Generic;
using ProgramsLogic;
using UI.Desktop.ViewModel;
using UnityEngine;
using Utils;

namespace UI.Desktop.View
{
    public class DesktopDialog : BaseDialog
    {
        public override bool CanCloseWithAllDialogs => false;

        [SerializeField] private RectTransform _iconsHolder = null!;
        [SerializeField] private ProgramIconView _programIconPrefab = null!;

        private IDesktopViewModel _viewModel = null!;
        
        public void Init(IDesktopViewModel viewModel)
        {
            gameObject.UpdateViewModelWithDisposable(ref _viewModel, viewModel);
            gameObject.Subscribe(_viewModel.Programs, CreateIcons);
        }

        private void CreateIcons(IReadOnlyCollection<IProgram>? programs)
        {
            if (programs == null)
            {
                return;
            }

            _iconsHolder.DestroyChildren();
            foreach (var program in programs)
            {
                var view = Instantiate(_programIconPrefab, _iconsHolder, false);
                view.Init(program);
            }
        }
    }
}