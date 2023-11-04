#nullable enable
using System.Collections;
using UI.Programs.InstallerIDE.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.InstallerIDE.View
{
    public class InstallationView : MonoBehaviour
    {
        [SerializeField] private Text _description = null!;
        [SerializeField] private GameObject _loaderComponent = null!;
        [SerializeField] private RectTransform _loadersHolder = null!;

        private IEnumerator? _animation;
        private IInstallationViewModel _viewModel = null!;
        
        public void Init(IInstallationViewModel viewModel)
        {
            if (_animation != null)
            {
                Debug.LogError("InstallationView.Init: animation is not null");
                return;
            }
            
            _viewModel = viewModel;
            _description.text = viewModel.DescriptionText;
            _animation = LoadingAnimation();
            StartCoroutine(_animation);
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnCloseButton()
        {
            _viewModel.OnClickCloseHandler();
        }
        
        /// <summary>
        /// Симуляция загрузки
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadingAnimation()
        {
            yield return null;
        }
        
    }
}