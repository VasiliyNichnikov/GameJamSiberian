using System;
using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public interface IMessengerViewModel : IDisposable
    {
        IReactiveProperty<bool> IsLoginState { get; }
        IReactiveProperty<bool> IsChatState { get; }
        
        IMessengerLoginViewModel LoginViewModel { get; }
        ILeftPanelViewModel LeftPanelViewModel { get; }
        IChatViewModel ChatViewModel { get; }
    }
}