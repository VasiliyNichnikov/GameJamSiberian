#nullable enable
using Configs;
using UI;
using UI.Desktop;
using UnityEngine;
using Utils;

namespace ProgramsLogic
{
    public abstract class ProgramData : IProgram
    {
        public Sprite Icon { get; }
        public string Name { get; }
        public bool NeedShowInDesktop => _context.NeedShowInDesktop;
        public abstract ProgramType Type { get; }

        private DesktopProgramContext _context;
        private readonly ProgramState _stateProgram;
        private BaseDialog? _openedDialog;

        protected ProgramData(DesktopProgramContext context)
        {
            var data = DataHelper.Instance.ProgramsIconData.GetIconDataByType(Type);
            Icon = data.Sprite;
            Name = data.Name;
            _stateProgram = new ProgramState();

            _context = context;
        }

        public void UpdateContext(DesktopProgramContext context)
        {
            _context = context;
        }

        protected void OpenProgram(BaseDialog dialog)
        {
            _openedDialog = dialog;
            _stateProgram.Open();
        }

        protected void CloseProgram()
        {
            _openedDialog = null;
            _stateProgram.Close();
        }
        
        public void OnClickHandler()
        {
            if (_stateProgram.IsOpened)
            {
                if (_openedDialog != null)
                {
                    _openedDialog.transform.SetAsLastSibling();
                }
                
                return;
            }

            if (!_context.AllowProgramToRun)
            {
                SimpleDialogsHelper.OpenWarningDialog("Дружина", "Отказано в доступе!");
                return;
            }
            
            OnClickHandlerBase();
        }

        protected abstract void OnClickHandlerBase();
    }
}