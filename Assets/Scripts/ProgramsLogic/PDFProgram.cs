using Configs;
using UI.Desktop;
using UI.Programs.PDF;
using UI.Programs.PDF.View;
using UI.Programs.PDF.ViewModel;

namespace ProgramsLogic
{
    public class PDFProgram : ProgramData
    {
        public override ProgramType Type => ProgramType.PDF;

        public PDFProgram(DesktopProgramContext context) : base(context)
        {
        }

        public override void OnClickHandler()
        {
            if (State.IsOpened)
            {
                return;
            }

            var dialog = Main.Instance.GuiManager.ShowDialog<PDFDialog>();
            dialog.Init(new PDFViewModel());
            /*State.Open();*/
        }
    }

}
