using EventChannelSystem.Core;
using UnityEngine;

namespace EventChannelSystem
{
    [CreateAssetMenu(fileName = "Void EventChannel", menuName = "Events / Void EventChannel")]
    public class VoidEventChannel : BaseEventChannel<Void>
    {
        public void RaiseEvent()
        {
            RaiseEvent(new Void());
        }
    }
}
