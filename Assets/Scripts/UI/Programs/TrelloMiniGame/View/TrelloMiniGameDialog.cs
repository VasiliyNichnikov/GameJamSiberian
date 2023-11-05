﻿#nullable enable
using System.Collections.Generic;
using UI.Programs.TrelloMiniGame.ViewModel;
using UniRx;
using UnityEngine;

namespace UI.Programs.TrelloMiniGame.View
{
    public class TrelloMiniGameDialog : BaseDialog
    {
        [SerializeField] private List<TrelloColumnView> _columnViews = null!;
        [SerializeField] private GameObject _saveButtonObject = null!;
        
        private ITrelloMiniGameViewModel _viewModel = null!;
        
        public void Init(ITrelloMiniGameViewModel viewModel)
        {
            _viewModel = viewModel;

            Debug.Assert(_viewModel.Columns.Count == _columnViews.Count, "The number of columns and models does not match");
            for (var i = 0; i < _viewModel.Columns.Count; i++)
            {
                _columnViews[i].Init(_viewModel.Columns[i]);
            }

            _viewModel.IsCompleted.ObserveEveryValueChanged(x => x.Value).Subscribe(isActive => _saveButtonObject.SetActive(!isActive));
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void TryToSaveDataButton()
        {
            _viewModel.OnClickSaveDataHandler();
        }
    }
}