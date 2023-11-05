#nullable enable
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public class DiskSelectionViewModel : IDiskSelectionViewModel
    {
        public string Title { get; }
        public string DescriptionText { get; }
        public IReactiveProperty<IDiskBlockViewModel?> SelectedDisk => _selectedDisk;
        public IReadOnlyCollection<IDiskBlockViewModel> Disks => _disks;

        private readonly ReactiveProperty<IDiskBlockViewModel?>
            _selectedDisk = new ReactiveProperty<IDiskBlockViewModel?>();
        private readonly List<DiskBlockViewModel> _disks;

        public DiskSelectionViewModel()
        {
            var selectionData = DataHelper.Instance.InstallerData.GetDiskSelectionData();
            Title = selectionData.TitleText;
            DescriptionText = selectionData.DescriptionText;
            _disks = new List<DiskBlockViewModel>();
            for (var i = 0; i < selectionData.Disks.Count; i++)
            {
                // Начинаем с 1 считать
                var indexDisk = i + 1;
                var isCorrectedDisk = indexDisk == selectionData.NumberOfCorrectedDisk;
                var data = selectionData.Disks[i];
                _disks.Add(new DiskBlockViewModel(data, isCorrectedDisk, () => OnClickDisk(indexDisk)));
            }
        }

        private void OnClickDisk(int indexDisk)
        {
            var listIndex = indexDisk - 1;
            if (listIndex < 0 || listIndex >= _disks.Count)
            {
                Debug.LogError($"DiskSelectionViewModel: not corrected index: {listIndex}");
                return;
            }

            foreach (var disk in _disks)
            {
                disk.CancelDiskSelection();
            }
            var selectedDisk = _disks[listIndex];
            selectedDisk.SelectDisk();
            _selectedDisk.Value = selectedDisk;
        }

        public bool GetSelectedDiskState()
        {
            if (_selectedDisk.Value != null)
            {
                if (_selectedDisk.Value.IsCorrectedDisk == true)
                    return true;
            }

            return false;
        }
    }
}