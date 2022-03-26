using UnityEngine;
using UnityEngine.Events;

namespace Project_Setup.So_EventSystem.Generic
{
    public abstract class ArgumentGameEventListener<TGameEvent, TUnityEvent, TArg>
        : MonoBehaviour, IArgumentGameEventListener<TArg>
        where TGameEvent : IArgumentGameEvent<TArg>
        where TUnityEvent : UnityEvent<TArg>
    {

        [SerializeField]
        [Tooltip("Game Event to listen to which will trigger the onGameEvent event")]
        private TGameEvent gameEvent = default;

        [SerializeField]
        [Tooltip("Called when the listener is triggered with and argument.")]
        private TUnityEvent onGameEvent = default;

        public TGameEvent GameEvent
        {
            get => gameEvent;
            set => gameEvent = value;
        }

        public TUnityEvent OnGameEvent
        {
            get => onGameEvent;
            set => onGameEvent = value;
        }

        public void OnEventRaised(TArg arg)
        {
            onGameEvent.Invoke(arg);
        }

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }
        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }
    }
}
