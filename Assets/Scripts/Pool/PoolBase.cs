using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public interface IPool<in T> where T: IObjectPool
    {
        void RemoveObject(T objectPool);
    }
    
    public abstract class PoolBase<T>: IPool<T> where T: IObjectPool
    {
        private readonly Queue<T> _unusedObjects = new Queue<T>();

        public void RemoveObject(T objectPool)
        {
            if (_unusedObjects.Contains(objectPool))
            {
                Debug.LogError("PoolBase.RemoveObject: objectPool contains already contains in list");
                return;
            }

            objectPool.Hide();
            _unusedObjects.Enqueue(objectPool);
        }
        
        protected T GetOrCreateObject()
        {
            if (_unusedObjects.Count != 0)
            {
                var unusedObjects = _unusedObjects.Dequeue();
                unusedObjects.Show();
                return unusedObjects;
            }

            var createdObject = CreateObject();
            createdObject.InitPool(this);
            return createdObject;
        }

        protected abstract T CreateObject();
    }
}