#nullable enable
using Configs;
using UI.Desktop;
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
        public override ProgramType Type => ProgramType.Swallow;
        private readonly MessengerManager _messengerManager;
        
        public SwallowProgram(DesktopProgramContext context) : base(context)
        {
            _messengerManager = new MessengerManager();
        }

        public override void OnClickHandler()
        {
            if (State.IsOpened)
            {
                return;
            }

            var dialog = Main.Instance.GuiManager.ShowDialog<MessengerDialog>();
            dialog.Init(new MessengerViewModel(_messengerManager));
            State.Open();
        }
    }
}