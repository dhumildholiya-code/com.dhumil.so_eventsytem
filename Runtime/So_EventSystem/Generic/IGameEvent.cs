using System.Collections.Generic;

namespace Project_Setup.So_EventSystem.Generic
{
    public interface IGameEvent
    {
        ICollection<IGameEventListener> Listeners { get; }
        void RaiseEvent();
        void RegisterListener(IGameEventListener listener);
        void UnregisterListener(IGameEventListener listener);
    }
}