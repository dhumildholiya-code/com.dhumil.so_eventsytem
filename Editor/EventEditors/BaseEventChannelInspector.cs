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
                    EditorGUILayout.ObjectField(behaviour, behaviour.GetType(), true);
                }
            }
            GUILayout.Space(10);
            if (GUILayout.Button("Raise Event"))
            {
                var targetObject = _prop.serializedObject.targetObject;
                var targetObjectType = targetObject.GetType();
                var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
                var field = targetObjectType.GetField(_prop.propertyPath, bindingFlags);
                if (field != null)
                {
                    var value = (T)field.GetValue(targetObject);
                    _channel.RaiseEvent(value);
                }
                else
                {
                    Debug.LogError("Field Not Found");
                }
            }
        }
    }
}
