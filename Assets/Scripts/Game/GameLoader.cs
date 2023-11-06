#nullable enable
using Configs;
using ProgramsLogic;
using UI.Desktop;

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
            // Устанавливаем браузер без возможности в него попасть // TODO удалить
            _computerFacade.InstallProgram(ProgramFactory.CreateProgram(ProgramType.IzbaSurf, DesktopProgramContext.Default().SetAllowProgramToRun()));
            // Устанавливаем мессенджер с возможностью в него попасть
            _computerFacade.InstallProgram(ProgramFactory.CreateProgram(ProgramType.Swallow, DesktopProgramContext.Default().SetAllowProgramToRun()));
            // Устанавливаем файл PDF
            _computerFacade.InstallProgram(ProgramFactory.CreateProgram(ProgramType.PDF, DesktopProgramContext.Default().SetAllowProgramToRun()));
            // Устанавливаем загрузчик IDE (Он не будет показываться на рабочем столе)
            _computerFacade.InstallProgram(ProgramFactory.CreateProgram(ProgramType.InstallerIde, DesktopProgramContext.Default().SetAllowProgramToRun().HideProgramFromDesktop()));
        }
    }
}