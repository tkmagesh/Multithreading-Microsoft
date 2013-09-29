using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;

namespace ThreadingPart2
{
    [Synchronization]
    public class AutoLock : ContextBoundObject
    {
        public void Demo()
        {
            Console.Write("Start...");
            Thread.Sleep(1000); // We can't be preempted here
            Console.WriteLine("end"); // thanks to automatic locking!
        }
    }
    public class Test
    {
        public static void Main()
        {
            AutoLock safeInstance = new AutoLock();
            new Thread(safeInstance.Demo).Start(); // Call the Demo
            new Thread(safeInstance.Demo).Start(); // method 3 times
            safeInstance.Demo(); // concurrently.
        }
    }
}
