using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Programs.QTEMiniGame.VIewModel
{
    public class QteMiniGameViewModel : IQteMiniGameViewModel
    {
        public KeyCode CurrentNeedKey { get; private set; }
        private readonly List<KeyCode> _keyNames;

        public bool IsKeyNeed { get; set; } 
        public float TimeBetweenQte { get; private set; }
        public float QteTime { get; private set; }
        
        private readonly float _minTimeBetweenQte;
        private readonly float _minQteTime;

        public int NumberForRecalculate { get; }
        private readonly float _qteScaler;
        private readonly float _accuracyLimit;
        private float _accuracy;
        
        public IQteEditorViewModel EditorViewModel { get; }
        public QteMiniGameViewModel()
        {
            var data = DataHelper.Instance.QteMiniGameData;
            _keyNames = data.NeedKeys.ToList();
            
            TimeBetweenQte = data.MaxTimeBetweenQte;
            QteTime = data.MaxQteTime;
            _minTimeBetweenQte = data.MinTimeBetweenQte;
            _minQteTime = data.MinQteTime;

            NumberForRecalculate = data.NumberRecalculate;
            _qteScaler = data.QteScaler;
            _accuracyLimit = data.AccuracyLimit;

            EditorViewModel = new QteEditorViewModel(data);
        }

        public bool CheckKey(bool downCorrectKey)
        {
            return IsKeyNeed && downCorrectKey;
        }

        public void GenerateNewKey()
        {
            CurrentNeedKey = _keyNames[Random.Range(0, _keyNames.Count)];
        }

        public bool EditQteParam()
        {
            if (_accuracy > _accuracyLimit)
            {
                TimeBetweenQte = TimeBetweenQte > _minTimeBetweenQte ? TimeBetweenQte *= _qteScaler : TimeBetweenQte;
                QteTime = QteTime > _minQteTime ? QteTime *= _qteScaler : QteTime;
                
                _accuracy = 0;
                return true;
            }

            return false;
        }

        public void SetCalcAccuracy(int target, int total)
        {
            _accuracy = (float)target / (float)total;
        }
    }
}