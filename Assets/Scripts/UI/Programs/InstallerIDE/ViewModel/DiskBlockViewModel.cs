#nullable enable
using System;
using Configs;
using UniRx;
using UnityEngine;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class DiskBlockViewModel : IDiskBlockViewModel
    {
        public IReactiveProperty<bool> IsSelected => _isSelected;
        public string NameDisk { get; }
        public string AmountOfSpace { get; }
        public float OccupiedSpace { get; }
        public bool IsCorrectedDisk { get; }

        private const int MaxStorageGB = 30;
        
        private readonly ReactiveProperty<bool> _isSelected = new ReactiveProperty<bool>();
        private readonly Action _onClickHandler;
        
        public DiskBlockViewModel(InstallerMiniGameData.DiskData data, bool isCorrectedDisk, Action onClickHandler)
        {
            OccupiedSpace = data.OccupiedSpace;
            NameDisk = data.NameDisk;
            var freeStorage = MaxStorageGB - Mathf.CeilToInt(data.OccupiedSpace * MaxStorageGB);
            AmountOfSpace = string.Format(data.AmountOfSpace, freeStorage, MaxStorageGB);
            IsCorrectedDisk = isCorrectedDisk;
            _onClickHandler = onClickHandler;
            
        }

        public void OnClickHandler() => _onClickHandler.Invoke();


        public void SelectDisk()
        {
            _isSelected.Value = true;
        }

        public void CancelDiskSelection()
        {
            _isSelected.Value = false;
        }

        


    }
}