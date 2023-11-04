#nullable enable
using UI.Programs.TrelloMiniGame.View;
using UnityEngine;

namespace Pool
{
    public interface ITrelloTasksPool : IPool<TrelloTaskView>
    {
        
    }
    
    public class TrelloTasksPool : PoolBase<TrelloTaskView>
    {
        private readonly RectTransform _holder;
        private readonly TrelloTaskView _prefab;
        
        public TrelloTasksPool(RectTransform holder, TrelloTaskView prefab)
        {
            _holder = holder;
            _prefab = prefab;
        }
        
        public TrelloTaskView GetOrCreateTask() => GetOrCreateObject();
        
        protected override TrelloTaskView CreateObject()
        {
            var view = Object.Instantiate(_prefab, _holder, false);
            return view;
        }
    }
}