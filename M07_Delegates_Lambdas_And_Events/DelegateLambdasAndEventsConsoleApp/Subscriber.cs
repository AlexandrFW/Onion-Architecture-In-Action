using System;

namespace DelegateLambdasAndEventsConsoleApp
{
    public class Subscriber
    {
        string _name;

        public Subscriber(string sSubscriberName)
        {
            _name = sSubscriberName;
        }


        public void countDown_Progress(string returnedMessage)
        {
            Console.WriteLine($"Subscriber {_name } got the message {returnedMessage}");
        }
    }
}