#nullable enable
using System;
using UI.Programs.PDF.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.PDF.View
{
    public class PDFView : MonoBehaviour
    {
        private Text _text = null!;

        public void Init(string text)
        {
            _text = this.GetComponent<Text>();
            _text.text = text;
        }
    }
}
