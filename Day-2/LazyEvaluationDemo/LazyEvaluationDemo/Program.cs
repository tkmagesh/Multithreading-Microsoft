using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyEvaluationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 1000).ToList();
            var allEvenNumbers = MyUtils.FilterEven(numbers);
            var enumerator = allEvenNumbers.GetEnumerator();
            Console.WriteLine("First 10 even numbers");
            for (int i = 0; i < 10; i++)
            {
                if (enumerator.MoveNext()) 
                    Console.WriteLine(enumerator.Current);
            }
            Console.ReadLine();
        }
    }

    public static class MyUtils{
        public static IEnumerable<int> FilterEven(List<int> source) {
            //var result = new List<int>();
            foreach (var n in source)
            {
                if (n == 10)
                    yield break;
                if (n % 2 == 0)
                    yield return n;
            }
                    //result.Add(n);
            //return result;
        }
    }
}
