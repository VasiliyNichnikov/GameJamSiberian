using UnityEngine;

namespace UI.Programs.QTEMiniGame.VIewModel
{
    public interface IQteMiniGameViewModel
    {
        KeyCode CurrentNeedKey { get; }
        bool CheckKey(bool downCorrectKey);
        void GenerateNewKey();
        bool IsKeyNeed { get; set; }
        float TimeBetweenQte { get; }
        float QteTime { get; }
        IQteEditorViewModel EditorViewModel { get; }
        int NumberForRecalculate { get; }
        bool EditQteParam();
        void SetCalcAccuracy(int target, int total);
    }
}