using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Project_Setup.So_EventSystem.Generic
{
    public abstract class ArgumentBaseEvent<TArg> : ScriptableObject, IArgumentGameEvent<TArg>
    {
        [SerializeField]
        [Tooltip("Should debug message be logged for this event.")]
        private bool debug = false;

        private readonly ReadOnlyCollection<IArgumentGameEventListener<TArg>> readListeners;

        private readonly List<IArgumentGameEventListener<TArg>> listeners =
            new List<IArgumentGameEventListener<TArg>>();

        public ICollection<IArgumentGameEventListener<TArg>> Listeners => readListeners;

        public ArgumentBaseEvent()
        {
            readListeners = listeners.AsReadOnly();
        }

        public void RaiseEvent(TArg arg)
        {
            if (debug)
            {
                Debug.Log($"Raise event: {name} with an argument: {arg}");
            }

            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                var listener = listeners[i];
                if (debug)
                {
                    Debug.Log($"Raise event: {name}, listener: {listener}, argument: {arg}");
                }

                try
                {
                    listener.OnEventRaised(arg);
                }
                catch (Exception e)
                {
                    Debug.Log($"Listener: {listener} of event: {name} has thrown an exception.");
                    Debug.LogException(e, this);
                }
            }
        }

        public void RegisterListener(IArgumentGameEventListener<TArg> listener)
        {
            if (debug)
            {
                Debug.Log($"Registering listener: {listener}");
            }

            listeners.Add(listener);
        }

        public void UnregisterListener(IArgumentGameEventListener<TArg> listener)
        {
            if (debug)
            {
                Debug.Log($"Unregistering listener: {listener}");
            }

            listeners.Remove(listener);
        }
    }
}