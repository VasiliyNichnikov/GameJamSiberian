using System;

namespace UI.Programs.Messenger.ViewModel
{
    public interface IMessengerViewModel : IDisposable
    {
        ILeftPanelViewModel LeftPanelViewModel { get; }
        IChatViewModel ChatViewModel { get; }
    }
}