using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingPrimer
{
    class Program
    {
        static string Greeting = "Hello";
        static void Main(string[] args)
        {
            Console.WriteLine("Main() from thread {0}",Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Min = ");
            var min = int.Parse(Console.ReadLine());

            //var t = new Thread(new ParameterizedThreadStart(SayHi));
            var t = new Thread(SayHi);
            t.Start("magesh");
            //t.Join();
            SayHi("Suresh");
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static void SayHi(object name)
        {
            Console.WriteLine("{2} {0} (from a different thread!! Id = {1})",name,Thread.CurrentThread.ManagedThreadId,Greeting);
        }
    }
}
