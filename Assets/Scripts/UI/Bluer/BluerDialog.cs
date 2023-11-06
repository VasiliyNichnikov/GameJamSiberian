#nullable enable
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Bluer
{
    public class BluerDialog : BaseDialog
    {
        private const float OpenCloseAnimationTime = 0.45f;
        
        [SerializeField] private Text _title = null!;
        [SerializeField] private GameObject _continueButton = null!;
        [SerializeField] private Text _description = null!;
        [SerializeField] private CanvasGroup _group = null!;
        [SerializeField] private AnimationCurve _openCloseCurve = null!;
        
        private Action _onContinueButtonHandler = null!;
        private IEnumerator? _writingAnimation;

        private void Awake()
        {
            _group.alpha = 0;
            _group.blocksRaycasts = true;
            _continueButton.SetActive(false);
        }

        public void Init(string title, string description, float timeWriting, bool skipOpenAnimation, Action onContinueButtonHandler)
        {
            if (_writingAnimation != null)
            {
                Debug.LogError("BluerDialog.Init: writing animation is null");
                return;
            }

            _title.gameObject.SetActive(title != string.Empty);
            if (title != string.Empty)
            {
                _title.text = title;
            }
            _onContinueButtonHandler = onContinueButtonHandler;
            _writingAnimation = WritingAnimation(description, timeWriting, skipOpenAnimation);
            StartCoroutine(_writingAnimation);
        }

        private IEnumerator WritingAnimation(string textWriting, float timeWriting, bool skipOpenAnimation)
        {
            if (!skipOpenAnimation)
            {
                yield return AnimationWithProgress(progress => _group.alpha = progress, () => _group.alpha = 1.0f);
            }
            else
            {
                _group.alpha = 1.0f;
            }
            var timePerCharacter = timeWriting /textWriting.Length;
            yield return TextWriterHelper.AnimationWritingText(_description, textWriting, timePerCharacter);
            OnCompleteAnimation();
        }

        /// <summary>
        /// По идеи можно переиспользовать и вынести
        /// </summary>
        private IEnumerator AnimationWithProgress(Action<float> animationWithProgress, Action onComplete)
        {
            var timer = OpenCloseAnimationTime;
            while (timer >= 0.0f)
            {
                var progress = Mathf.Clamp01(timer / OpenCloseAnimationTime);
                animationWithProgress.Invoke(_openCloseCurve.Evaluate(progress));
                yield return null;
                timer -= Time.deltaTime;
            }

            onComplete.Invoke();
        }
        
        private void OnCompleteAnimation()
        {
            _continueButton.SetActive(true);
            _writingAnimation = null;
        }
        
        /// <summary>
        /// Called from unity
        /// </summary>
        public void OnContinueButton()
        {
            _onContinueButtonHandler.Invoke();
        }
    }
}