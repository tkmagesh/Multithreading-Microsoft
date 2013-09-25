using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProgrammingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread with Id = {0}", Thread.CurrentThread.ManagedThreadId);
            new Task(() => { 
                Console.WriteLine("Executed in a different thread with Id = {0}", Thread.CurrentThread.ManagedThreadId); 
            }).Start();
            Console.ReadLine();
        }
    }
}
