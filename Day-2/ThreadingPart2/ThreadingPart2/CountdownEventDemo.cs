﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingPart2
{
    class CountdownEventDemo
    {
        static CountdownEvent _countdown = new CountdownEvent(3);
        static void Main()
        {
            new Thread(SaySomething).Start("I am thread 1");
            new Thread(SaySomething).Start("I am thread 2");
            new Thread(SaySomething).Start("I am thread 3");
            new Thread(SaySomething).Start("I am thread 3");
            _countdown.Wait(); // Blocks until Signal has been called 3 times
            Console.WriteLine("All threads have finished speaking!");
        }
        static void SaySomething(object thing)
        {
            Thread.Sleep(1000);
            Console.WriteLine(thing);
            _countdown.Signal();
        }
    }
}
