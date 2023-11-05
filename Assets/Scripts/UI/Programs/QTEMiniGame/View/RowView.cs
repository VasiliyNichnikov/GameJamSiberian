#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.QTEMiniGame.View
{
    public class RowView : MonoBehaviour
    {
        public Text RowNumber => _rowNumber;
        public Text RowValue => _rowValue;
        
        [SerializeField] private Text _rowNumber = null!;
        [SerializeField] private Text _rowValue = null!;
    }
}