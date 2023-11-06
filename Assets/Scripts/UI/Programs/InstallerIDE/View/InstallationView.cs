#nullable enable
using System.Collections;
using UI.Programs.InstallerIDE.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.InstallerIDE.View
{
    public class InstallationView : MonoBehaviour
    {
        [SerializeField] private Text _description = null!;
        [SerializeField] private GameObject _loaderComponent = null!;
        [SerializeField] private RectTransform _loadersHolder = null!;
        [SerializeField] private GameObject _closeButtonObject = null!;

        private IEnumerator? _animation;
        private IInstallationViewModel _viewModel = null!;

        private void Start()
        {
            _closeButtonObject.SetActive(false);
        }

        public void Init(IInstallationViewModel viewModel)
        {
            if (_animation != null)
            {
                Debug.LogError("InstallationView.Init: animation is not null");
                return;
            }

            gameObject.UpdateViewModel(ref _viewModel, viewModel);
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
            for (var i = 0; i < 29; i++)
            {
                Instantiate(_loaderComponent, _loadersHolder);
                yield return new WaitForSeconds(Random.Range(0.15f, 0.5f));
            }
            
            _closeButtonObject.SetActive(true);
        }
    }
}