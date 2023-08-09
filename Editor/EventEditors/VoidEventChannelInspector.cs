using UnityEditor;

namespace EventChannelSystem
{
    [CustomEditor(typeof(VoidEventChannel))]
    public class VoidEventChannelInspector : BaseEventChannelInspector<Void>
    {
        protected override Void DrawValue()
        {
            return new Void();
        }
    }
}