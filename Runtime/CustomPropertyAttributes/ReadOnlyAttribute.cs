using System;
using UnityEngine;

namespace Project_Setup.CustomPropertyAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
        
    }
}