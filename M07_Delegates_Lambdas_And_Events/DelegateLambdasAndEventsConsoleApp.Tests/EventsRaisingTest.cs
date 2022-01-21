using NUnit.Framework;

namespace DelegateLambdasAndEventsConsoleApp.Tests
{
    public class EventsRaisingTest
    {
        [Test]
        public void Countdown_Publisher_Should_Raise_Event_And_Subscriber_Should_Get_It_Test()
        {
            // Assign
            bool isEventRaised = false;
            var countDown = new Countdown(1000);
            countDown.OnCounted += (e) => { isEventRaised = true; }; //subscriber1.countDown_Progress;

            // Act
            countDown.Count();

            // Assert
            Assert.That(isEventRaised, Is.True);
        }
    }
}