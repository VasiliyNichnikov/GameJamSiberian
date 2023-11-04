using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CurrentTimeScreensaver
{
    // TODO: подумать, может написать метод для сброса состояния текста.
    public class CurrentTimeScreensaver : MonoBehaviour
    {
        public Text TimeText;
        public Image FadeImage;
        public float FadeSpeed;

        public IEnumerator InTime(string currentTime)
        {
            SetTime(currentTime);
            
            var imageColor = FadeImage.color;
            var textColor = TimeText.color;
            
            while (imageColor.a < 1f)
            {
                imageColor.a += Mathf.Lerp(0f, 1f, FadeSpeed * Time.deltaTime);

                if (imageColor.a > 0.3f)
                    textColor.a += Mathf.Lerp(0f, 1f, 1.7f * FadeSpeed * Time.deltaTime);
                
                FadeImage.color = imageColor;
                TimeText.color = textColor;
                
                yield return null;
            }
        }

        public IEnumerator OutTime()
        {
            var imageColor = FadeImage.color;
            var textColor = TimeText.color;
            
            while (imageColor.a > 0f)
            {
                imageColor.a -= Mathf.Lerp(0f, 1f, FadeSpeed * Time.deltaTime);
                
                if(textColor.a > 0f)
                    textColor.a -= Mathf.Lerp(0f, 1f, 2f * FadeSpeed * Time.deltaTime);
                
                FadeImage.color = imageColor;
                TimeText.color = textColor;
                
                yield return null;
            }
            
            TimeText.GameObject().SetActive(false);
            textColor.a = 1f;
            TimeText.color = textColor;
        }
        
        private void SetTime(string currentTime)
        {
            TimeText.text = currentTime; 
            var textColor = TimeText.color;
            textColor.a = 0f;
            TimeText.color = textColor;
            TimeText.GameObject().SetActive(true);
        }
    }
}
