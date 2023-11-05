#nullable enable
using Configs;
using ProgramsLogic;
using UI.Desktop;
using UnityEngine;

namespace Plot.MiniGame
{
    public class TrelloMiniGamePlot : IMiniGamePlot
    {
        private readonly IComputerFacade _computerFacade;
        private IzbaSerfProgram? _browser;
        
        public TrelloMiniGamePlot(IComputerFacade computerFacade)
        {
            _computerFacade = computerFacade;
        }
        
        public void ExecutePlot()
        {
            if (!_computerFacade.TryGetInstalledProgram(ProgramType.IzbaSurf, out var program))
            {
                Debug.LogError(
                    $"TrelloMiniGamePlot.ExecutePlot: not found installed program {ProgramType.InstallerIde}");
                return;
            }

            if (program is IzbaSerfProgram browser)
            {
                _browser = browser;
            }
        }

        public bool CheckCompletionCondition()
        {
            if (_browser == null)
            {
                Debug.LogError("TrelloMiniGamePlot.CheckCompletionCondition: browser is null");
                return false;
            }
            
            return _browser.IsCompleted;
        }

        public void CompletePlot()
        {
            // need release
        }
    }
}