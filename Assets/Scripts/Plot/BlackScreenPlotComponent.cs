#nullable enable
using System;
using Configs.Plot;
using UI.Bluer;
using UI.Desktop;

namespace Plot
{
    public class BlackScreenPlotComponent : AbstractPlotComponent
    {
#pragma warning disable CS0067
        public override event Action? OnCompletePlot;
#pragma warning disable

        private readonly BlackScreenPlotData _data;
        private BluerDialog? _bluerDialog;
        private bool _isCompleted;
        
        public BlackScreenPlotComponent(IComputerFacade computerFacade, BlackScreenPlotData data) : base(computerFacade)
        {
            _data = data;
            _isCompleted = false;
        }

        public override void ExecutePlot()
        {
            _bluerDialog = Main.Instance.GuiManager.ShowBluer();
            _bluerDialog.Init(_data.Title, _data.DescriptionText, _data.TimeWriting, _data.SkipOpenAnimation, () =>
            {
                _bluerDialog.Hide();
                _isCompleted = true;
            });
        }

        public override void CompletePlot()
        {
        }

        public override bool CheckCompletionCondition()
        {
            return _isCompleted;
        }
    }
}