#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniRx;
using UnityEngine;

namespace UI.Programs.TrelloMiniGame.ViewModel
{
    public class TrelloMiniGameViewModel : ITrelloMiniGameViewModel
    {
        public IReactiveProperty<bool> IsCompleted => _isCompleted;
        public ReadOnlyCollection<ITrelloColumnViewModel> Columns => _columns.Cast<ITrelloColumnViewModel>().ToList().AsReadOnly();

        private readonly ReactiveProperty<bool> _isCompleted = new ReactiveProperty<bool>();
        private readonly List<TrelloColumnViewModel> _columns = new();
        private readonly Action _onHideDialog;
        
        public TrelloMiniGameViewModel(Action hideDialog, bool isCompleted)
        {
            var data = DataHelper.Instance.TrelloMiniGameData;
            _columns.Add(new TrelloColumnViewModel(data.FirstColumnData, this, 0));
            _columns.Add(new TrelloColumnViewModel(data.SecondColumnData, this, 1));
            _columns.Add(new TrelloColumnViewModel(data.ThirdColumnData, this, 2));
            _columns.Add(new TrelloColumnViewModel(data.FourthColumnData, this, 3));

            _isCompleted.Value = isCompleted;
            _onHideDialog = hideDialog;
        }

        public void OnChangeTaskColumn(int currentColumnIndex, int nextColumnIndex, TrelloTaskViewModel taskViewModel)
        {
            if (nextColumnIndex < 0 || nextColumnIndex >= _columns.Count)
            {
                Debug.LogError(
                    $"TrelloMiniGameViewModel.OnChangeTaskColumn: not corrected column index: {nextColumnIndex}");
                return;
            }

            var currentColumn = _columns[currentColumnIndex];
            var nextColumn = _columns[nextColumnIndex];
            if (!currentColumn.TryRemoveTask(taskViewModel))
            {
                Debug.LogError(
                    $"TrelloMiniGameViewModel.OnChangeTaskColumn: Couldn't delete task from column {nextColumnIndex}");
                return;
            }

            if (!nextColumn.TryAddTask(taskViewModel))
            {
                Debug.LogError(
                    $"TrelloMiniGameViewModel.OnChangeTaskColumn: Couldn't add to column {nextColumnIndex}");
            }
        }
        
        public void OnClickSaveDataHandler()
        {
            if (_columns.All(column => column.IsLocationTasksCorrected))
            {
                _onHideDialog.Invoke();
            }
            else
            {
                // TODO в доработках
                Debug.LogWarning("TrelloMiniGameViewModel:OnClickSaveDataHandler: need show error");
            }
        }
    }
}