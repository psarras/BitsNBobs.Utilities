namespace BitsNBobs.Patterns
{
    public interface IState
    {
        void Tick();
        void OnEnter();
        void OnExit();
    }
}