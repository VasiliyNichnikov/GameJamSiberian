using UnityEngine;

namespace Configs.Plot
{
    [CreateAssetMenu(fileName = "MiniGamePlotData", menuName = "Configs/MiniGamePlotData", order = 0)]
    public class MiniGamePlotData : ScriptableObject
    {
        public MiniGameType MiniGameType => _miniGameType;

        [SerializeField] private MiniGameType _miniGameType;
    }
}