using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellationDemo
{
    class Program
    {
        static CancellationTokenSource source;
        static void Main(string[] args)
        {
            source = new CancellationTokenSource();
            
            var t = new Task(DoWork,source.Token);
            t.Start();
            Console.WriteLine("Task Running... Press ENTER to cancel the task if still running...");
            Console.ReadLine();

            if (t.Status == TaskStatus.Running)
            {
                source.Cancel();
            }
            else
            {
                Console.WriteLine("Task completed naturally");
            }
            
            Console.ReadLine();

        }

        static void DoWork(object token)
        {
            var t = (CancellationToken)token;
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
                
                //if (source.IsCancellationRequested)
                if (t.IsCancellationRequested)
                {
                    Console.WriteLine("Task cancellation requested");
                    break;
                }
            }
        }
    }
}
