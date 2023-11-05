#nullable enable

using Configs;
using UI.ClicksHandler;
using UI.Desktop;
using UnityEngine;

namespace ProgramsLogic
{
    public abstract class ProgramData : IProgram
    {
        public Sprite Icon { get; }
        public string Name { get; }
        public bool NeedShowInDesktop => _context.NeedShowInDesktop;
        public abstract ProgramType Type { get; }

        private DesktopProgramContext _context;
        protected readonly ProgramState State;

        protected ProgramData(DesktopProgramContext context)
        {
            var data = DataHelper.Instance.ProgramsIconData.GetIconDataByType(Type);
            Icon = data.Sprite;
            Name = data.Name;
            State = new ProgramState();

            _context = context;
        }

        public void UpdateContext(DesktopProgramContext context)
        {
            _context = context;
        }

        public virtual void OnClickHandler()
        {
            if (State.IsOpened)
            {
                return;
            }

            // Клик по умолчанию (Если нужен кастомный, оверайдим метод)
            var canOpen = ProgramClicksHelper.OnClickDefaultHandler(Type, _context);
            if (canOpen)
            {
                State.Open();
            }
        }

        public void Dispose()
        {
            // nothing
        }
    }
}