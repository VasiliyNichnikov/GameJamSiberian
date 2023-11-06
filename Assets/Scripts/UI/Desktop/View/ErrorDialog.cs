using UnityEngine;
using UnityEngine.UI;

namespace UI.Desktop.View
{
    public class ErrorDialog : BaseDialog
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _description;
        [SerializeField] private Text _buttonText;

        public void Init(string title, string description, string buttonText = "Ok")
        {
            _title.text = title;
            _description.text = description;
            _buttonText.text = buttonText;
        }

        public void OnButtonClick()
        {
            // TODO: желаемеое действие
        }
        
    }
}