using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Диспоузим все вюхи при уничтожение объекта
    /// </summary>
    public class DisposeOnDestroy : MonoBehaviour
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public void AddDispose(IDisposable disposable)
        {
            if (_disposables.Contains(disposable))
            {
                Debug.LogError("DisposeOnDestroy.AddDispose: dispose already contains in list");
                return;
            }

            _disposables.Add(disposable);
        }

        public void Free()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }

        private void OnDestroy()
        {
            Free();
        }
    }
}