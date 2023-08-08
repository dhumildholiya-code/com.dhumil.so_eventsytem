using System;
using UnityEngine;

namespace EventChannelSystem.CustomPropertyAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ReadOnlyAttribute : PropertyAttribute
    {

    }
}