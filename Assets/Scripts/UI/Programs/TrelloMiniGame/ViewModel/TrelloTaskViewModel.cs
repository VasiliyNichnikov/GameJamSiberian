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
        public event Action? OnShowArrows;
        public int ColumnNumber { get; private set; }
        public string Title { get; }
        public string Description { get; }
        
        public string UserName { get; }
        public string UserSurname { get; }
        public Sprite UserIcon { get; }
        
        public IReadOnlyCollection<string> Tags { get; }

        /// <summary>
        /// Обработчик при нажатие на стрелки
        /// Первый int - это текущая колонка
        /// Второй int - в какую колонку нужно перенести
        /// </summary>
        private readonly Action<int, int, TrelloTaskViewModel> _onClickArrowsHandler;
        /// <summary>
        /// Обработчик при нажатие на таску
        /// </summary>
        private readonly Action<TrelloTaskViewModel> _onClickTaskHandler;
        
        public TrelloTaskViewModel(TrelloMiniGameData.TaskData data, Action<TrelloTaskViewModel> onClickTaskHandler, Action<int, int, TrelloTaskViewModel> onClickArrowsHandler, int columnNumber)
        {
            Title = data.Title;
            ColumnNumber = columnNumber;
            Description = data.Description;
            Tags = data.Tags.Select(ConvertTag).ToList();
            var userData = DataHelper.Instance.TrelloMiniGameData.GetUserByType(data.User);
            UserName = userData.Name;
            UserSurname = userData.Surname;
            UserIcon = userData.Icon;

            _onClickArrowsHandler = onClickArrowsHandler;
            _onClickTaskHandler = onClickTaskHandler;
        }

        /// <summary>
        /// Очень плохо
        /// </summary>
        public void SetColumnNumber(int value)
        {
            ColumnNumber = value;
        }

        public void OnClickTaskHandler() => _onClickTaskHandler.Invoke(this);

        public void OnMoveLeftColumnHandler() => _onClickArrowsHandler.Invoke(ColumnNumber, ColumnNumber - 1, this);
        public void OnMoveRightColumnHandler() => _onClickArrowsHandler.Invoke(ColumnNumber, ColumnNumber + 1, this);
        public void SelectAndShowArrows() => OnShowArrows?.Invoke();
        
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