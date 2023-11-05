using UnityEngine;

namespace ProgramsLogic
{
    public class ProgramState
    {
        public bool IsOpened { get; private set; }

        public void Open()
        {
            if (IsOpened)
            {
                Debug.LogWarning("ProgramState.Open: program is already opened");
                return;
            }

            IsOpened = true;
        }

        public void Close()
        {
            if (!IsOpened)
            {
                Debug.LogWarning("ProgramState.Close: program is already closed");
                return;
            }

            IsOpened = false;
        }
    }
}