using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Configs;
using UniRx;

namespace UI.Programs.TrelloMiniGame.ViewModel
{
    public class TrelloColumnViewModel : ITrelloColumnViewModel
    {
        public string TitleColumn { get; }

        /// <summary>
        /// Корректно ли расположены все таски в колонке
        /// </summary>
        public bool IsLocationTasksCorrected => _tasks.All(task => task.IsLocationCorrected);
        public IReactiveProperty<ReadOnlyCollection<ITrelloTaskViewModel>> Tasks => _tasksProp;

        private readonly ReactiveProperty<ReadOnlyCollection<ITrelloTaskViewModel>> _tasksProp = new ();
        private readonly List<TrelloTaskViewModel> _tasks;
        private readonly int _columnNumber;

        public TrelloColumnViewModel(TrelloMiniGameData.ColumnData data, TrelloMiniGameViewModel miniGameViewModel, int columnNumber)
        {
            TitleColumn = data.TitleText;
            _tasks = data.Tasks.Select(taskData => new TrelloTaskViewModel(taskData, miniGameViewModel.OnChangeTaskColumn, columnNumber)).ToList();
            _tasksProp.Value = _tasks.Cast<ITrelloTaskViewModel>().ToList().AsReadOnly();
            _columnNumber = columnNumber;
        }

        public bool TryRemoveTask(TrelloTaskViewModel taskViewModel)
        {
            if(!_tasks.Contains(taskViewModel))
            {
                return false;
            }

            _tasks.Remove(taskViewModel);
            _tasksProp.Value =_tasks.Cast<ITrelloTaskViewModel>().ToList().AsReadOnly();
            return true;
        }

        public bool TryAddTask(TrelloTaskViewModel taskViewModel)
        {
            if(_tasks.Contains(taskViewModel))
            {
                return false;
            }

            _tasks.Add(taskViewModel);
            taskViewModel.SetColumnNumber(_columnNumber);
            _tasksProp.Value =_tasks.Cast<ITrelloTaskViewModel>().ToList().AsReadOnly();
            return true;
        }
    }
}