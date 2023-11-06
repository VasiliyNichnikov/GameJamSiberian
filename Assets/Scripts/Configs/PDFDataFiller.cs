#nullable enable
using UI.Programs.PDF;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PDFData", menuName = "Configs/PDFData", order = 0)]
    public class PDFDataFiller : ScriptableObject
    {
        public string Text => _text;
        [SerializeField, TextArea, Header("Заполнение инструкции")] private string _text = null!;
    }
}
