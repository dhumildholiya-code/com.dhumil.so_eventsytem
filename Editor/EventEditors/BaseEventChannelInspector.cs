using EventChannelSystem.Core;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EventChannelSystem
{
    public abstract class BaseEventChannelInspector<T> : Editor
    {
        protected BaseEventChannel<T> _channel;
        protected SerializedProperty _prop;

        protected void OnEnable()
        {
            _channel = target as BaseEventChannel<T>;
            _prop = serializedObject.FindProperty("value");
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = Application.isPlaying;
            if (_prop == null) return;
            EditorGUI.BeginChangeCheck();
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(_prop, true);
            EditorGUILayout.Space(10);
            DrawCustom();
            serializedObject.ApplyModifiedProperties();
            EditorGUI.EndChangeCheck();
        }

        protected void DrawCustom()
        {
            GUILayout.Label($"Listeners : {_channel.Listeners.Count}");
            for (int i = _channel.Listeners.Count - 1; i >= 0; i--)
            {
                if (_channel.Listeners[i] is MonoBehaviour behaviour)
                {
                    var listener = (BaseEventListener<T>)behaviour;
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.ObjectField(listener, listener.GetType(), true);
                        if (GUILayout.Button("Raise Event"))
                        {
                            listener.OnEventRaised(GetValue());
                        }
                    }
                }
            }
            GUILayout.Space(10);
            if (GUILayout.Button("Raise Event"))
            {
                var value = GetValue();
                _channel.RaiseEvent(value);
            }
        }

        private T GetValue()
        {
            var targetObject = _prop.serializedObject.targetObject;
            var targetObjectType = targetObject.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var field = targetObjectType.GetField(_prop.propertyPath, bindingFlags);
            return (T)field.GetValue(targetObject);
        }
    }
}
