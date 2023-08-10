using EventChannelSystem.Core;
using UnityEngine;

namespace EventChannelSystem
{
    [CreateAssetMenu(fileName = "Void EventChannel", menuName = "Event Channel / Void")]
    public class VoidEventChannel : BaseEventChannel<Void>
    {
        public void RaiseEvent()
        {
            RaiseEvent(new Void());
        }
    }
}
