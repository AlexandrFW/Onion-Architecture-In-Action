using System;
using System.Threading;

namespace DelegateLambdasAndEventsConsoleApp
{
    public class Countdown
    {
        private int _delay;
        private string _message = "Counter has finished count";

        public Countdown(int delay)
        {
            _delay = delay;
        }

        public delegate void CountDownMessageDelegate(string returnMessage); 
        public event CountDownMessageDelegate OnCounted; 
        
        public void Count() 
        {
            Console.WriteLine("Please wait, counting down...");

            Thread.Sleep(_delay);

            OnCounted(_message);
        }
    }
}