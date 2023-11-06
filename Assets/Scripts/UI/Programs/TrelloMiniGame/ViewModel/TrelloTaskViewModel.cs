#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;

namespace UI.Programs.TrelloMiniGame.ViewModel
{
    public class TrelloTaskViewModel : ITrelloTaskViewModel
    {
        public int TaskId { get; }
        public int ColumnNumber { get; private set; }
        public string Title => _data.Title;
        public string Description => _data.Description;
        public string UserName { get; }
        public string UserSurname { get; }
        public Sprite UserIcon { get; }

        // + 1 так как считаем с 1, поэтому правильный ответ на 1 больше
        // выглядет увы как костыль, но пока как есть
        public bool IsLocationCorrected => _data.RightNumberColumn == ColumnNumber + 1;
        
        public IReadOnlyCollection<string> Tags { get; }

        /// <summary>
        /// Обработчик при нажатие на стрелки
        /// Первый int - это текущая колонка
        /// Второй int - в какую колонку нужно перенести
        /// </summary>
        private readonly Action<int, int, TrelloTaskViewModel> _onClickArrowsHandler;

        private readonly TrelloMiniGameData.TaskData _data;
        
        public TrelloTaskViewModel(int taskId, TrelloMiniGameData.TaskData data, Action<int, int, TrelloTaskViewModel> onClickArrowsHandler, int columnNumber)
        {
            _data = data;
            TaskId = taskId;
            ColumnNumber = columnNumber;
            Tags = data.Tags.Select(ConvertTag).ToList();
            var userData = DataHelper.Instance.TrelloMiniGameData.GetUserByType(data.User);
            UserName = userData.Name;
            UserSurname = userData.Surname;
            UserIcon = userData.Icon;

            _onClickArrowsHandler = onClickArrowsHandler;
        }

        /// <summary>
        /// Очень плохо
        /// </summary>
        public void SetColumnNumber(int value)
        {
            ColumnNumber = value;
        }

        public void OnMoveLeftColumnHandler() => _onClickArrowsHandler.Invoke(ColumnNumber, ColumnNumber - 1, this);
        public void OnMoveRightColumnHandler() => _onClickArrowsHandler.Invoke(ColumnNumber, ColumnNumber + 1, this);
        
        private static string ConvertTag(TrelloMiniGameData.TaskTag tag)
        {
            switch (tag)
            {
                case TrelloMiniGameData.TaskTag.UI:
                    return "UI";
                case TrelloMiniGameData.TaskTag.Code:
                    return "CODE";
                case TrelloMiniGameData.TaskTag.Idea:
                    return "IDEA";
                default:
                    Debug.LogError($"TrelloTaskViewModel.ConvertTag: not corrected type: {tag}");
                    return "UNKNOWN";
            }
        }
    }
}