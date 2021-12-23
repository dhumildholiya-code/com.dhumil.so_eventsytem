using UnityEngine;
using UnityEngine.Events;

namespace Project_Setup.So_EventSystem
{
    public abstract class BaseEventListener<T, TE> : MonoBehaviour, IBaseEventListener<T> where TE : BaseEventSo<T>
    {
        public TE eventChannel;
        public UnityEvent<T> eventCallback;

        protected virtual void OnEnable()
        {
            eventChannel.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            eventChannel.RemoveListener(this);
        }

        public void OnEventRaised(T eventData)
        {
            eventCallback.Invoke(eventData);
        }
    }
}