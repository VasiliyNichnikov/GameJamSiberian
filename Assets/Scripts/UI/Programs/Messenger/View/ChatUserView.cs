#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.Messenger.View
{
    public class ChatUserView : MonoBehaviour
    {
        [SerializeField] private Text _nameUserLabel = null!;
        [SerializeField] private Text _statusUserLabel = null!;
        
        public void SetUserData(string nameUser)
        {
            _nameUserLabel.text = nameUser;
            // Статус по типу онлайн и тп
            _statusUserLabel.text = "Что-то на славянском";
        }

        public void DeselectUser()
        {
            _nameUserLabel.text = string.Empty;
            _statusUserLabel.text = string.Empty;
        }
    }
}