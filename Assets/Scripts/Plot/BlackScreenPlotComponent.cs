#nullable enable
using System;
using Configs.Plot;
using UI.Desktop;

namespace Plot
{
    public class BlackScreenPlotComponent : AbstractPlotComponent
    {
#pragma warning disable CS0067
        public override event Action? OnCompletePlot;
#pragma warning disable

        public BlackScreenPlotComponent(IComputerFacade computerFacade, BlackScreenPlotData data) : base(computerFacade)
        {
        }

        public override void ExecutePlot()
        {
        }

        public override void CompletePlot()
        {
        }

        public override bool CheckCompletionCondition()
        {
            return false;
        }
    }
}