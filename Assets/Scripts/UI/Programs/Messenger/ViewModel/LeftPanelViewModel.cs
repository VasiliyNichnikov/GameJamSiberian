#nullable enable
using System.Collections.Generic;
using System.Linq;

namespace UI.Programs.Messenger.ViewModel
{
    public class LeftPanelViewModel : ILeftPanelViewModel
    {
        public IReadOnlyCollection<IUserBlockViewModel> UsersViewModel { get; }

        private readonly MessengerFacade _facade;

        public LeftPanelViewModel(MessengerFacade facade)
        {
            _facade = facade;
            UsersViewModel = _facade.AllUserTypes.Select(type => new UserBlockViewModel(type, () => OnClickUser(type))).ToList();
        }
        
        private void OnClickUser(UserType type) => _facade.SelectUserChat(type);
    }
}