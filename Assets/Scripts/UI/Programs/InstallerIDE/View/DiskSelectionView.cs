#nullable enable
using System.Collections.Generic;
using UI.Programs.InstallerIDE.ViewModel;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.InstallerIDE.View
{
    public class DiskSelectionView : MonoBehaviour
    {
        [SerializeField] private Text _description = null!;
        [SerializeField] private RectTransform _disksHolder = null!;
        [SerializeField] private DiskBlockView _diskBlockPrefab = null!;
        
        private IDiskSelectionViewModel _viewModel = null!;

        public void Init(IDiskSelectionViewModel viewModel)
        {
            _viewModel = viewModel;
            _description.text = _viewModel.DescriptionText;
            
            CreateDisks();
        }

        private void CreateDisks()
        {
            _disksHolder.transform.DestroyChildren();
            foreach (var viewModel in _viewModel.Disks)
            {
                var view = Instantiate(_diskBlockPrefab, _disksHolder, false);
                view.Init(viewModel);
            }
        }
    }
}