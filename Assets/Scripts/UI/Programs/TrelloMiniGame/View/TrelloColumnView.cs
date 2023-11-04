#nullable enable
using System.Collections.Generic;
using System.Linq;
using Pool;
using UI.Programs.TrelloMiniGame.ViewModel;
using UniRx;
using UnityEngine;
using Utils;

namespace UI.Programs.TrelloMiniGame.View
{
    public class TrelloColumnView : MonoBehaviour
    {
        [SerializeField] private RectTransform _columnHolder = null!;
        [SerializeField] private TrelloTaskView _taskViewPrefab = null!;

        private TrelloArrowsManager _trelloArrowsManager = null!;
        private ITrelloColumnViewModel _viewModel = null!;

        private TrelloTasksPool _pool = null!;
        private readonly List<TrelloTaskView> _taskViews = new List<TrelloTaskView>();

        public void Init(ITrelloColumnViewModel viewModel, TrelloArrowsManager trelloArrowsManager)
        {
            _pool = new TrelloTasksPool(_columnHolder, _taskViewPrefab);
            _trelloArrowsManager = trelloArrowsManager;
            _viewModel = viewModel;
            _viewModel.Tasks.ObserveEveryValueChanged(x => x.Value).Subscribe(CreateTasks);
        }

        private void CreateTasks(IReadOnlyCollection<ITrelloTaskViewModel> tasks)
        {
            // Убираем в пул и отключаем
            foreach (var task in _taskViews.Where(view => view.isActiveAndEnabled))
            {
                task.RemoveToPool();
                task.Dispose();
            }
            foreach (var taskViewModel in tasks)
            {
                var view = _pool.GetOrCreateTask();
                view.Init(taskViewModel, _trelloArrowsManager);
                _taskViews.Add(view);
            }
        }

        private void OnDestroy()
        {
            TryClearTasks();
        }

        private void TryClearTasks()
        {
            if (_taskViews.Count != 0)
            {
                foreach (var taskView in _taskViews)
                {
                    taskView.Dispose();
                }
            }
            _taskViews.Clear();
            _columnHolder.DestroyChildren();
        }
    }
}