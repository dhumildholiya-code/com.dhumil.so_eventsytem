using UnityEditor;

namespace EventChannelSystem.EventEditors
{
    [CustomEditor(typeof(IntEventChannel))]
    public class IntEventChannelInspector : BaseEventChannelInspector<int>
    {
    }
}