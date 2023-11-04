#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.TrelloMiniGame.View
{
    public class TagView : MonoBehaviour
    {
        [SerializeField] private Text _text = null!;
        
        public void Init(string tagName)
        {
            _text.text = tagName;
        }
    }
}