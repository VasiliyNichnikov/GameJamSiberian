using System;
using System.Collections.Generic;
using Configs;
using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public interface IChatViewModel : IDisposable
    {
        /// <summary>
        /// Пользователь с которым будет идти диалог
        /// </summary>
        IReactiveProperty<MessengerData.UserData?> SelectedUser { get; }
        /// <summary>
        /// Сообщения которые были отправлены в чате
        /// Может быть пустым
        /// </summary>
        IReactiveProperty<IReadOnlyCollection<SentMessage>> SentMessages { get; }
    }
}