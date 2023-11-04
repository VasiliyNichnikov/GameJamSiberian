#nullable enable
namespace UI.Programs.InstallerIDE.ViewModel
{
    public class WelcomeViewModel : IWelcomeViewModel
    {
        public string Title { get; }
        public string Description { get; }

        public WelcomeViewModel()
        {
            var welcomeData = DataHelper.Instance.InstallerData.GetWelcomeData();
            Title = welcomeData.Title;
            Description = welcomeData.Description;
        }
    }
}