#nullable enable
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Вешается на компонент
    /// И если выполнится код Click Utils
    /// То будем брать данные от сюда
    /// </summary>
    public class DisplayBlocker : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _group = null!;

        public void OffClicks() => _group.blocksRaycasts = false;
        public void OnClicks() => _group.blocksRaycasts = true;
    }
}