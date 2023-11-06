namespace UI.Programs.Messenger.ViewModel
{
    public interface IMessengerLoginViewModel
    {
        bool TryToLogInChat(string login, string password);
    }
}