using System.Collections.Generic;
using UnityEngine;

namespace EventChannelSystem.Core
{
    public abstract class BaseEventChannel<T> : ScriptableObject, IEventChannel<T>
    {
        [SerializeField] protected T value;
        protected readonly List<IEventListener<T>> _listeners = new List<IEventListener<T>>();
        public List<IEventListener<T>> Listeners { get { return _listeners; } }

        public void AddListener(IEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void RemoveListener(IEventListener<T> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }

        public void RaiseEvent(T eventData)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(eventData);
            }
        }
    }
}