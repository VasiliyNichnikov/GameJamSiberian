using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Configs;
using UniRx;
using UnityEngine;

namespace UI.Programs.PDF.ViewModel
{
    public class PDFViewModel
    {
        PDFDataFiller _data = null!;
        public PDFViewModel()
        {

            _data = DataHelper.Instance.PDFDataFiller;
        }

        public PDFDataFiller getData()
        {
            return _data;
        }
    }
}
