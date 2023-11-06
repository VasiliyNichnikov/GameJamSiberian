#nullable enable
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

        private readonly ReactiveProperty<bool> _isCompleted = new ();
        private readonly List<TrelloColumnViewModel> _columns = new();
        
        private readonly TrelloMiniGameManager _trelloManager;
        
        public TrelloMiniGameViewModel(TrelloMiniGameManager trelloManager)
        {
            _trelloManager = trelloManager;
            _columns.Add(new TrelloColumnViewModel(trelloManager.FirstColumnData, trelloManager,this, 0));
            _columns.Add(new TrelloColumnViewModel(trelloManager.SecondColumnData, trelloManager,this, 1));
            _columns.Add(new TrelloColumnViewModel(trelloManager.ThirdColumnData, trelloManager,this, 2));
            _columns.Add(new TrelloColumnViewModel(trelloManager.FourthColumnData, trelloManager,this, 3));

            _isCompleted.Value = trelloManager.IsCompleted;
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

            _trelloManager.OnChangeTaskColumn(currentColumnIndex, nextColumnIndex, taskViewModel.TaskId);
        }
        
        
        public void OnClickSaveDataHandler()
        {
            if (_columns.All(column => column.IsLocationTasksCorrected))
            {
                _trelloManager.OnCompleteMiniGame();
                _isCompleted.Value = true;
            }
            else
            {
                // TODO в доработках
                Debug.LogWarning("TrelloMiniGameViewModel:OnClickSaveDataHandler: need show error");
            }
        }
    }
}