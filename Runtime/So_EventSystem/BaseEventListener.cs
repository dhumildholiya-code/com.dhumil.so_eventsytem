using UnityEngine;
using UnityEngine.Events;

namespace Project_Setup.So_EventSystem
{
    public abstract class BaseEventListener<T, TE> : MonoBehaviour where TE : BaseEventSo<T>
    {
        public TE eventChannel;
        public UnityEvent<T> eventCallback;

        protected virtual void OnEnable()
        {
            eventChannel.eventToRaise += HandleEvent;
        }

        protected virtual void OnDisable()
        {
            eventChannel.eventToRaise -= HandleEvent;
        }

        protected void HandleEvent(T eventData)
        {
            eventCallback.Invoke(eventData);
        }
    }
}