#nullable enable
using Configs;
using UI.Desktop;
using UI.Programs.TrelloMiniGame.View;
using UI.Programs.TrelloMiniGame.ViewModel;

namespace ProgramsLogic
{
    public class IzbaSerfProgram : ProgramData
    {
        public override ProgramType Type => ProgramType.IzbaSurf;

        public bool IsCompleted { get; private set; }
        
        public IzbaSerfProgram(DesktopProgramContext context) : base(context)
        {
        }

        protected override void OnClickHandlerBase()
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<TrelloMiniGameDialog>();
            dialog.Init(new TrelloMiniGameViewModel(dialog.Hide, IsCompleted));
            dialog.SetHideAction(() =>
            {
                State.Close();
                IsCompleted = true;
            });
            State.Open();
        }
    }
}