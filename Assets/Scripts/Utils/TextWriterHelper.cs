#nullable enable
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class TextWriterHelper
    {
        public static IEnumerator AnimationWritingText(Text text, string textToWrite, float timePerCharacter)
        {
            var characterIndex = 0;
            var timer = 0.0f;
            while (characterIndex < textToWrite.Length)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer += timePerCharacter;
                    characterIndex++;
                    text.text = textToWrite.Substring(0, characterIndex);
                }

                yield return null;
            }
        }
    }
}