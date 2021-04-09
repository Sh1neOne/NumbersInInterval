using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumbersInInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вычислите количество чисел на промежутке от 1_000_000_000 до 2_000_000_000, в которых сумма цифр кратна последней цифре числа. 
            //Для выполнения данного задания используйте многопоточность.
            int count = 0;
            var stopWatch = Stopwatch.StartNew();

            Parallel.For(1_000_000_000, 2_000_000_000,
                     (index, pls) =>
                     {
                         int lastNumb;
                         lastNumb = index % 10;
                         if (lastNumb == 0)
                         {
                             Interlocked.Increment(ref count);
                         }
                         else
                         {
                             int n, sum = 0;
                             n = index;
                             while (n != 0)
                             {
                                 sum += n % 10;
                                 n /= 10;
                             }
                             if (sum % lastNumb == 0) { Interlocked.Increment(ref count); }
                         }
                          
                     }
                );

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            Console.WriteLine("Время выполнения " + elapsedTime);
            Console.WriteLine("Количество: " + count);
            Console.ReadLine();
        }
    }
}
