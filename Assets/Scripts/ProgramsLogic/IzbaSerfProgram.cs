#nullable enable
using Configs;
using UI.Desktop;
using UI.Programs.TrelloMiniGame;
using UI.Programs.TrelloMiniGame.View;
using UI.Programs.TrelloMiniGame.ViewModel;

namespace ProgramsLogic
{
    public class IzbaSerfProgram : ProgramData
    {
        public ITrelloMiniGameManager TrelloMiniGameManager => _trelloMiniGameManager;
        
        public override ProgramType Type => ProgramType.IzbaSurf;

        private readonly TrelloMiniGameManager _trelloMiniGameManager;
        
        public IzbaSerfProgram(DesktopProgramContext context) : base(context)
        {
            _trelloMiniGameManager = new TrelloMiniGameManager();
        }

        protected override void OnClickHandlerBase()
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<TrelloMiniGameDialog>();
            dialog.Init(new TrelloMiniGameViewModel(_trelloMiniGameManager));
            dialog.SetHideAction(State.Close);
            State.Open();
        }
    }
}