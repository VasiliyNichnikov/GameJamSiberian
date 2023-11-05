#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Configs.Plot
{
    [CreateAssetMenu(fileName = "Plot", menuName = "Configs/Plot", order = 0)]
    public class PlotData : ScriptableObject
    {
        public ReadOnlyCollection<PlotComponent> Components => new ReadOnlyCollection<PlotComponent>(_plots);
        
        [Serializable]
        public struct PlotComponent
        {
            public PlotType PlotType => _plotType;
            public MiniGamePlotData? MiniGameData => _miniGameData;
            public MessengerPlotData? MessengerData => _messengerData;
            public BlackScreenPlotData? BlackScreenData => _blackScreenData;
            
            [SerializeField] private PlotType _plotType;
            [SerializeField] private MiniGamePlotData? _miniGameData;
            [SerializeField] private MessengerPlotData? _messengerData;
            [SerializeField] private BlackScreenPlotData? _blackScreenData;
        }

        [SerializeField, Header("Описываем сюжет в нужно последовательност")]
        private PlotComponent[] _plots = null!;
    }
}