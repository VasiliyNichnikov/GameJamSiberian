using Configs;
using UI.Desktop;

namespace ProgramsLogic
{
    /// <summary>
    /// Заглушка
    /// </summary>
    public class EmptyProgram : ProgramData
    {
        public override ProgramType Type => ProgramType.Empty;

        public EmptyProgram(DesktopProgramContext context) : base(context)
        {
        }
    }
}