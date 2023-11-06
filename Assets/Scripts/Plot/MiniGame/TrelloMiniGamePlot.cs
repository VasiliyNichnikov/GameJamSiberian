#nullable enable
using Configs;
using ProgramsLogic;
using UI.Desktop;
using UI.Programs.TrelloMiniGame;
using UnityEngine;

namespace Plot.MiniGame
{
    public class TrelloMiniGamePlot : IMiniGamePlot
    {
        private readonly IComputerFacade _computerFacade;
        private ITrelloMiniGameManager? _trelloMiniGameManager;
        
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
                _trelloMiniGameManager = browser.TrelloMiniGameManager;
            }
        }

        public bool CheckCompletionCondition()
        {
            if (_trelloMiniGameManager == null)
            {
                Debug.LogError("TrelloMiniGamePlot.CheckCompletionCondition: trelloMiniGameManager is null");
                return false;
            }
            
            return _trelloMiniGameManager.IsCompleted;
        }

        public void CompletePlot()
        {
            // need release
        }
    }
}