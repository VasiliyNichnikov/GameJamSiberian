using System;

namespace UI.Desktop
{
    public interface IProgram : IDisposable
    {
        DesktopProgramContext Context { get; }

        void OnClickHandler();
    }
}