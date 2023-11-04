#nullable enable

using UI.ClicksHandler;

namespace UI.Desktop
{
    public class ProgramData : IProgram
    {
        public DesktopProgramContext Context { get; private set; }

        public ProgramData(DesktopProgramContext context)
        {
            Context = context;
        }

        public void UpdateContext(DesktopProgramContext context)
        {
            Context = context;
        }

        public void OnClickHandler()
        {
            ProgramClicksHelper.OnClickDefaultHandler(Context);
        }

        public void Dispose()
        {
            // nothing
        }
    }
}