using System;
using Configs;
using UnityEngine;

namespace ProgramsLogic
{
    public interface IProgram : IDisposable
    {
        bool NeedShowInDesktop { get; }
        Sprite Icon { get; }
        string Name { get; }
        ProgramType Type { get; }
        
        void OnClickHandler();
    }
}