using Configs;
using UI.Desktop;
using UI.Programs.PDF.View;

namespace ProgramsLogic
{
    public class PDFProgram : ProgramData
    {
        public override ProgramType Type => ProgramType.PDF;

        public PDFProgram(DesktopProgramContext context) : base(context)
        {
        }
        
        protected override void OnClickHandlerBase()
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<PDFDialog>();
            dialog.SetHideAction(State.Close);
            State.Open();
        }
    }

}
