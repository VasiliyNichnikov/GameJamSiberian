using Configs;
using UI.Desktop;
using UI.Programs.QTEMiniGame.View;
using UI.Programs.QTEMiniGame.VIewModel;

namespace ProgramsLogic
{
    public class IdeProgram : ProgramData
    {
        public bool IsCompleted { get; private set; }
        
        public override ProgramType Type => ProgramType.IDE;

        public IdeProgram(DesktopProgramContext context) : base(context)
        {
        }
        
        protected override void OnClickHandlerBase()
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<QteMiniGameView>();
            dialog.Init(new QteMiniGameViewModel(), IsCompleted, () =>
            {
                IsCompleted = true;
            });
            dialog.SetHideAction(State.Close);
            State.Open();
        }
    }
}