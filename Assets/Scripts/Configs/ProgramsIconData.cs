#nullable enable
using System;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ProgramsIconData", menuName = "Configs/ProgramsIconData", order = 0)]
    public class ProgramsIconData : ScriptableObject
    {
        [Serializable]
        public struct ProgramIconData
        {
            public ProgramType Type => _type;
            public string Name => _name;
            public Sprite Sprite => _sprite;
            
            [SerializeField] private ProgramType _type;
            [SerializeField] private Sprite _sprite;
            [SerializeField] private string _name;
        }

        [SerializeField] private ProgramIconData[] _programIcons = null!;

        public ProgramIconData GetIconDataByType(ProgramType type) => _programIcons.First(data => data.Type == type);
    }
}