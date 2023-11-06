#nullable enable
using System;
using UniRx;
using UnityEngine;

namespace Utils
{
    public static class ReactiveExtensions
    {
        public static void UpdateViewModelWithDisposable<T>(this GameObject gameObject, ref T currentViewModel, T newViewModel) where T: IDisposable
        {
            TryFreeGameObject(gameObject);

            if (currentViewModel != null!)
            {
                currentViewModel.Dispose();
            }
            currentViewModel = newViewModel;
        }
        
        public static void UpdateViewModel<T>(this GameObject gameObject, ref T currentViewModel, T newViewModel)
        {
            TryFreeGameObject(gameObject);
            
            currentViewModel = newViewModel;
        }
        
        public static void Subscribe<T>(this GameObject gameObject, IReactiveProperty<T> reactiveProperty, Action<T> action)
        {
            var disposeOnDestroy = gameObject.GetComponent<DisposeOnDestroy>();
            if (disposeOnDestroy == null)
            {
                disposeOnDestroy = gameObject.AddComponent<DisposeOnDestroy>();
            }

            var disposable = reactiveProperty.ObserveEveryValueChanged(x => x.Value).Subscribe(action);
            disposeOnDestroy.AddDispose(disposable);
        }

        private static void TryFreeGameObject(GameObject gameObject)
        {
            var disposeOnDestroy = gameObject.GetComponent<DisposeOnDestroy>();
            if (disposeOnDestroy != null)
            {
                disposeOnDestroy.Free();
            }
        }
    }
}