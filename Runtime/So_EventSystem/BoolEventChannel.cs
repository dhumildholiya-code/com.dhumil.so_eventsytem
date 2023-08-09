using EventChannelSystem.Core;
using UnityEngine;

namespace EventChannelSystem
{
    [CreateAssetMenu(fileName = "Bool EventChannel", menuName = "Events / Bool EventChannel")]
    public class BoolEventChannel : BaseEventChannel<bool>
    {
    }
}