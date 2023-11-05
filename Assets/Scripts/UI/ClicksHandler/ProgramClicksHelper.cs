using System.Collections.Generic;
using Configs;
using ProgramsLogic;
using UI.Desktop;
using UnityEngine;

namespace UI.ClicksHandler
{
    /// <summary>
    /// Пока нигде не нужна
    /// Если нигде не пригодится - удалить
    /// </summary>
    public class ProgramClicksHelper
    {
        private static readonly Dictionary<ProgramType, IProgramClicksHelper> _clicks =
            new()
            {
                { ProgramType.Swallow, new ProgramSwallowClickHelper() },
                { ProgramType.IzbaSurf, new ProgramIzbaSurfClickHandler() },
                { ProgramType.IDE, new ProgramIdeClickHelper() },
                { ProgramType.InstallerIde, new ProgramFileWithIdeClickHandler() }
            };

        public static bool OnClickDefaultHandler(ProgramType type, DesktopProgramContext context)
        {
            if (!context.AllowProgramToRun)
            {
                return false;
            }


            if (_clicks.TryGetValue(type, out var result))
            {
                result.OnClickHandler(context);
                return true;
            }

            Debug.LogError($"ProgramClicks.OnClickDefaultHandler: not found program with type {type}");
            return false;
        }
    }
}