using System;
using Configs;
using UI.Desktop;
using UnityEngine;

namespace ProgramsLogic
{
    public class ProgramFactory
    {
        public static ProgramData CreateProgram(ProgramType type, DesktopProgramContext context)
        {
            switch (type)
            {
                case ProgramType.IzbaSurf:
                    return new IzbaSerfProgram(context);
                case ProgramType.Swallow:
                    return new SwallowProgram(context);
                case ProgramType.IDE:
                    return new IdeProgram(context);
                default:
                    Debug.LogError($"ProgramFactory.CreateProgram: not found program: {type}");
                    return new EmptyProgram(context);
            }
        }
    }
}