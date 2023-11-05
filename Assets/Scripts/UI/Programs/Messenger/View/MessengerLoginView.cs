#nullable enable
using UI.Programs.Messenger.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.Messenger.View
{
    public class MessengerLoginView : MonoBehaviour
    {
        [SerializeField] private InputField _login = null!;
        [SerializeField] private InputField _password = null!;

        private IMessengerLoginViewModel _viewModel = null!;
        
        public void Init(IMessengerLoginViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnClickEnterButton()
        {
            _viewModel.TryToLogInChat(_login.text, _password.text);
        }
    }
}