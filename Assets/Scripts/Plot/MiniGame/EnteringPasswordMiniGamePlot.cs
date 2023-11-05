#nullable enable
using Configs;
using ProgramsLogic;
using UI.Desktop;
using UI.Programs;
using UI.Programs.Messenger;
using UnityEngine;

namespace Plot.MiniGame
{
    /// <summary>
    /// Квест считается завершенным когда игрок ввел пароль и вошел в менеджер
    /// </summary>
    public class EnteringPasswordMiniGamePlot : IMiniGamePlot
    {
        private readonly IComputerFacade _computerFacade;
        private IMessengerManager? _messengerManager;
        
        public EnteringPasswordMiniGamePlot(IComputerFacade computerFacade)
        {
            _computerFacade = computerFacade;
        }
        
        /// <summary>
        /// Получаем менеджер
        /// </summary>
        public void ExecutePlot()
        {
            if (!_computerFacade.TryGetInstalledProgram(ProgramType.Swallow, out var program))
            {
                Debug.LogError($"EnteringPasswordMiniGamePlot.ExecutePlot: not found installed program {ProgramType.Swallow}");
                return;
            }

            if (program is SwallowProgram messenger)
            {
                _messengerManager = messenger.Manager;
            }
        }

        public bool CheckCompletionCondition()
        {
            if (_messengerManager == null)
            {
                Debug.LogError("EnteringPasswordMiniGamePlot.CheckCompletionCondition: messenger is null");
                return false;
            }

            return _messengerManager.State == MessengerState.Opened;
        }

        public void CompletePlot()
        {
            // nothing
        }
    }
}