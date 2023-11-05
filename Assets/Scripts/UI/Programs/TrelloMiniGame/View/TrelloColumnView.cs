#nullable enable
using System.Collections.Generic;
using System.Linq;
using Pool;
using UI.Programs.TrelloMiniGame.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.TrelloMiniGame.View
{
    public class TrelloColumnView : MonoBehaviour
    {
        [SerializeField] private Text _title = null!;
        [SerializeField] private RectTransform _columnHolder = null!;
        [SerializeField] private TrelloTaskView _taskViewPrefab = null!;
        
        private ITrelloColumnViewModel _viewModel = null!;

        private TrelloTasksPool _pool = null!;
        private readonly List<TrelloTaskView> _taskViews = new List<TrelloTaskView>();

        public void Init(ITrelloColumnViewModel viewModel)
        {
            _pool = new TrelloTasksPool(_columnHolder, _taskViewPrefab);
            _title.text = viewModel.TitleColumn;
            _viewModel = viewModel;
            _viewModel.Tasks.ObserveEveryValueChanged(x => x.Value).Subscribe(CreateTasks);
        }

        private void CreateTasks(IReadOnlyCollection<ITrelloTaskViewModel> tasks)
        {
            // Убираем в пул и отключаем
            foreach (var task in _taskViews.Where(view => view.isActiveAndEnabled))
            {
                task.RemoveToPool();
            }
            foreach (var taskViewModel in tasks)
            {
                var view = _pool.GetOrCreateTask();
                view.Init(taskViewModel);
                _taskViews.Add(view);
            }
        }

        private void OnDestroy()
        {
            TryClearTasks();
        }

        private void TryClearTasks()
        {
            _taskViews.Clear();
            _columnHolder.DestroyChildren();
        }
    }
}