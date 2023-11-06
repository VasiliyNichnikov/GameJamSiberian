using UI.Bluer;

namespace UI
{
    public interface IDialogsManager
    {
        // Костыль
        BluerDialog ShowBluer();
        T ShowDialog<T>() where T : BaseDialog;

        /// <summary>
        /// Закрывает все активные диалоги
        /// </summary>
        void HideAllActiveDialogs();
    }
}