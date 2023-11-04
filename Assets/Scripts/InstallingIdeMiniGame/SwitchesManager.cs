using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace InstallingIdeMiniGame
{
    public class SwitchesManager : MonoBehaviour
    {
        public MiniGameLogic GameLogic;
        
        public Toggle TogglePrefab;
        public int SwitchNumber;
        public readonly List<Toggle> Switches = new List<Toggle>();
        
        private void Start()
        {
            SpawnSwitches();
        }

        private void SpawnSwitches()
        {
            for (int i = 0; i < SwitchNumber; ++i)
            {
                Switches.Add(Instantiate(TogglePrefab, this.transform, false));
                Switches[i].SetIsOnWithoutNotify(true);
            }
        }
        
        public void SetVisible(bool flag)
        {
            foreach (var toggle in Switches)
            {
                toggle.GameObject().SetActive(flag);
            }
        }
    }
}
