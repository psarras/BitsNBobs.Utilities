using System;

namespace BitsNBobs.Utilities.Events
{
    public interface ISwitch
    {
        void FlickOn();
    }

    public interface IState
    {
        bool State { get; set; }
        event Action<bool> ChangedState;
        void Reset();
        void ResetWithoutNotification();
    }

    public interface IClick
    {
        // Click Once, reset afterwards
        void Click();
    }
}