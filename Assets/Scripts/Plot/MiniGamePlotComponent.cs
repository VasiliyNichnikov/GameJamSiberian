#nullable enable
using System;
using Configs.Plot;
using Plot.MiniGame;
using UI.Desktop;
using UnityEngine;

namespace Plot
{
    public class MiniGamePlotComponent : AbstractPlotComponent
    {
#pragma warning disable CS0067
        public override event Action? OnCompletePlot;
#pragma warning disable

        private readonly IMiniGamePlot _miniGamePlot;
        
        public MiniGamePlotComponent(IComputerFacade computerFacade, MiniGamePlotData data) : base(computerFacade)
        {
            switch (data.MiniGameType)
            {
                case MiniGameType.EnteringPassword:
                    _miniGamePlot = new EnteringPasswordMiniGamePlot(computerFacade);
                    break;
                default:
                    Debug.LogError($"MiniGamePlotComponent: not supported type: {_miniGamePlot}");
                    _miniGamePlot = new EmptyMiniGame();
                    break;
            }
        }

        public override void ExecutePlot() => _miniGamePlot.ExecutePlot();

        public override bool CheckCompletionCondition() => _miniGamePlot.CheckCompletionCondition();

        public override void CompletePlot() => _miniGamePlot.CompletePlot();
    }
}