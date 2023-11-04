#nullable enable
namespace Pool
{
    public interface IObjectPool
    {
        void InitPool<T>(IPool<T> pool) where T: IObjectPool;
        void Show();
        void Hide();
    }
}