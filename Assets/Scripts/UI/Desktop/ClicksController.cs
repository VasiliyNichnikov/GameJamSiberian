#nullable enable
namespace UI.Desktop
{
    public class ClicksController
    {
        private readonly SceneData _sceneData;
        
        public ClicksController(SceneData sceneData)
        {
            _sceneData = sceneData;
        }

        public void TurnOnDisplayBlocker() => _sceneData.DisplayBlocker.OffClicks();
        
        public void TurnOffDisplayBlocker() => _sceneData.DisplayBlocker.OnClicks();
    }
}