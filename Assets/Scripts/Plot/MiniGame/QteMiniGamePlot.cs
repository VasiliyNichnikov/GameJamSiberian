#nullable enable
using Configs;
using ProgramsLogic;
using UI.Desktop;
using UnityEngine;

namespace Plot.MiniGame
{
    public class QteMiniGamePlot : IMiniGamePlot
    {
        private readonly IComputerFacade _computerFacade;
        private IdeProgram? _ideProgram;
        
        public QteMiniGamePlot(IComputerFacade computerFacade)
        {
            _computerFacade = computerFacade;
        }
        
        public void ExecutePlot()
        {
            if (!_computerFacade.TryGetInstalledProgram(ProgramType.IDE, out var program))
            {
                Debug.LogError(
                    $"InstallingIdeMiniGamePlot.ExecutePlot: not found installed program {ProgramType.InstallerIde}");
                return;
            }

            if (program is IdeProgram ide)
            {
                _ideProgram = ide;
            }
        }

        public bool CheckCompletionCondition()
        {
            if (_ideProgram == null)
            {
                Debug.LogError("QteMiniGamePlot.CheckCompletionCondition: installerIde is null");
                return false;
            }
            
            return _ideProgram.IsCompleted;
        }

        public void CompletePlot()
        {
            
        }
    }
}