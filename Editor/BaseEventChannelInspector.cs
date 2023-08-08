using EventChannelSystem.Core;
using UnityEditor;
using UnityEngine;

namespace EventChannelSystem
{
    public abstract class BaseEventChannelInspector<T> : Editor
    {
        protected T value;
        protected BaseEventChannel<T> _channel;

        protected void OnEnable()
        {
            _channel = target as BaseEventChannel<T>;
        }

        public override void OnInspectorGUI()
        {
            DrawCustom();
        }

        protected abstract void DrawValueLable();

        protected void DrawCustom()
        {
            GUILayout.Label($"Listeners : {_channel.Listeners.Count}");
            for (int i = _channel.Listeners.Count - 1; i >= 0; i--)
            {
                GUILayout.Label($"{_channel.Listeners[i]}");
            }
            GUILayout.Space(10);
            DrawValueLable();
            if (GUILayout.Button("Raise Event"))
            {
                _channel.RaiseEvent(value);
            }
        }
    }
}
