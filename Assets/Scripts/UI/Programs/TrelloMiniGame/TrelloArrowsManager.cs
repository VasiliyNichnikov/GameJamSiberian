#nullable enable
using UnityEngine;

namespace UI.Programs.TrelloMiniGame
{
    public interface IArrowObject
    {
        int ColumnNumber { get; }
        
        void MoveLeft();
        void MoveRight();
    }
    
    public class TrelloArrowsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _leftArrow = null!;
        [SerializeField] private GameObject _rightArrow = null!;

        private IArrowObject? _arrowObject;
        
        public void Init(IArrowObject arrowObject)
        {
            _arrowObject = arrowObject;
            _leftArrow.SetActive(arrowObject.ColumnNumber != 0);
            _rightArrow.SetActive(arrowObject.ColumnNumber != 3);
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
        }
    }
}