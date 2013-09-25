using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Text;
using System.Threading;

namespace PrimeFinderAssignment
{
    class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    class Program
    {
        public static  int PrimeCount;
        public static Object obj = new Object();
        
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();


            Console.Write("Start = ");
            var min = int.Parse(Console.ReadLine());
            Console.Write("End = ");
            var max = int.Parse(Console.ReadLine());
            //Console.WriteLine("First max = {0}", ((max + min) / 2));
            //Console.WriteLine("Second Min = {0}", ((max + min) / 2) + 1);
            Console.ReadLine();
            sw.Start();
            var t1 = new Thread(FindPrimeCount);
            var t2 = new Thread(FindPrimeCount);

            var r1 = new Range { Min = min, Max = ((max + min) / 2) };
            //var r1 = new Range { Min = min, Max = max };
            var r2 = new Range { Min = ((max + min) / 2) + 1, Max = max };
            
            t1.Start(r1);
            t2.Start(r2);

            t1.Join();
            t2.Join();
            sw.Stop();
            Console.WriteLine("{0} prime numbers are found between {1} and {2} in {3} milliseconds",PrimeCount,min,max,sw.ElapsedMilliseconds);
            Console.ReadLine();
        }

        /*public static void FindPrimeCount(object objRange) {
            var range = (Range)objRange;
            var localCount = 0;
            for (var n = range.Min; n <= range.Max; n++)
            {
                if (IsPrime(n))
                {
                    localCount++;
                }
            }
            lock (obj)
            {
                PrimeCount += localCount;
            }
          
        }*/
        public static void FindPrimeCount(object objRange)
        {
            var range = (Range)objRange;
            for (var n = range.Min; n <= range.Max; n++)
            {
                if (IsPrime(n)){
                    lock (obj)
                    {
                        PrimeCount++;
                    }
                }
            }
            

        }

        public static bool IsPrime(int n)
        {
            if (n <= 3) return true;
            for (var i = 2; i <= (n - 1); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}
