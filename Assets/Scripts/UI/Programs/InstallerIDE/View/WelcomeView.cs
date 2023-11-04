#nullable enable
using UI.Programs.InstallerIDE.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Programs.InstallerIDE.View
{
    public class WelcomeView : MonoBehaviour
    {
        [SerializeField] private Text _description = null!;
        
        public void Init(IWelcomeViewModel viewModel)
        {
            _description.text = viewModel.Description;
        }
    }
}