using UnityEngine;
using UnityEngine.Events;

namespace Project_Setup.So_EventSystem
{
    public abstract class BaseEventSo<T> : ScriptableObject
    {
        public UnityAction<T> eventToRaise;

        public void RaiseEvent(T eventData)
        {
            eventToRaise?.Invoke(eventData);
        }
    }
}