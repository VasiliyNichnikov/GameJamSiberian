#nullable enable
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Desktop.View
{
    public class WarningDialog : BaseDialog
    {
        [SerializeField] private Text _title = null!;
        [SerializeField] private Text _description = null!;
        [SerializeField] private Text _buttonText = null!;

        private Action _onClickHandler = null!;
        
        public void Init(string title, string description, string buttonText, Action onClickHandler)
        {
            _title.text = title;
            _description.text = description;
            _buttonText.text = buttonText;
            _onClickHandler = onClickHandler;
        }

        public void OnButtonClick()
        {
            _onClickHandler?.Invoke();
        }
        
    }
}