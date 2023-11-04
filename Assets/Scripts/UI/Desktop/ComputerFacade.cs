#nullable enable

using System;
using UI.Desktop.View;
using UI.Desktop.ViewModel;

namespace UI.Desktop
{
    public class ComputerFacade : IComputerFacade, IDisposable
    {
        private readonly ProgramStorage _storage = new ProgramStorage();
        
        /// <summary>
        /// Установка программы
        /// </summary>
        public void InstallProgram(DesktopProgramContext context) => _storage.InstallProgram(context);
        /// <summary>
        /// Обновляем программму
        /// </summary>
        public void UpdateProgram(DesktopProgramContext context) => _storage.UpdateProgram(context);

        public void RemoveProgram(DesktopProgramContext context) => _storage.RemoveProgram(context);

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