using System.Collections.Generic;
using UI.Programs.Messenger;

namespace UI.Programs
{
    /// <summary>
    /// Команды для работы с мессенджером
    /// </summary>
    public interface IMessengerManager
    {
        /// <summary>
        /// Получаем всех доступных пользователей
        /// Которых можем читать
        /// </summary>
        IReadOnlyCollection<UserType> AllUserTypes { get; }

        /// <summary>
        /// Выбор пользователя для показа чата
        /// </summary>
        void SelectUserChat(UserType type);

        /// <summary>
        /// Открываем чат
        /// </summary>
        void OpenMessenger();
    }
}