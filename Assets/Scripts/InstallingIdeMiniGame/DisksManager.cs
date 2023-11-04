using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace InstallingIdeMiniGame
{
    public class DisksManager : MonoBehaviour
    {
        public MiniGameLogic GameLogic;
        
        public Button DiskPrefab;
        public int DiskNumber;
        private readonly List<Button> _disks = new List<Button>();
        public List<int> MaxDiskSize = new List<int>();

        public Button SelectedDisk;

        public string ButtonText = "Свободно {0}ГЯщеров из {1}ГЯщеров";
        public void Start()
        {
            SpawnDisks();
        }

        public void SetVisible(bool flag)
        {
            foreach (var disk in _disks)
            {
                disk.GameObject().SetActive(flag);
            }
        }

        public int GetIdByDisk(Button disk)
        {
            for (int i = 0; i < _disks.Count; ++i)
            {
                if (_disks[i] == disk)
                    return i;
            }

            throw new ArgumentException("There is no such disk.");
        }
        
        private void SpawnDisks()
        {
            for (int i = 0; i < DiskNumber; ++i)
            {
                var tDisk = Instantiate(DiskPrefab, this.transform, false);
                _disks.Add(tDisk);
                tDisk.GetComponentInChildren<Text>().text = string.Format(ButtonText, GameLogic.GetFreeSpaceById(i), 900);
                tDisk.onClick.AddListener(() => OnDiskClick(tDisk));
            }
        }

        private void OnDiskClick(Button buttonClicked)
        {
            SelectedDisk = buttonClicked;
            SelectSelectedDisk(buttonClicked);
        }
        
        private void SelectSelectedDisk(Button disk) // TODO: Уточнить, как именно надо выделить диск
        {
            disk.GetComponent<Image>().color = GameLogic.IsCorrectDiskSelected(GetIdByDisk(disk)) ? Color.cyan : Color.red;
        }
    }
}
