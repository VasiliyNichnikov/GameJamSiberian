using System.Collections;
using UI.Programs.QTEMiniGame.VIewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.QTEMiniGame.View
{
    public class QteMiniGameView : BaseDialog
    {
        public QteEditorView EditorView;
        public QteHolderView HolderView;
        public Button BuildButton;

        private bool _timeIsOut = false;
        private bool _timerHasStop = false;

        private Coroutine _writer;
        private Coroutine _deleter;
        private Coroutine _timer;

        private int _target;
        private int _total;
        
        private bool _isInitialized;

        private IQteMiniGameViewModel _viewModel;
        
        public void Init(IQteMiniGameViewModel viewModel)
        {
            _viewModel = viewModel;
            HolderView.Init();
            EditorView.Init(_viewModel.EditorViewModel);

            BuildButton.interactable = false;

            _target = 0;
            _total = 0;
            
            _writer = StartCoroutine(EditorView.TextAnimationWrite());

            _isInitialized = true;
            StartCoroutine(KeyDown(true));
        }
        
        private void Update()
        {
            if (!_isInitialized)
            {
                return;
            }
            
            if (EditorView.IsAllText)
            {
                if (!_viewModel.IsKeyNeed && HolderView.ButtonIsActive())
                {
                    HolderView.HideButton();
                }

                if(!BuildButton.interactable)
                    BuildButton.interactable = true;
                return;
            }
            
            if (_viewModel.IsKeyNeed && !_timerHasStop)
                _timer = StartCoroutine(TimerForDown());
            
            if (Input.anyKeyDown || _timeIsOut) // нажали клавишу 
            {
                if (_viewModel.IsKeyNeed && Input.GetKeyDown(_viewModel.CurrentNeedKey) && !_timeIsOut) // она нужна + совпала + время не вышло
                {
                    _viewModel.IsKeyNeed = false;
                    StartCoroutine(KeyDown(true));
                }
                else if (_viewModel.IsKeyNeed && (!Input.GetKeyDown(_viewModel.CurrentNeedKey) || _timeIsOut)) // она нужна + не совпала или вышло время
                {
                    _viewModel.IsKeyNeed = false;
                    StartCoroutine(KeyDown(false));
                }
            }

            // Если нужна клавиша и она не отрисована, то рисуем или убираем
            if (_viewModel.IsKeyNeed && !HolderView.ButtonIsActive())
            {
                HolderView.ViewButtonWithKey(_viewModel.CurrentNeedKey.ToString());
            }
            else if (!_viewModel.IsKeyNeed && HolderView.ButtonIsActive())
            {
                HolderView.HideButton();
            }
        }

        private IEnumerator KeyDown(bool isCorrect)
        {
            if(_timer != null)
            {
                StopCoroutine(_timer);
            }
            
            if (isCorrect)
            {
                yield return new WaitForSecondsRealtime(_viewModel.TimeBetweenQte); // ожидаем до следующего QTE, говорим что нужна клавиша и генерируем ее
                _viewModel.GenerateNewKey();
                _viewModel.IsKeyNeed = true;
                _timeIsOut = false;
                _timerHasStop = false;

                ++_target;
            }
            else
            {
                StopCoroutine(_writer);
                yield return StartCoroutine(EditorView.TextAnimationDelete());
                
                yield return new WaitForSecondsRealtime(_viewModel.TimeBetweenQte); // ожидаем до следующего QTE, говорим что нужна клавиша и генерируем ее
                _viewModel.GenerateNewKey();
                _viewModel.IsKeyNeed = true;
                _timeIsOut = false;
                _timerHasStop = false;

                _writer = StartCoroutine(EditorView.TextAnimationWrite());
            }

            ++_total;
            
            if(_total > _viewModel.NumberForRecalculate)
            {
                Debug.Log($"TargetTime = {_target} TotalTime = {_total}");
                _viewModel.SetCalcAccuracy(_target, _total);
                if (_viewModel.EditQteParam())
                {
                    _target = 0;
                    _total = 0;
                }
                Debug.Log($"QTE_time = {_viewModel.QteTime} TimeBetweenQTE = {_viewModel.TimeBetweenQte}");
            }
        }

        private IEnumerator TimerForDown()
        {
            _timerHasStop = true; // чтобы не запускалась несколько корутин
            yield return new WaitForSecondsRealtime(_viewModel.QteTime); // даем время нажать на клавишу
            _timeIsOut = true;
        }

        public void OnBuildButtonClick()
        {
            // TODO: выход из мини-игры
        }
    }
}