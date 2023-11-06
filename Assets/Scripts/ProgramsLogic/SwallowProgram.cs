#nullable enable
using Configs;
using UI.Desktop;
using UI.Programs;
using UI.Programs.Messenger;
using UI.Programs.Messenger.View;
using UI.Programs.Messenger.ViewModel;

namespace ProgramsLogic
{
    /// <summary>
    /// Ласточка (Мессенджер)
    /// </summary>
    public class SwallowProgram : ProgramData
    {
        public IMessengerManager Manager => _manager;
        public override ProgramType Type => ProgramType.Swallow;
        private readonly MessengerManager _manager;
        
        public SwallowProgram(DesktopProgramContext context) : base(context)
        {
            _manager = new MessengerManager();
        }

        protected override void OnClickHandlerBase()
        {
            var dialog = Main.Instance.GuiManager.ShowDialog<MessengerDialog>();
            dialog.Init(new MessengerViewModel(_manager));
            dialog.SetHideAction(CloseProgram);
            OpenProgram(dialog);
        }
    }
}