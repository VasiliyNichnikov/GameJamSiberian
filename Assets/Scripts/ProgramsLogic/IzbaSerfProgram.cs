using Configs;
using UI.Desktop;

namespace ProgramsLogic
{
    public class IzbaSerfProgram : ProgramData
    {
        public override ProgramType Type => ProgramType.IzbaSurf;

        public IzbaSerfProgram(DesktopProgramContext context) : base(context)
        {
        }
    }
}