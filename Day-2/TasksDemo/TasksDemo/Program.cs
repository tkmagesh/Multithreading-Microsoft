using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var tasks = new List<Task<int>>{
                new Task<int>(DoWork,1000),
                new Task<int>(DoWork,10000)
            };

            tasks.ForEach(t => t.Start());
            var completedIndex = Task.WaitAny(tasks.ToArray());
            
            Console.WriteLine(tasks[completedIndex].Result);
            */
            Console.WriteLine("Main thread id = {0}",Thread.CurrentThread.ManagedThreadId);
            /*
            var task1 = new Task<int>(DoWork, 1000);
            task1.ContinueWith((prevTask) =>
            {

                Console.WriteLine("This is the subsequent task with thread id = {0}",Thread.CurrentThread.ManagedThreadId );
                Console.WriteLine("The result from the previous task is " + prevTask.Result);
            });
            task1.Start();
            */
            
            Parallel.Invoke(
                () => DoWork(1000),
                () => DoWork(10000)
                    );

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static int DoWork(object taskDuration)
        {
            Console.WriteLine("Inside DoWork - Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep((int)taskDuration);
            Debug.WriteLine("This method is executed in a different thread");
            return (int)taskDuration;
           // return "Some result data";
        }
    }
}
