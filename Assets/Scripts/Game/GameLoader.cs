#nullable enable
using UI.Programs.Messenger;
using UI.Programs.Messenger.View;
using UI.Programs.Messenger.ViewModel;

namespace Game
{
    /// <summary>
    /// Главный загрузчик игры
    /// Пока просто для проверки
    /// </summary>
    public class GameLoader
    {
        private readonly MessengerFacade _messengerFacade;
        
        public GameLoader()
        {
            _messengerFacade = new MessengerFacade();
        }

        public void LoadGame()
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<MessengerDialog>();
            dialog.Init(new MessengerViewModel(_messengerFacade));
        }
    }
}