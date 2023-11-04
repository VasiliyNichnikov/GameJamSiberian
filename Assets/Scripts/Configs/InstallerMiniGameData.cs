#nullable enable
using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "InstallerMiniGameData", menuName = "Configs/InstallerMiniGameData", order = 0)]
    public class InstallerMiniGameData : ScriptableObject
    {
        public WelcomeData GetWelcomeData() => _welcomeData;
        public DiskSelectionData GetDiskSelectionData() => _diskSelectionData;
        public DeselectTogglesData GetDeselectTogglesData() => _deselectTogglesData;

        public SimulationInstallationData GetSimulationInstallationData() => _simulationInstallationData;

        [Serializable]
        public struct WelcomeData
        {
            public string Title => _title;
            public string Description => _description;

            [SerializeField] private string _title;
            [SerializeField, TextArea] private string _description;
        }
        
        [Serializable]
        public struct DiskData
        {
            public float OccupiedSpace => _occupiedSpace;
            public string NameDisk => _nameDisk;
            public string AmountOfSpace => _amountOfSpace;

            [SerializeField] private string _nameDisk;
            [SerializeField] private string _amountOfSpace;
            [SerializeField, Range(0f, 1f)] private float _occupiedSpace;
        }
        
        [Serializable]
        public struct DiskSelectionData
        {
            public string TitleText => _titleText;
            public string DescriptionText => _descriptionText;
            public int NumberOfCorrectedDisk => _numberOfCorrectedDisk;
            public ReadOnlyCollection<DiskData> Disks => new ReadOnlyCollection<DiskData>(_disks);

            [SerializeField] private string _titleText;
            [SerializeField, TextArea] private string _descriptionText;
            [SerializeField, Header("Номер правильного диска (Задается от 1)")] private int _numberOfCorrectedDisk;
            [SerializeField] private DiskData[] _disks;
        }
        
        [Serializable]
        public struct ToggleData
        {
            public string Description => _descriptionText;
            
            [SerializeField] private string _descriptionText;
        }
        
        [Serializable]
        public struct DeselectTogglesData
        {
            public string TitleText => _titleText;
            public string DescriptionText => _descriptionText;
            public ReadOnlyCollection<ToggleData> TogglesData => new ReadOnlyCollection<ToggleData>(_togglesData);
            
            [SerializeField] private string _titleText;
            [SerializeField, TextArea] private string _descriptionText;
            [SerializeField] private ToggleData[] _togglesData;
        }
        
        [Serializable]
        public struct SimulationInstallationData
        {
            public string TitleText => _titleText;
            public string DescriptionText => _descriptionText;
            
            [SerializeField] private string _titleText;
            [SerializeField, TextArea] private string _descriptionText; 
        }

        [SerializeField] private WelcomeData _welcomeData;
        [SerializeField] private DiskSelectionData _diskSelectionData;
        [SerializeField] private DeselectTogglesData _deselectTogglesData;
        [SerializeField] private SimulationInstallationData _simulationInstallationData;
    }
}