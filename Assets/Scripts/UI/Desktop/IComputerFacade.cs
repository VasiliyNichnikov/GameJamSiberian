#nullable enable
using Configs;
using ProgramsLogic;

namespace UI.Desktop
{
    /// <summary>
    /// Основная логика работы с ПК
    /// </summary>
    public interface IComputerFacade
    {
        bool IsProgramInstalled(ProgramType program);
        
        void InstallProgram(ProgramData program);
        void UpdateProgram(ProgramType programType, DesktopProgramContext context);
        void RemoveProgram(ProgramData program);

        bool TryGetInstalledProgram(ProgramType programType, out IProgram? program);

        /// <summary>
        /// Блокирует все наажатия на рабочем столе
        /// </summary>
        void BlockAllClicks();

        /// <summary>
        /// Разблокирует все нажатия на рабочем столе
        /// </summary>
        void UnlockAllClicks();
    }
}