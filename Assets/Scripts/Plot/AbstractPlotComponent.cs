#nullable enable
using System;
using Configs.Plot;
using UI.Desktop;
using UnityEngine;

namespace Plot
{
    public abstract class AbstractPlotComponent
    {
        public abstract event Action? OnCompletePlot;

        protected readonly IComputerFacade ComputerFacade;

        private static EmptyPlotComponent EmptyPlot(IComputerFacade computerFacade) => new EmptyPlotComponent(computerFacade);

        protected AbstractPlotComponent(IComputerFacade computerFacade)
        {
            ComputerFacade = computerFacade;
        }
        
        public static AbstractPlotComponent CreatePlot(IComputerFacade computerFacade, PlotData.PlotComponent component)
        {
            switch (component.PlotType)
            {
                case PlotType.Messenger:
                    if (component.MessengerData == null)
                    {
                        Debug.LogError("AbstractPlotComponent.CreatePlot: messenger data is null");
                        return EmptyPlot(computerFacade);
                    }
                    return new MessengerPlotComponent(computerFacade, component.MessengerData);
                case PlotType.MiniGame:
                    if (component.MiniGameData == null)
                    {
                        Debug.LogError("AbstractPlotComponent.CreatePlot: messenger data is null");
                        return EmptyPlot(computerFacade);
                    }
                    return new MiniGamePlotComponent(computerFacade, component.MiniGameData);
                case PlotType.BlackScreen:
                    if (component.BlackScreenData == null)
                    {
                        Debug.LogError("AbstractPlotComponent.CreatePlot: messenger data is null");
                        return EmptyPlot(computerFacade);
                    }
                    return new BlackScreenPlotComponent(computerFacade, component.BlackScreenData);
                default:
                    Debug.LogError($"AbstractPlotComponent.CreatePlot: unsupported type {component.PlotType}");
                    return EmptyPlot(computerFacade);
            }
        }
        
        
        public abstract void ExecutePlot();

        public abstract void CompletePlot();
        
        public abstract bool CheckCompletionCondition();
    }
}