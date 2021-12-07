using System;
using NUnit.Framework;
using Project_Setup.So_EventSystem;
using UnityEngine;
using Void = Project_Setup.So_EventSystem.Void;

namespace com.dhumil.project_setup.Tests.Runtime
{
    public class EventSystemTest
    {
        private VoidEventSo _voidEvent;
        private IntEventSo _intEvent;
        private VoidEventListener _voidEventListener;
        private IntEventListener _intEventListener;

        [SetUp]
        public void SetupForEventTests()
        {
            _voidEvent = ScriptableObject.CreateInstance<VoidEventSo>();
            _intEvent = ScriptableObject.CreateInstance<IntEventSo>();

            _voidEventListener = new GameObject().AddComponent<VoidEventListener>();
            _intEventListener = new GameObject().AddComponent<IntEventListener>();
        }

        [Test]
        public void WhenVoidEventIsCreated_IsShouldBeNull()
        {
            Assert.IsNull(_voidEvent.eventToRaise);
        }

        [Test]
        public void WhenEventIsNull_ListenerShouldNowKnowAnything()
        {
            _voidEventListener.eventChannel = _voidEvent;
            string s = String.Empty;
            
            _voidEvent.RaiseEvent(new Void());
            
            Assert.AreEqual(String.Empty, s);
        }

        [Test]
        public void WhenVoidEventIsRaised_VoidEventListenerShouldKnow()
        {
            //Setup for Listening Events.
            _voidEventListener.eventChannel = _voidEvent;
            string s = String.Empty;
            _voidEventListener.eventChannel.eventToRaise += v => s = "called";
                
            _voidEvent.RaiseEvent(new Void());

            Assert.AreEqual("called", s);
        }

        [Test]
        public void WhenIntEventIsRaisedWith3_IntEventListenerShouldListen3()
        {
            _intEventListener.eventChannel = _intEvent;
            int i = 0;
            _intEventListener.eventChannel.eventToRaise += eventData => i = eventData;
            
            _intEvent.RaiseEvent(3);
            
            Assert.AreEqual(3, i);
        }
    }
}