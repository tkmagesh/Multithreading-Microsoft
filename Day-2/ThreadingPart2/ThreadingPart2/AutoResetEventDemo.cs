using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingPart2
{
    class AutoResetEventDemo
    {
        static EventWaitHandle _waitHandle = new ManualResetEvent(false);
        static void Main()
        {
            new Thread(Waiter).Start();
            Thread.Sleep(3000); // Pause for a second...
            _waitHandle.Set(); // Wake up the Waiter.
        }
        static void Waiter()
        {
            Console.WriteLine("Waiting...");
            _waitHandle.WaitOne(); // Wait for notification
            Console.WriteLine("Notified");
        }
    }
}
