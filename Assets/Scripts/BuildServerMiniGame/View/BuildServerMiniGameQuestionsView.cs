using System.Collections.Generic;
using BuildServerMiniGame.ViewModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BuildServerMiniGame.View
{
    public class BuildServerMiniGameQuestionsView : MonoBehaviour
    {
        public Toggle QuestionPrefab;
       
        private IBuildServerMiniGameQuestionsViewModel _viewModel;
        private readonly List<Toggle> _toggles = new List<Toggle>();

        public void Init(IBuildServerMiniGameQuestionsViewModel viewModel)
        {
            _viewModel = viewModel;
            foreach (var question in _viewModel.Question)
            {
                CreateQuestion(question);
            }
        }

        private void CreateQuestion(BuildServerMiniGameQuestionViewModel question)
        {
            var q = Instantiate(QuestionPrefab, transform, false);
            q.GetComponentInChildren<Text>().text = question.QuestionText;
            question.Id = q.GetInstanceID();
            _toggles.Add(q);
            
            q.onValueChanged.AddListener(delegate { OnSelectQuestion(q); });
        }

        private void OnSelectQuestion(Toggle toggle)
        {
            _viewModel.EditSelected(toggle.GetInstanceID(), toggle.isOn);
        }

        public void SetActiveToggle(bool active)
        {
            foreach (var toggle in _toggles)
            {
                toggle.interactable = false;
            }
        }
    }
}