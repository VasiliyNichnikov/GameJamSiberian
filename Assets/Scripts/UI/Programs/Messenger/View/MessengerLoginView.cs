#nullable enable
using DG.Tweening;
using UI.Programs.Messenger.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.Messenger.View
{
    public class MessengerLoginView : MonoBehaviour
    {
        [SerializeField] private InputField _login = null!;
        [SerializeField] private InputField _password = null!;
        [SerializeField] private float _timeAnimation;
        [SerializeField] private CanvasGroup _canvasGroup = null!;
        
        private IMessengerLoginViewModel _viewModel = null!;
        
        public void Init(IMessengerLoginViewModel viewModel)
        {
            gameObject.UpdateViewModel(ref _viewModel, viewModel);
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnClickEnterButton()
        {
            var result = _viewModel.TryToLogInChat(_login.text, _password.text);
            if (!result)
            {
                var passwordTransform = _password.transform;
                LockClicks();
                PingPong(passwordTransform, passwordTransform.position.x, passwordTransform.position.x + 7.5f);
            }
        }

        private void LockClicks() => _canvasGroup.blocksRaycasts = false;
        private void UnlockClicks() => _canvasGroup.blocksRaycasts = true;
        
        private void PingPong(Transform transform, float from, float to, bool lastMove = false)
        {
            transform.DOLocalMoveX(to, _timeAnimation).OnComplete(() =>
            {
                if (lastMove)
                {
                    UnlockClicks();
                    return;
                }

                PingPong(transform, to, from, true);
            });
        }
    }
}