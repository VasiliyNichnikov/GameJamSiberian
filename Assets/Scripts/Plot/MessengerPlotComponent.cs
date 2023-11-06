#nullable enable
using System;
using Configs;
using Configs.Plot;
using ProgramsLogic;
using UI.Desktop;
using UI.Programs;
using UnityEngine;

namespace Plot
{
    public class MessengerPlotComponent : AbstractPlotComponent
    {
#pragma warning disable CS0067
        public override event Action? OnCompletePlot;
#pragma warning disable
        
        private readonly MessengerPlotData _data;
        
        private IMessengerManager? _messengerManager;
        
        public MessengerPlotComponent(IComputerFacade computerFacade, MessengerPlotData data) : base(computerFacade)
        {
            _data = data;
        }
        
        /// <summary>
        /// Логика:
        /// 1. Блокируем возможность нажимать на кнопки и пытаться как-то закрыть/перейти в другое окно
        /// 2. Передаем в мессенджер диалог с сообщениями
        /// 3. Ждем пока мессенджер не выполнит все сообщения
        /// 4. Разблокируем экран и возможность нажимать на интерфейс
        /// 5. Завершаем сюжет
        /// </summary>
        public override void ExecutePlot()
        {
            if (!ComputerFacade.TryGetInstalledProgram(ProgramType.Swallow, out var program))
            {
                Debug.LogError($"MessengerPlotComputer.ExecutePlot: not found installed program {ProgramType.Swallow}");
                return;
            }
            
            ComputerFacade.BlockAllClicks();
            if (program is SwallowProgram messenger)
            {
                _messengerManager = messenger.Manager;
                _messengerManager.LoadMessagesInChats(_data);
                messenger.OnClickHandler();
                _messengerManager.SelectUserChat(_data.UserType);
            }
            else
            {
                Debug.LogError(
                    $"MessengerPlotComputer.ExecutePlot: not corrected program with type: {ProgramType.Swallow}");
            }
        }

        public override void CompletePlot()
        {
            ComputerFacade.UnlockAllClicks();
            OnCompletePlot?.Invoke();
        }

        public override bool CheckCompletionCondition()
        {
            if (_messengerManager == null)
            {
                Debug.LogError("MessengerPlotComponent.CheckCompletionCondition: messenger is null");
                return false;
            }

            return _messengerManager.AllMessagesSendInChat(_data.UserType);
        }
    }
}