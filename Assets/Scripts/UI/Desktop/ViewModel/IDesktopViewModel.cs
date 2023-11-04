using System;
using System.Collections.Generic;
using UniRx;

namespace UI.Desktop.ViewModel
{
    public interface IDesktopViewModel : IDisposable
    {
        IReactiveProperty<IReadOnlyCollection<IProgramIconViewModel>> Programs { get; }
    }
}