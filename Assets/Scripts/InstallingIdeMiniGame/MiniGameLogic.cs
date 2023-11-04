using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InstallingIdeMiniGame
{
    public class MiniGameLogic : MonoBehaviour
    {
        public float MinSpaceToInstall;
        public float[] FreeSpacesDisk; // TODO: List<float>

        public float GetFreeSpaceById(int idDisk)
        {
            return FreeSpacesDisk[idDisk];
        }
        
        public bool IsCorrectDiskSelected(int diskId)
        {
            return MinSpaceToInstall <= FreeSpacesDisk[diskId];
        }

        public bool IsCorrectSwitchSelected(List<Toggle> switches)
        {
            foreach(var t in switches)
            {
                if (t.isOn)
                    return false;
            }

            return true;
        }

        public IEnumerator LoadVisualization(Slider installBar, float loadTime)
        {
            float time = 0;

            while(time < loadTime)
            {
                time += Random.Range(0.5f, 1.5f); 

                var part = time / loadTime;
                var sliderPos = installBar.maxValue * part;
                
                installBar.SetValueWithoutNotify(sliderPos);
                
                yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            }
        }
    }
}
