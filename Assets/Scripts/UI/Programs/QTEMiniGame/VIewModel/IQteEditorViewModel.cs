using System.Collections.Generic;

namespace UI.Programs.QTEMiniGame.VIewModel
{
    public interface IQteEditorViewModel
    {
        List<string> ProgramText { get; }  
        float Delay { get; }         
        int NumberSymbolsForDeleteInIteration { get; }
    }
}