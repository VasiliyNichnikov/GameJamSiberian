#nullable enable
using Configs.Plot;
using UI.Programs.Messenger;

namespace UI.Programs
{
    /// <summary>
    /// Команды для работы с мессенджером
    /// </summary>
    public interface IMessengerManager
    {
        MessengerState State { get; }
        
        /// <summary>
        /// Используется для того чтобы убедиться что больше сообщений на отправку нет
        /// </summary>
        bool AllMessagesSendInChat(UserType user);
        
        /// <summary>
        /// Выбор пользователя для показа чата
        /// </summary>
        void SelectUserChat(UserType type);

        /// <summary>
        /// Открываем чат
        /// </summary>
        void OpenMessenger();

        /// <summary>
        /// Загружаем сообщения в чаты
        /// </summary>
        void LoadMessagesInChats(MessengerPlotData data);
    }
}