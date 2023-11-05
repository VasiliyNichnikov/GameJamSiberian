#nullable enable
using System.Collections.Generic;
using System.Linq;

namespace UI.Programs.Messenger.ViewModel
{
    public class LeftPanelViewModel : ILeftPanelViewModel
    {
        public IReadOnlyCollection<IUserBlockViewModel> UsersViewModel { get; }

        private readonly MessengerManager _manager;

        public LeftPanelViewModel(MessengerManager manager)
        {
            _manager = manager;
            UsersViewModel = _manager.AllUserTypes.Select(type => new UserBlockViewModel(type, () => OnClickUser(type))).ToList();
        }
        
        private void OnClickUser(UserType type) => _manager.SelectUserChat(type);
    }
}