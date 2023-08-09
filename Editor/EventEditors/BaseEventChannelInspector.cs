using EventChannelSystem.Core;
using UnityEditor;
using UnityEngine;

namespace EventChannelSystem
{
    public abstract class BaseEventChannelInspector<T> : Editor
    {
        protected BaseEventChannel<T> _channel;
        protected T value;

        protected void OnEnable()
        {
            _channel = target as BaseEventChannel<T>;
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = Application.isPlaying;
            DrawCustom();
        }

        protected abstract T DrawValue();

        protected void DrawCustom()
        {
            GUILayout.Label($"Listeners : {_channel.Listeners.Count}");
            for (int i = _channel.Listeners.Count - 1; i >= 0; i--)
            {
                if (_channel.Listeners[i] is MonoBehaviour behaviour)
                {
                    EditorGUILayout.ObjectField(behaviour, behaviour.GetType(), true);
                }
            }
            GUILayout.Space(10);
            value = DrawValue();
            if (GUILayout.Button("Raise Event"))
            {
                _channel.RaiseEvent(value);
            }
        }
    }
}
