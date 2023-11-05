#nullable enable
using System.Collections.Generic;
using UI.Programs.PDF.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.PDF.View
{

    public class PDFDialog : BaseDialog
    {
        [SerializeField] private PDFView _pdfView = null!;
        private PDFViewModel _viewModel = null!;
        public void Init(PDFViewModel viewModel)
        {
            _viewModel = viewModel;
            _pdfView.Init(_viewModel.getData().Text);
        }
    }
}
