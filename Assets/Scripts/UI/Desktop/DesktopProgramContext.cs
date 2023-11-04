using Configs;

namespace UI.Desktop
{
    /// <summary>
    /// Управляет иконками на рабочем столе
    /// </summary>
    public struct DesktopProgramContext
    {
        public bool AllowProgramToRun { get; private set; }
        public ProgramType ProgramType { get; private set; }

        public static DesktopProgramContext Default(ProgramType type) => new DesktopProgramContext(type);
        
        public DesktopProgramContext SetAllowProgramToRun()
        {
            AllowProgramToRun = true;
            return this;
        }
        
        private DesktopProgramContext(ProgramType type)
        {
            ProgramType = type;
            AllowProgramToRun = false;
        }
    }
}