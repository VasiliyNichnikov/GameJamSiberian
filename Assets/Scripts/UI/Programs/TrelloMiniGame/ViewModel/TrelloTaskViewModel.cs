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
                case TrelloMiniGameData.TaskTag.Ornament:
                    return "Орнамент";
                case TrelloMiniGameData.TaskTag.DigitalIconography:
                    return "Цифровая иконопись";
                case TrelloMiniGameData.TaskTag.SymbolistDecipherer:
                    return "Символист-разгадчик";
                case TrelloMiniGameData.TaskTag.CatResearcher:
                    return "Котоисследователь";
                case TrelloMiniGameData.TaskTag.Codifier:
                    return "Кодификатор";
                case TrelloMiniGameData.TaskTag.CipherComposer:
                    return "Шифрокомпозитор";
                case TrelloMiniGameData.TaskTag.Accounts:
                    return "Счёты";
                case TrelloMiniGameData.TaskTag.NegotiationsWithClient:
                    return "Переговоры с клиентом";
                case TrelloMiniGameData.TaskTag.Chronicles:
                    return "Летописи";
                default:
                    Debug.LogError($"TrelloTaskViewModel.ConvertTag: not corrected type: {tag}");
                    return "UNKNOWN";
            }
        }
    }
}