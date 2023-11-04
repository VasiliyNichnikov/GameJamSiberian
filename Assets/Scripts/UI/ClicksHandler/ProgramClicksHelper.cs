using System.Collections.Generic;
using Configs;
using UI.Desktop;
using UnityEngine;

namespace UI.ClicksHandler
{
    public class ProgramClicksHelper
    {
        private static readonly Dictionary<ProgramType, IProgramClicksHelper> _clicks =
            new Dictionary<ProgramType, IProgramClicksHelper>
            {
                { ProgramType.Swallow, new ProgramSwallowClickHelper() },
                { ProgramType.IzbaSurf, new ProgramIzbaSurfClickHandler() },
                { ProgramType.IDE, new ProgramIdeClickHelper() }
            };

        public static void OnClickDefaultHandler(DesktopProgramContext context)
        {
            var program = context.ProgramType;
            if (_clicks.TryGetValue(program, out var result))
            {
                result.OnClickHandler(context);
                return;
            }

            Debug.LogError($"ProgramClicks.OnClickDefaultHandler: not found program with type {program}");
        }
    }
}