using System.Collections;
using System.Linq;
using UI.Programs.QTEMiniGame.VIewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.QTEMiniGame.View
{
    public class QteEditorView : MonoBehaviour
    {
        [SerializeField] private RowView _rowPrefab;
        
        private RowView _createdRow;
        private Text _editorText;
        private Text _rowNumberText;
        
        private IQteEditorViewModel _viewModel;
        
        private int _currentPos;
        private int _currentLine;
        private int _savePos;

        public bool IsAllText { get; private set; }
        private bool _isLineEnd;
        
        public void Init(IQteEditorViewModel viewModel)
        {
            _viewModel = viewModel;
            IsAllText = false;
            _isLineEnd = true;
            _currentPos = 0;
            _savePos = 0;
            _currentLine = 0;
        }

        // TODO: Когда текст уходит за првую гараницу, то он закрывает номер строки (для текущего конфига 18 строка)
        public IEnumerator TextAnimationWrite()
        {
            for(; _currentLine < _viewModel.ProgramText.Count; ++_currentLine)
            {
                if(_isLineEnd)
                {
                    _createdRow = Instantiate(_rowPrefab, transform, false);
                    _editorText = _createdRow.RowValue;
                    _rowNumberText = _createdRow.RowNumber;
                    _isLineEnd = false;
                }

                _rowNumberText.text = (_currentLine + 1).ToString();
                
                _currentPos = _savePos;
                for (var i = _currentPos; i < _viewModel.ProgramText[_currentLine].Length; ++i)
                {
                    _editorText.text += _viewModel.ProgramText[_currentLine][i];
                    _savePos = i;
                    yield return new WaitForSecondsRealtime(_viewModel.Delay);
                }

                _savePos = 0;
                _currentPos = 0;
                _isLineEnd = true;
            }

            IsAllText = true;
        }

        public IEnumerator TextAnimationDelete()
        {
            _currentPos = _savePos;
            for (var i = _currentPos; i >= 0 && i > _editorText.text.Length - _viewModel.NumberSymbolsForDeleteInIteration; i--)
            {
                _editorText.text = _editorText.text[..^1];
                _savePos = i;
                yield return new WaitForSecondsRealtime(_viewModel.Delay / 2);
            }
        }
    }
}