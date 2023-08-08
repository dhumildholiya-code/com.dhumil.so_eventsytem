using UnityEditor;

namespace EventChannelSystem
{
    [CustomEditor(typeof(IntEventChannel))]
    public class IntEventChannelInspector : BaseEventChannelInspector<int>
    {
        protected override void DrawValueLable()
        {
            value = EditorGUILayout.IntField("Value", value);
        }
    }
}