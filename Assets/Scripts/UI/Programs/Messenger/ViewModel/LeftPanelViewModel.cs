#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Programs.Messenger.ViewModel
{
    public class LeftPanelViewModel : ILeftPanelViewModel, IDisposable
    {
        public IReadOnlyCollection<IUserBlockViewModel> UsersViewModel => _users;
        
        private readonly MessengerManager _manager;
        private readonly List<UserBlockViewModel> _users;

        private UserBlockViewModel? _selectedUser;
        
        public LeftPanelViewModel(MessengerManager manager)
        {
            _manager = manager;
            _users = MessengerManager.AllUserTypes.Select(type => new UserBlockViewModel(type, () => OnClickUser(type))).ToList();
            _manager.OnChatSelected += UpdateChat;
        }

        private void UpdateChat(ChatManager chat)
        {
            var userType = chat.UserData.Type;
            var selectedViewModel = _users.FirstOrDefault(user => user.User == userType);
            if (selectedViewModel == null)
            {
                Debug.LogError("LeftPanelViewModel.UpdateChat: user viewModel is null");
                return;
            }
            // Убираем у предыдущего выделение (если было) и выставляем у следуюещего
            _selectedUser?.RemoveSelection();
            _selectedUser = selectedViewModel;
            _selectedUser.Select();
        }
        
        private void OnClickUser(UserType type) => _manager.SelectUserChat(type); 
        
        public void Dispose()
        {
            _manager.OnChatSelected -= UpdateChat;
        }
    }
}