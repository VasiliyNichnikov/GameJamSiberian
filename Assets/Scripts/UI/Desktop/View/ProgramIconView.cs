#nullable enable
using ProgramsLogic;
using UI.Desktop.ViewModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Desktop.View
{
    public class ProgramIconView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _icon = null!;
        [SerializeField] private Text _name = null!;
        [SerializeField] private GameObject _selectionIcon = null!;

        private IProgram _program = null!;
        
        public void Init(IProgram program)
        {
            _program = program;

            _name.text = _program.Name;
            _icon.sprite = _program.Icon;
        }

        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnClickButton()
        {
            _program.OnClickHandler();
        }

        public void OnPointerEnter(PointerEventData eventData) => _selectionIcon.SetActive(true);

        public void OnPointerExit(PointerEventData eventData) => _selectionIcon.SetActive(false);
    }
}