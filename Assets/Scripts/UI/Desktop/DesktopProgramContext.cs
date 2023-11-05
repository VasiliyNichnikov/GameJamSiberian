namespace UI.Desktop
{
    /// <summary>
    /// Управляет иконками на рабочем столе
    /// </summary>
    public struct DesktopProgramContext
    {
        public bool AllowProgramToRun { get; private set; }
        public bool NeedShowInDesktop { get; private set; }

        public static DesktopProgramContext Default() => new(true);
        
        public DesktopProgramContext SetAllowProgramToRun()
        {
            AllowProgramToRun = true;
            return this;
        }

        public DesktopProgramContext HideProgramFromDesktop()
        {
            NeedShowInDesktop = false;
            return this;
        }
        
        private DesktopProgramContext(bool needShowInDesktop)
        {
            AllowProgramToRun = false;
            NeedShowInDesktop = needShowInDesktop;
        }
    }
}