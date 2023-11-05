#nullable enable
using System;
using System.Collections.Generic;
using ProgramsLogic;
using UniRx;

namespace UI.Desktop.ViewModel
{
    public interface IDesktopViewModel : IDisposable
    {
        IReactiveProperty<IReadOnlyCollection<IProgram>> Programs { get; }
    }
}