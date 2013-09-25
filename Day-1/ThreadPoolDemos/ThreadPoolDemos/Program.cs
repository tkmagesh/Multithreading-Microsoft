using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread Id = {0} in Main()", Thread.CurrentThread.ManagedThreadId);
            var range = new Range { Min = 1, Max = 100 };
            //ThreadPool.QueueUserWorkItem(FindPrimes, range);
            //FindPrimesUsingBackgroundWorker(range);


            Console.ReadLine();
        }

        private static void FindPrimesUsingBackgroundWorker(Range range)
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += FindPrimesForBackgroundWorker;
            /*worker.DoWork += (o, e) =>
            {
                FindPrimes((Range)e.Argument);
                //FindPrimes(range);
            };*/
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync(range);
        }

        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine("Thread Id in Progress = {0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine(e.ProgressPercentage + " % completed");
        }

        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Completed");
        }

        public static void FindPrimesForBackgroundWorker(object sender, DoWorkEventArgs dea) {
            //FindPrimes(dea.Argument);
            var range = (Range)dea.Argument;
            var primeCount = 0;
            var progressUpdateStage = ((range.Max - range.Min)+1) / 100;
           Debug.WriteLine("Thread Id in FindPrimesForBackgroundWorker = {0}", Thread.CurrentThread.ManagedThreadId);
           
            for(var i=range.Min; i<= range.Max;i++){
                if (PrimeFinder.IsPrime(i)) primeCount++;
                var progress = ((double)(i - range.Min + 1) / (range.Max - range.Min + 1)) * 100;
                ((BackgroundWorker)sender).ReportProgress((int)progress);
            }
        }

        public static void FindPrimes(object objRange)
        {
            Console.WriteLine("Thread Id = {0} in FindPrimes()", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Is the thread a Background thread? {0}", Thread.CurrentThread.IsBackground);
            PrimeFinder.FindPrimeCount(objRange);
            var range = (Range)objRange;
            Console.WriteLine("{0} prime numbers are found between {1} and {2}",PrimeFinder.PrimeCount, range.Min, range.Max);
            Console.ReadLine();
        }
    }

    
    class Range {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    class PrimeFinder
    {
        public static int PrimeCount;
        public static Object obj = new Object();

        public static void FindPrimeCount(object objRange)
        {
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

        }

        public static bool IsPrime(int n)
        {
            if (n <= 3) return true;
            for (var i = 2; i <= (n / 2); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}
