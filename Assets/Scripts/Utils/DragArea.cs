#nullable enable
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.DraggableUtils
{
    public class DragArea : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
    {
        [SerializeField] private BaseDialog _dialog = null!;
        [SerializeField] private float _speedMovement = 45;
        
        private Vector3 _dragOffset;
        private Camera _camera = null!;
        
        private void Start()
        {
            _camera = Camera.main!;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _dialog.transform.SetAsLastSibling();
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            var dialogTransform = _dialog.transform;
            dialogTransform.SetAsLastSibling();
            _dragOffset = dialogTransform.position - GetMousePosition();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _dialog.transform.position = Vector3.MoveTowards(_dialog.transform.position,
                _dragOffset + GetMousePosition(), _speedMovement * Time.deltaTime);
        }

        private Vector3 GetMousePosition()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.x = Mathf.Clamp(mousePosition.x, 0, Screen.width);
            // TODO захардкодил BottomPanel минимальное значени по оси y
            mousePosition.y = Mathf.Clamp(mousePosition.y, 100, Screen.height);
            
            var worldPosition = _camera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0.0f;
            return worldPosition;
        }
    }
}