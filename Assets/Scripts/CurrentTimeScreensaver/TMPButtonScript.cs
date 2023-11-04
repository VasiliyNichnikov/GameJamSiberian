using UnityEngine;

namespace CurrentTimeScreensaver
{
    public class TMPButtonScript : MonoBehaviour
    {
        public CurrentTimeScreensaver ScreenSaver;
        public bool Flag = true;
    
        public void OnButtonClick()
        {
            if (Flag) // рассветление
            {
                StartCoroutine(ScreenSaver.InTime("20:34"));
                Debug.Log("InTimeMethod");
            }
            else
            {
                StartCoroutine(ScreenSaver.OutTime());
                Debug.Log("OutTimeMethod");
            }
            
            Flag = !Flag;
        }
    }
}
