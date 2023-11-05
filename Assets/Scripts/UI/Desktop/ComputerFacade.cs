#nullable enable

using System;
using Configs;
using ProgramsLogic;
using UI.Desktop.View;
using UI.Desktop.ViewModel;
using UI.Programs;
using UI.Programs.Messenger;

namespace UI.Desktop
{
    public class ComputerFacade : IComputerFacade, IDisposable
    {
        public IMessengerManager MessengerManager => _messengerManager;
        
        /// <summary>
        /// Чат должен жить на протяжение все игры
        /// </summary>
        private readonly MessengerManager _messengerManager = new MessengerManager();
        private readonly ProgramStorage _storage = new ProgramStorage();

        /// <summary>
        /// Установка программы
        /// </summary>
        public void InstallProgram(ProgramData program) => _storage.InstallProgram(program);
        /// <summary>
        /// Обновляем программму
        /// </summary>
        public void UpdateProgram(ProgramType programType, DesktopProgramContext context) => _storage.UpdateProgram(programType, context);

        /// <summary>
        /// Удаляем программу
        /// </summary>
        public void RemoveProgram(ProgramData program) => _storage.RemoveProgram(program.Type);

        public void OpenDesktop()
        {
            var viewModel = new DesktopViewModel(_storage);
            var desktop = Main.Instance.GuiManager.ShowDialog<DesktopDialog>();
            desktop.Init(viewModel);
        }

        public void Dispose()
        {
            
        }
    }
}