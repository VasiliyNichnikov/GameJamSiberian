#nullable enable
using Configs;
using ProgramsLogic;
using UI.Desktop;
using UnityEngine;

namespace Plot.MiniGame
{
    public class InstallingIdeMiniGamePlot : IMiniGamePlot
    {
        private readonly IComputerFacade _computerFacade;
        private InstallerIdeProgram? _installerIde;

        public InstallingIdeMiniGamePlot(IComputerFacade computerFacade)
        {
            _computerFacade = computerFacade;
        }

        public void ExecutePlot()
        {
            if (!_computerFacade.TryGetInstalledProgram(ProgramType.InstallerIde, out var program))
            {
                Debug.LogError(
                    $"InstallingIdeMiniGamePlot.ExecutePlot: not found installed program {ProgramType.InstallerIde}");
                return;
            }

            if (program is InstallerIdeProgram installer)
            {
                _installerIde = installer;
            }
        }

        public bool CheckCompletionCondition()
        {
            if (_installerIde == null)
            {
                Debug.LogError("InstallingIdeMiniGamePlot.CheckCompletionCondition: installerIde is null");
                return false;
            }
            
            return _installerIde.IsCompleted;
        }

        public void CompletePlot()
        {
            // Устанавливаем Ide на рабочий стол
            var context = DesktopProgramContext.Default();
            _computerFacade.InstallProgram(ProgramFactory.CreateProgram(ProgramType.IDE, context));
            
            // Добавляем клик для Trello (Браузер)
            var browserContext = DesktopProgramContext.Default().SetAllowProgramToRun();
            _computerFacade.UpdateProgram(ProgramType.IzbaSurf, browserContext);
        }
    }
}