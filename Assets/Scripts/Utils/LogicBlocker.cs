#nullable enable
using UnityEngine;

namespace Utils
{
    public interface ILogicBlocker
    {
        bool IsLocked { get; }
    }
    
    public class LogicBlocker : ILogicBlocker
    {
        public bool IsLocked { get; private set; } = false;
        
        public void Lock()
        {
            if (IsLocked)
            {
                Debug.LogWarning("LogicBlocker.Lock: logic is already locked");
                return;
            }

            IsLocked = true;
        }

        public void Unlock()
        {
            if (!IsLocked)
            {
                Debug.LogWarning("LogicBlocker.Lock: logic is already unlocked");
                return;
            }

            IsLocked = false;
        }
    }
}