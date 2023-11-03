using System.Collections.Generic;

namespace UI.Programs.Messenger.ViewModel
{
    public interface ILeftPanelViewModel
    {
        IReadOnlyCollection<IUserBlockViewModel> UsersViewModel { get; }
    }
}