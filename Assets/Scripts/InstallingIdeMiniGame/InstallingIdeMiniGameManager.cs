using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace InstallingIdeMiniGame
{
    public class InstallingIdeMiniGameManager : MonoBehaviour
    {
        public MiniGameLogic GameLogic;
        
        public Button NextButton;

        public Text WelcomeInstallerText;
        public string WelcomeText = "Welcome to the IDE-shit installer";
        
        public DisksManager DisksManager;
        public SwitchesManager SwitchesManager;
    
        
        public Slider InstallBar;
        public int LoadTime = 10;
        public void Start()
        {
            HideAllInterface();
            WelcomeInstallerText.text = WelcomeText;
        }

        private enum InstallingState
        {
            Start,
            WelcomeText,
            OpenExplorer,
            Switches,
            LoadBar,
            End
        }

        private InstallingState _state = InstallingState.Start;

        public void OnNextButtonClick()
        {
            MoveOnStates(_state);
        }

        private void MoveOnStates(InstallingState currentState)
        {
            switch (currentState)
            {
                case InstallingState.Start:
                    _state = InstallingState.WelcomeText;
                    break;
                case InstallingState.WelcomeText:
                    _state = InstallingState.OpenExplorer;
                    break;
                case InstallingState.OpenExplorer:
                    if (GameLogic.IsCorrectDiskSelected(DisksManager.GetIdByDisk(DisksManager.SelectedDisk)))
                        _state = InstallingState.Switches;
                    break;
                case InstallingState.Switches:
                    if(GameLogic.IsCorrectSwitchSelected(SwitchesManager.Switches))
                        _state = InstallingState.LoadBar;
                    break;
                case InstallingState.LoadBar:
                    StartCoroutine(GameLogic.LoadVisualization(InstallBar, LoadTime)); // BUG: запускается только после вызова следующего состояния
                    _state = InstallingState.End;
                    break;
                case InstallingState.End:
                    break;
            }
            
            LoadUI(_state);
        }

        private void LoadUI(InstallingState currentState)
        {
            switch (currentState)
            {
                case InstallingState.WelcomeText:
                    HideAllInterface();
                    WelcomeInstallerText.GameObject().SetActive(true);
                    break;
                case InstallingState.OpenExplorer:
                    HideAllInterface();
                    DisksManager.SetVisible(true);
                    break;
                case InstallingState.Switches:
                    HideAllInterface();
                    SwitchesManager.SetVisible(true);
                    break;
                case InstallingState.LoadBar:
                    HideAllInterface();
                    InstallBar.GameObject().SetActive(true);
                    break;
                case InstallingState.End:
                    NextButton.GetComponentInChildren<Text>().text = "Finish";
                    break;
            }
        }

        private void HideAllInterface()
        {
            WelcomeInstallerText.GameObject().SetActive(false);
            DisksManager.SetVisible(false);
            SwitchesManager.SetVisible(false);
            InstallBar.GameObject().SetActive(false);
        }
    }
}
