using UI.Programs;

namespace UI
{
    public interface IDialogsManager
    {
        T ShowDialog<T>() where T : BaseDialog;
    }
}