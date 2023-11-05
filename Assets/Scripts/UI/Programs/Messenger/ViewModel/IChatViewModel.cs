#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Configs;
using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public interface IChatViewModel : IDisposable
    {
        event Action? UploadedMessagesToSend;
        
        /// <summary>
        /// Пользователь с которым будет идти диалог
        /// </summary>
        IReactiveProperty<MessengerData.UserData?> SelectedUser { get; }
        /// <summary>
        /// Сообщения которые были отправлены в чате
        /// Может быть пустым
        /// </summary>
        IReactiveProperty<ReadOnlyCollection<SentMessage>> SentMessages { get; }

        IEnumerable<UnsentMessage> ReceiveUnsentMessages();

        /// <summary>
        /// Помечает первое сообщение (которое идет на отправку) как отправленное
        /// </summary>
        void MarkFirstMessageAsSent();
    }
}