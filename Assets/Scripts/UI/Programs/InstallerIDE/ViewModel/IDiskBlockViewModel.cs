using UniRx;

namespace UI.Programs.InstallerIDE.ViewModel
{
    public interface IDiskBlockViewModel
    {
        IReactiveProperty<bool> IsSelected { get; }
        string NameDisk { get; }
        string AmountOfSpace { get; }
        
        /// <summary>
        /// Количество занятого пространства
        /// </summary>
        float OccupiedSpace { get; }
        /// <summary>
        /// Является ли диск корректным для ответа
        /// </summary>
        bool IsCorrectedDisk { get; }
        /// <summary>
        /// Действие при нажатие на диск
        /// </summary>
        void OnClickHandler();
    }
}