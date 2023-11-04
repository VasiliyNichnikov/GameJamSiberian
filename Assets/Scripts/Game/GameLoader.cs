#nullable enable
using Configs;
using UI.Desktop;
using UI.Desktop.View;
using UI.Desktop.ViewModel;

namespace Game
{
    public class GameLoader
    {
        private readonly ComputerFacade _computerFacade;

        public GameLoader()
        {
            _computerFacade = new ComputerFacade();
        }
        
        public void LoadGame()
        {
            RunComputer();
        }

        /// <summary>
        /// Для начала готовим стартовый ПК
        /// </summary>
        private void RunComputer()
        {
            // Открываем рабочий стол
            _computerFacade.OpenDesktop();
            // Устанавливаем браузер без возможности в него попасть
            _computerFacade.InstallProgram(DesktopProgramContext.Default(ProgramType.IzbaSurf));
            // Устанавливаем мессенджер с возможностью в него попасть
            _computerFacade.InstallProgram(DesktopProgramContext.Default(ProgramType.Swallow).SetAllowProgramToRun());
        }
    }
}