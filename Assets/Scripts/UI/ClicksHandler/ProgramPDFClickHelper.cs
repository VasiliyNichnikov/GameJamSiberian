#nullable enable
using UI.Desktop;
using UnityEngine;

namespace UI.ClicksHandler
{
    public class ProgramPDFClickHelper : IProgramClicksHelper
    {
        public void OnClickHandler(DesktopProgramContext context)
        {
            Debug.Log("ProgramPDFClickHelper.OnClickHandler: clicked");
        }
    }
}
