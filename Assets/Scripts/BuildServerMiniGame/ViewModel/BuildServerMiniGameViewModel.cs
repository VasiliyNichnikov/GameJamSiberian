using System.Collections.Generic;
using System.Linq;
using BuildServerMiniGame.View;
using UnityEngine;

namespace BuildServerMiniGame.ViewModel
{
    public class BuildServerMiniGameViewModel : IBuildServerMiniGameViewModel
    {
        public IBuildServerMiniGameQuestionsViewModel QuestionsViewModel { get; }
        public string TaskText { get; }
        public string HintText { get; }
        private readonly List<string> _errorsTexts;
        private readonly string _sussesText;

        public BuildServerMiniGameViewModel(Configs.BuildServerMiniGameData data)
        {
            TaskText = data.Task;
            HintText = data.Hint;
            QuestionsViewModel = new BuildServerMiniGameQuestionsViewModel(data);
            _errorsTexts = data.Errors.ToList();
            _sussesText = data.Susses;
        }

        public bool CheckAnswer()
        {
            var variables = QuestionsViewModel.GetQuestionsStatus();
            /*
             * (¬w∧¬x)∧(y∧z)∧¬(t→w)
             *    t  w  x  y  z
             *    1  0  0  1  1
             */
            return (!variables[1] & !variables[2]) & (variables[3] & variables[4]) & !(!variables[0] | variables[1]);
        }

        public string GetRandomError()
        {
            return _errorsTexts[Random.Range(0, _errorsTexts.Count)];
        }

        public string GetSusses()
        {
            return _sussesText;
        }
    }
}