using UnityEditor;

namespace EventChannelSystem.EventEditors
{
    [CustomEditor(typeof(BoolEventChannel))]
    public class BoolEventChannelInspector : BaseEventChannelInspector<bool>
    {
    }
}