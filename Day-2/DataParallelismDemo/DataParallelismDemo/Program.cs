using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace DataParallelismDemo
{
    class Program
    {
        //static List<int> primes = new List<int>();
        static void Main(string[] args)
        {
            /*
            Parallel.For(1, 100000, () => new List<int>(), (n,po, list) =>
            {
                if (IsPrime(n))
                {
                    //primes.Add(n);
                    list.Add(n);
                }
                return list;
            }, (list) => {
                
                Console.WriteLine("list contains {0} prime numbers - thread id = {1}",list.Count,Thread.CurrentThread.ManagedThreadId);
            });
            */

            Enumerable.Range(1, 100).AsParallel().Where(n => {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
                return true;
            }).ToList();
            Console.ReadLine();
        }

        public static bool IsPrime(int n)
        {
            if (n <= 3) return true;
            for (var i = 2; i <= (n / 2); i++)
                if (n % i == 0) return false;
            return true;
        }

    }

    public static class MyExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action) {
            foreach (var item in list)
                action(item);
        }
    }
}
