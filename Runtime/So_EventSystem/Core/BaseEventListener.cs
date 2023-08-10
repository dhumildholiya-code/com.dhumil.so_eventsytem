using UnityEngine;
using UnityEngine.Events;

namespace EventChannelSystem.Core
{
    public abstract class BaseEventListener<T> : MonoBehaviour, IEventListener<T>
    {
        public BaseEventChannel<T> eventChannel;
        public UnityEvent<T> eventCallback;

        protected virtual void OnEnable()
        {
            eventChannel.AddListener(this);
        }

        protected virtual void OnDestroy()
        {
            eventChannel.RemoveListener(this);
        }

        public void OnEventRaised(T eventData)
        {
            eventCallback.Invoke(eventData);
        }
    }
}