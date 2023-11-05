using Configs;
using UI.Desktop;

namespace ProgramsLogic
{
    public class IdeProgram : ProgramData
    {
        public override ProgramType Type => ProgramType.IDE;

        public IdeProgram(DesktopProgramContext context) : base(context)
        {
        }
    }
}