#nullable enable
using System;
using UI.Desktop;

namespace Plot
{
    /// <summary>
    /// Используем при ошибке
    /// </summary>
    public class EmptyPlotComponent : AbstractPlotComponent
    {
#pragma warning disable CS0067
        public override event Action? OnCompletePlot;
#pragma warning disable
        public EmptyPlotComponent(IComputerFacade computerFacade) : base(computerFacade)
        {
        }

        public override void ExecutePlot()
        {
        }

        public override bool CheckCompletionCondition()
        {
            return false;
        }

        public override void CompletePlot()
        {
        }
    }
}