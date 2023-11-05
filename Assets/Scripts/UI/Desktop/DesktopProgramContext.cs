using Configs;

namespace UI.Desktop
{
    /// <summary>
    /// Управляет иконками на рабочем столе
    /// </summary>
    public struct DesktopProgramContext
    {
        public bool AllowProgramToRun { get; private set; }

        public static DesktopProgramContext Default() => new DesktopProgramContext();
        
        public DesktopProgramContext SetAllowProgramToRun()
        {
            AllowProgramToRun = true;
            return this;
        }
        
        private DesktopProgramContext(ProgramType type)
        {
            AllowProgramToRun = false;
        }
    }
}