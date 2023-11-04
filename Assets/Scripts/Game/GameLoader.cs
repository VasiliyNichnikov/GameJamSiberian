#nullable enable

namespace Game
{
    public class GameLoader
    {
        public IComputerFacade ComputerFacade => _computerFacade;
        
        private readonly ComputerFacade _computerFacade;

        public GameLoader(ClicksController clicksController)
        {
            _computerFacade = new ComputerFacade(clicksController);
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
            _computerFacade.InstallProgram(ProgramFactory.CreateProgram(ProgramType.IzbaSurf, DesktopProgramContext.Default()));
            // Устанавливаем мессенджер с возможностью в него попасть
            _computerFacade.InstallProgram(ProgramFactory.CreateProgram(ProgramType.Swallow, DesktopProgramContext.Default().SetAllowProgramToRun()));
        }
    }
}