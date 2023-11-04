#nullable enable
using UI.Programs.TrelloMiniGame.View;
using UI.Programs.TrelloMiniGame.ViewModel;

namespace Game
{
    /// <summary>
    /// Главный загрузчик игры
    /// Пока просто для проверки
    /// </summary>
    public class GameLoader
    {
        public void LoadGame()
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<TrelloMiniGameDialog>();
            dialog.Init(new TrelloMiniGameViewModel());
        }
    }
}