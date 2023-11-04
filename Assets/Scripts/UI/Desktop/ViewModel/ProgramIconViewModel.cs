using System;
using Configs;
using UnityEngine;

namespace UI.Desktop.ViewModel
{
    public class ProgramIconViewModel : IProgramIconViewModel
    {
        public Sprite Icon { get; }
        public string Name { get; }
        public ProgramType Type => _programData.Context.ProgramType;
        
        private readonly Action _onClickHandler;

        private IProgram _programData;
        
        public ProgramIconViewModel(IProgram info)
        {
            var data = DataHelper.Instance.ProgramsIconData.GetIconDataByType(info.Context.ProgramType);
            Icon = data.Sprite;
            Name = data.Name;
            _programData = info;
        }

        public void UpdateProgram(IProgram info)
        {
            _programData = info;
        }
        
        public void OnClickHandler()
        {
            if (!_programData.Context.AllowProgramToRun)
            {
                return;
            }

            _programData.OnClickHandler();
        }
    }
}