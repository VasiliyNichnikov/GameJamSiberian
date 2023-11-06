#nullable enable
using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;

namespace UI.Programs.TrelloMiniGame
{
    public class TrelloMiniGameManager : ITrelloMiniGameManager
    {
        // Номер колонки и привязанные к ней задачи
        // Хранит все задачи и колонки в нужном расположение
        private readonly Dictionary<int, List<int>> _tasks = new();

        /// <summary>
        /// Ключ - id задачи
        /// Значение - данные о задаче
        /// </summary>
        private readonly Dictionary<int, TrelloMiniGameData.TaskData> _tasksData = new Dictionary<int, TrelloMiniGameData.TaskData>();

        public bool IsCompleted { get; private set; }
        private TrelloMiniGameData _data = null!;

        public TrelloMiniGameManager() => InitializeData();

        public IReadOnlyCollection<int> GetCurrentLocationOfTasks(int columnIndex) => _tasks[columnIndex];
        public TrelloMiniGameData.TaskData GetTaskDataById(int taskId) => _tasksData[taskId];

        public TrelloMiniGameData.ColumnData FirstColumnData => _data.FirstColumnData;
        public TrelloMiniGameData.ColumnData SecondColumnData => _data.SecondColumnData;
        public TrelloMiniGameData.ColumnData ThirdColumnData => _data.ThirdColumnData;
        public TrelloMiniGameData.ColumnData FourthColumnData => _data.FourthColumnData;

        /// <summary>
        /// Считаем что вся валидация сделана на шаге ниже
        /// </summary>
        public void OnChangeTaskColumn(int currentColumnIndex, int nextColumnIndex, int taskId)
        {
            var currentColumn = _tasks[currentColumnIndex];
            currentColumn.Remove(taskId);

            var nextColumn = _tasks[nextColumnIndex];
            nextColumn.Add(taskId);
        }

        private void InitializeData()
        {
            _data = DataHelper.Instance.TrelloMiniGameData;

            InitializeSelectedColumn(0, _data.FirstColumnData);
            InitializeSelectedColumn(1, _data.SecondColumnData);
            InitializeSelectedColumn(2, _data.ThirdColumnData);
            InitializeSelectedColumn(3, _data.FourthColumnData);
        }

        public void OnCompleteMiniGame()
        {
            if (IsCompleted)
            {
                Debug.LogError("TrelloMiniGameManager.OnCompleteMiniGame: miniGame is already completed");
                return;
            }
            
            IsCompleted = true;
        }
        
        private void InitializeSelectedColumn(int columnIndex, TrelloMiniGameData.ColumnData data)
        {
            var taskIds = new List<int>();
            var tasksList = data.Tasks.ToList();
            for (var i = 0; i < tasksList.Count; i++)
            {
                var id = columnIndex * 100 + i;
                _tasksData.Add(id, tasksList[i]);
                taskIds.Add(id);
            }

            _tasks.Add(columnIndex, taskIds);
        }
    }
}