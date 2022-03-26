using System.Collections.Generic;

namespace Project_Setup.So_EventSystem.Generic
{
    public interface IArgumentGameEvent<TArg>
    {
        ICollection<IArgumentGameEventListener<TArg>> Listeners { get; }
        void RaiseEvent(TArg arg);
        void RegisterListener(IArgumentGameEventListener<TArg> listener);
        void UnregisterListener(IArgumentGameEventListener<TArg> listener);
    }
}