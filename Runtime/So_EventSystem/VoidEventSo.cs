using UnityEngine;

namespace Project_Setup.So_EventSystem
{
    [CreateAssetMenu(fileName = "Void Event", menuName = "Events / Void Event")]
    public class VoidEventSo : BaseEventSo<Void>
    {
        public void RaiseEvent()
        {
            eventToRaise?.Invoke(new Void());
        }
    }
}
