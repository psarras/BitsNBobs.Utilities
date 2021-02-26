namespace BitsNBobs.Pool
{
    public interface IPooled
    {
        void OnSpawn();
        void OnRecycle();
    }
}