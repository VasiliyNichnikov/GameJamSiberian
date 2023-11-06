#nullable enable

using System;
using Configs;
using ProgramsLogic;
using UI.Desktop.View;
using UI.Desktop.ViewModel;
using UnityEngine;

namespace UI.Desktop
{
    public class ComputerFacade : IComputerFacade, IDisposable
    {
        private readonly ProgramStorage _storage = new ProgramStorage();
        private readonly ClicksController _clicksController;
        
        private DesktopDialog? _desktop;

        public ComputerFacade(ClicksController clicksController)
        {
            _clicksController = clicksController;
        }

        public bool IsProgramInstalled(ProgramType program) => _storage.TryGetProgram(program, out _);

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

        public bool TryGetInstalledProgram(ProgramType programType, out IProgram? program) =>
            _storage.TryGetProgram(programType, out program);

        public void BlockAllClicks() => _clicksController.TurnOnDisplayBlocker();
        public void UnlockAllClicks() => _clicksController.TurnOffDisplayBlocker();
        public void OpenDesktop()
        {
            if (_desktop != null)
            {
                Debug.LogError("ComputerFacade.OpenDesktop: desktop is already opened");
                return;
            }
            
            var viewModel = new DesktopViewModel(_storage);
            _desktop = Main.Instance.GuiManager.ShowDialog<DesktopDialog>();
            _desktop.Init(viewModel);
        }

        public void Dispose()
        {
            
        }
    }
}