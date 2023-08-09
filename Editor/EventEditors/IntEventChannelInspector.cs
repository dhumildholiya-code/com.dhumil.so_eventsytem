using UnityEditor;

namespace EventChannelSystem.EventEditors
{
    [CustomEditor(typeof(IntEventChannel))]
    public class IntEventChannelInspector : BaseEventChannelInspector<int>
    {
        protected override int DrawValue()
        {
            return EditorGUILayout.IntField("Value", value);
        }
    }
}