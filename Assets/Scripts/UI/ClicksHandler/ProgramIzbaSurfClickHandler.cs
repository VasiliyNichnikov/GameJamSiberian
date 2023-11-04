#nullable enable
using UI.Desktop;
using UnityEngine;

namespace UI.ClicksHandler
{
    public class ProgramIzbaSurfClickHandler : IProgramClicksHelper
    {
        public void OnClickHandler(DesktopProgramContext context)
        {
            Debug.Log("ProgramIzbaSurfClickHandler.OnClickHandler: clicked");
        }
    }
}