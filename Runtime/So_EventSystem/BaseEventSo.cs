using System.Collections.Generic;
using UnityEngine;

namespace Project_Setup.So_EventSystem
{
    public abstract class BaseEventSo<T> : ScriptableObject
    {
        private readonly List<IBaseEventListener<T>> _listeners = new List<IBaseEventListener<T>>();

        public void AddListener(IBaseEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void RemoveListener(IBaseEventListener<T> listener)
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