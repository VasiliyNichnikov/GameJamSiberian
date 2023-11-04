#nullable enable
using UI.Desktop;
using UnityEngine;

namespace UI.ClicksHandler
{
    public class ProgramIdeClickHelper : IProgramClicksHelper
    {
        public void OnClickHandler(DesktopProgramContext context)
        {
            Debug.Log("ProgramIdeClickHelper.OnClickHandler: clicked");
        }
    }
}