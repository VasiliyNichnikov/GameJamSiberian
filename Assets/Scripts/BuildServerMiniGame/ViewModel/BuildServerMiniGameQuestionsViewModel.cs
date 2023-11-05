#nullable  enable
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace BuildServerMiniGame.ViewModel
{
    public class BuildServerMiniGameQuestionsViewModel : IBuildServerMiniGameQuestionsViewModel
    {
        public IReadOnlyCollection<BuildServerMiniGameQuestionViewModel> Question => _questions;
        private List<BuildServerMiniGameQuestionViewModel> _questions = new List<BuildServerMiniGameQuestionViewModel>();

        public BuildServerMiniGameQuestionsViewModel(Configs.BuildServerMiniGameData data)
        {
            foreach (var question in data.Questions)
                _questions.Add(new BuildServerMiniGameQuestionViewModel(question));
            
        }

        public List<bool> GetQuestionsStatus()
        {
            var qStatus = new List<bool>();
            
            foreach (var question in _questions)
                qStatus.Add(question.IsSelect);
            

            return qStatus;
        }

        public void EditSelected(int id, bool value)
        {
            var q = _questions.Find(x => x.Id == id);
            if (q != null)
                q.IsSelect = value;
            
        }
    }
}