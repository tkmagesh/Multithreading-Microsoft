using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LambdaIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (var i = 0; i < 10; i++)
            {
                var num = i;
                new Thread(() => Console.WriteLine(num)).Start();
            }
            Console.ReadLine();
        }
    }
}
