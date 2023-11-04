#nullable enable
using UnityEngine;

namespace UI.Programs.TrelloMiniGame
{
    public interface IArrowObject
    {
        RectTransform RectTransform { get; }
        int ColumnNumber { get; }
        
        void MoveLeft();
        void MoveRight();
    }
    
    public class TrelloArrowsManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _arrowsHolder = null!;
        [SerializeField] private GameObject _leftArrow = null!;
        [SerializeField] private GameObject _rightArrow = null!;

        private IArrowObject? _arrowObject;
        
        public void Show(IArrowObject arrowObject)
        {
            _arrowObject = arrowObject;
            _arrowsHolder.gameObject.SetActive(true);
            _arrowsHolder.transform.position = arrowObject.RectTransform.position;
            _leftArrow.SetActive(arrowObject.ColumnNumber != 0);
            _rightArrow.SetActive(arrowObject.ColumnNumber != 3);
        }
        
        private void Hide()
        {
            _arrowsHolder.gameObject.SetActive(false);
        }

        
        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnRightButtonClick()
        {
            if (_arrowObject == null)
            {
                Debug.LogError("TrelloArrowsManager.OnRightButtonClick: arrowObject is null");
                return;
            }

            _arrowObject.MoveRight();
            Hide();
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnLeftButtonClick()
        {
            if (_arrowObject == null)
            {
                Debug.LogError("TrelloArrowsManager.OnLeftButtonClick: arrowObject is null");
                return;
            }

            _arrowObject.MoveLeft();
            Hide();
        }
    }
}