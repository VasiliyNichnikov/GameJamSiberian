namespace UI.Desktop
{
    /// <summary>
    /// Основная логика работы с ПК
    /// </summary>
    public interface IComputerFacade
    {
        void InstallProgram(DesktopProgramContext context);
        void UpdateProgram(DesktopProgramContext context);
    }
}