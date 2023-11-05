#nullable enable
using System.Collections.Generic;
using UI.Desktop;
using UnityEngine;


namespace Plot
{
    public class PlotManager : IPlotManager
    {
        // ключ - id сюжета 
        private readonly Dictionary<int, AbstractPlotComponent> _plots = new();

        /// <summary>
        /// ЛУЧШЕ НЕ ТРОГАТЬ ЕГО ЛОГИКУ И НЕ МЕНЯТЬ
        /// ИНАЧЕ БУДЕТ ПИЗДЕЦ А НЕ СЮЖЕТ :)
        /// </summary>
        private int _currentPlotIndex = -1;

        private readonly IComputerFacade _computerFacade;

        public PlotManager(IComputerFacade computerFacade)
        {
            _computerFacade = computerFacade;
            InitializePlots();
        }
        
        public void StartPlot()
        {
            if (!_plots.ContainsKey(_currentPlotIndex))
            {
                Debug.LogError($"PlotManager.StartPlot: failed to start plot with id {_currentPlotIndex}");
                return;
            }

            var plot = _plots[_currentPlotIndex];
            plot.ExecutePlot();
        }

        /// <summary>
        /// Проверяем выполнение текущего сюжета
        /// </summary>
        public void CheckExecutionOfPlot()
        {
            // Сначала получаем текущий сюжет
            var currentPlot = _plots[_currentPlotIndex];
            if (!currentPlot.CheckCompletionCondition())
            {
                return;
            }

            currentPlot.CompletePlot();
            var nextPlotIndex = _currentPlotIndex + 1;
            if (_plots.TryGetValue(nextPlotIndex, out var nextPlot))
            {
                _currentPlotIndex = nextPlotIndex;
                nextPlot.ExecutePlot();
            }
            else
            {
                Debug.Log("PlotManager.OnComplete: игра завершена");
            }
        }
        
        private void InitializePlots()
        {
            var data = DataHelper.Instance.PlotData;
            for (var i = 0; i < data.Components.Count; i++)
            {
                var component = data.Components[i];
                var plot = AbstractPlotComponent.CreatePlot(_computerFacade, component);
                if (_plots.ContainsKey(i))
                {
                    Debug.LogError("PlotManager.InitializePlots: plot with id already contains in list");
                    return;
                }
                _plots.Add(i, plot);
            }

            _currentPlotIndex = 0;
        }
    }
}