using UnityEditor;

namespace EventChannelSystem
{
    [CustomEditor(typeof(VoidEventChannel))]
    public class VoidEventChannelInspector : BaseEventChannelInspector<Void>
    {
    }
}