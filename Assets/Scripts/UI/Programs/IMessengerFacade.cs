using System.Collections.Generic;
using UI.Programs.Messenger;

namespace UI.Programs
{
    /// <summary>
    /// Перегородка между данными и логикой
    /// Чтобы не надо было постоянно обращаться к синглтону в ВМ
    /// </summary>
    public interface IMessengerFacade
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
    }
}