using BuildServerMiniGame.ViewModel;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BuildServerMiniGame.View
{
    public class BuildServerMiniGameView : BaseDialog // Главная View (BuildServerMiniGameQuestionsView зависит от этой)
    {
        public BuildServerMiniGameQuestionsView BuildServerMiniGameQuestionsViewPrefab;
        public GameObject BuildServerMiniGame;
        public Text TaskText;
        public Text HintText;
        public Button TryButton;
        public Text TerminalText;

        public string InGameButtonLabel = "Залить";
        public string AfterGameButtonLabel = "Далее";
        
        private IBuildServerMiniGameViewModel _viewModel;
        private bool _isDone = false;
        private BuildServerMiniGameQuestionsView _buildServerMiniGameQuestionsView;
        
        public void Init(IBuildServerMiniGameViewModel viewModel)
        {
            _viewModel = viewModel;
            
            BuildServerMiniGame.SetActive(true);
            TaskText.text = _viewModel.TaskText;
            HintText.text = _viewModel.HintText;

            TerminalText.text = "";
            TryButton.GetComponentInChildren<Text>().text = InGameButtonLabel;

            _buildServerMiniGameQuestionsView = Instantiate(BuildServerMiniGameQuestionsViewPrefab, transform, false);
            _buildServerMiniGameQuestionsView.Init(_viewModel.QuestionsViewModel);
        }

        public void OnClickTryButton()
        {
            if (_viewModel.CheckAnswer())
            {
                if(!_isDone)
                {
                    AddTextInTerminal(_viewModel.GetSusses());
                    TryButton.GetComponentInChildren<Text>().text = AfterGameButtonLabel;
                    _buildServerMiniGameQuestionsView.SetActiveToggle(false);
                    
                    _isDone = true;
                }
                else
                {
                    // TODO: Выход из мини-игры.
                    Debug.Log("Выход из мини-игры");
                }
                
            }
            else
            {
                AddTextInTerminal(_viewModel.GetRandomError());
            }
        }

        private void AddTextInTerminal(string text)
        {
            TerminalText.text += text + '\n';
        }
        
    }
}