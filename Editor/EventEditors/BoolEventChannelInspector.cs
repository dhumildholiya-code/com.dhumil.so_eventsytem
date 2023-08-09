using UnityEditor;

namespace EventChannelSystem.EventEditors
{
    [CustomEditor(typeof(BoolEventChannel))]
    public class BoolEventChannelInspector : BaseEventChannelInspector<bool>
    {
        protected override bool DrawValue()
        {
            return EditorGUILayout.Toggle("Value", value);
        }
    }
}