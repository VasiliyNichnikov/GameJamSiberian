#nullable enable
using Unity.VisualScripting;
using UnityEngine;

namespace Configs.Plot
{
    [CreateAssetMenu(fileName = "BlackScreenPlotData", menuName = "Configs/BlackScreenPlotData", order = 0)]
    public class BlackScreenPlotData : ScriptableObject
    {
        public string Title => _title;
        public string DescriptionText => _descriptionText;
        public float TimeWriting => _timeWriting;
        public bool SkipOpenAnimation => _skipOpenAnimation;

        [SerializeField, Header("Не обязательно")] private string _title = null!;
        [SerializeField, TextArea(10, 10)] private string _descriptionText = null!;
        [SerializeField, Range(0, 60), Header("Время сколько будет печаться текст в секундах")] private float _timeWriting;
        [SerializeField, Header("Если стоит галка - пропускаем измение алфы")] private bool _skipOpenAnimation;
    }
}