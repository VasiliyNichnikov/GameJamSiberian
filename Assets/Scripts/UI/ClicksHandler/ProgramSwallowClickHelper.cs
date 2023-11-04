#nullable enable
using UI.Desktop;
using UnityEngine;

namespace UI.ClicksHandler
{
    public class ProgramSwallowClickHelper : IProgramClicksHelper
    {
        public void OnClickHandler(DesktopProgramContext context)
        {
            Debug.Log("ProgramSwallowClickHelper.OnClickHandler: clicked");
        }
    }
}