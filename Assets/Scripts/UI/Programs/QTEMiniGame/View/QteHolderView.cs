using UI.Programs.QTEMiniGame.VIewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.QTEMiniGame.View
{
    public class QteHolderView : MonoBehaviour
    {
        [SerializeField] private GameObject _qteButtonImgPrefab;
        
        private GameObject _qteButton;
        private Text _qteButtonText;

        public void Init()
        {
            _qteButton = Instantiate(_qteButtonImgPrefab, transform, false);
            _qteButton.SetActive(false);
            _qteButtonText = _qteButton.GetComponentInChildren<Text>();
        }

        public void ViewButtonWithKey(string key)
        {
            _qteButtonText.text = key;
            _qteButton.SetActive(true);
        }

        public void HideButton()
        {
            _qteButton.SetActive(false);
        }

        public bool ButtonIsActive()
        {
            return _qteButton.activeSelf;
        }
    }
}