using System;
using System.Collections.Generic;
using UniRx;

namespace UI.Programs.Messenger.ViewModel
{
    public interface IChatViewModel : IDisposable
    {
        IReactiveProperty<IReadOnlyCollection<SentMessage>> SentMessages { get; }
    }
}