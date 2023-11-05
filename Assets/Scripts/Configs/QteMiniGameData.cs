#nullable enable
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(fileName = "QteMiniGameData", menuName = "Configs/QteMiniGameData", order = 0)]
    public class QteMiniGameData : ScriptableObject
    {
        public IReadOnlyCollection<KeyCode> NeedKeys => _needKeys;
        public float MaxTimeBetweenQte => _maxTimeBetweenQte;
        public float MaxQteTime => _maxQteTime;
        public float MinTimeBetweenQte => _minTimeBetweenQte;
        public float MinQteTime => _minQteTime;
        public string? ProgramText => _programText;
        public float Delay => _delay;
        public int NumberSymbolsForDeleteInIteration => _numberSymbolsForDeleteInIteration;
        public float QteScaler => _qteScaler;
        public float AccuracyLimit => _accuracyLimit;
        public int NumberRecalculate => _numberRecalculate;
        
        [SerializeField, Header("Клавиши, используемые для QTE")] private List<KeyCode> _needKeys = null!;
        
        [SerializeField, Header("Максимальное время между QTE (сек) - легкий уровень")] private float _maxTimeBetweenQte;
        [SerializeField, Header("Максимальное время на то, чтобы нажать клавишу (сек) - легкий уровень")] private float _maxQteTime;
        
        [SerializeField, Header("Минимальное время между QTE (сек) - сложный уровень")] private float _minTimeBetweenQte;
        [SerializeField, Header("Минимальное время на то, чтобы нажать клавишу (сек) - сложный уровень")] private float _minQteTime;
        
        [SerializeField, Header("Число, на которое будет умножаться время [0; 1]")] private float _qteScaler;
        [SerializeField, Header("Порог точности, при котором повышается сложность [0; 1]")] private float _accuracyLimit;
        [SerializeField, Header("Число попыток, через сколько будет пересчитывться точность")] private int _numberRecalculate;

        [SerializeField, Header("Текст для отоброжения (не забывайте про строки)"), Multiline] private string _programText = null!;
        [SerializeField, Header("Скорость появления новых символов в тексте (сек)")] private float _delay;
        [SerializeField, Header("Кол-во символов, которое будет удаляться за ошибку")] private int _numberSymbolsForDeleteInIteration;
    }
}