using System.Collections.Generic;
using System.Linq;

namespace UI.Programs.QTEMiniGame.VIewModel
{
    public class QteEditorViewModel : IQteEditorViewModel
    {
        public List<string> ProgramText { get; }
        public float Delay { get; }
        public int NumberSymbolsForDeleteInIteration { get; }

        public QteEditorViewModel(Configs.QteMiniGameData data)
        {
            ProgramText = data.ProgramText.Split('\n').ToList();
            Delay = data.Delay;
            NumberSymbolsForDeleteInIteration = data.NumberSymbolsForDeleteInIteration;
        }
    }
}