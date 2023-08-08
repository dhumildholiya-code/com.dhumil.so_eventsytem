using UnityEditor;
using UnityEngine;

namespace EventChannelSystem
{
    [CustomEditor(typeof(VoidEventChannel))]
    public class VoidEventChannelInspector : BaseEventChannelInspector<Void>
    {
        protected override void DrawValueLable()
        {
            return;
        }
    }
}