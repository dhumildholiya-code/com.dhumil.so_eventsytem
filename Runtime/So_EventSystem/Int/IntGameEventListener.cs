using Project_Setup.So_EventSystem.Generic;
using UnityEngine;

namespace Project_Setup.So_EventSystem.Int
{
    [AddComponentMenu("Game Events/Int Game Event Listener")]
    public class IntGameEventListener : ArgumentGameEventListener<IntGameEvent, IntEvent, int>
    {
    }
}