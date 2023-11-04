﻿#nullable enable
using System.Collections.Generic;
using UI.Desktop.ViewModel;
using UniRx;
using UnityEngine;

namespace UI.Desktop.View
{
    public class DesktopDialog : BaseDialog
    {
        [SerializeField] private RectTransform _iconsHolder = null!;
        [SerializeField] private ProgramIconView _programIconPrefab = null!;

        private IDesktopViewModel _viewModel = null!;
        
        public void Init(IDesktopViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.Programs.ObserveEveryValueChanged(x => x.Value).Subscribe(CreateIcons);
        }

        private void CreateIcons(IReadOnlyCollection<IProgramIconViewModel>? viewModels)
        {
            if (viewModels == null)
            {
                return;
            }
            
            foreach (var viewModel in viewModels)
            {
                var view = Instantiate(_programIconPrefab, _iconsHolder, false);
                view.Init(viewModel);
            }
        }

        public override void Dispose()
        {
            _viewModel.Dispose();
        }
    }
}