using Configs;
using ProgramsLogic;
using UI.Programs;

namespace UI.Desktop
{
    /// <summary>
    /// Основная логика работы с ПК
    /// </summary>
    public interface IComputerFacade
    {
        IMessengerManager MessengerManager { get; }
        
        void InstallProgram(ProgramData program);
        void UpdateProgram(ProgramType programType, DesktopProgramContext context);
        void RemoveProgram(ProgramData program);
    }
}