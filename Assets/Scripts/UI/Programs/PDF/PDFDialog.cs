#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.PDF.View
{

    public class PDFDialog : BaseDialog
    {
        [SerializeField] private Text _mainContentText = null!;

        private void Start()
        {
            var data = DataHelper.Instance.PdfDataFiller.Text;
            _mainContentText.text = data;
        }
    }
}
