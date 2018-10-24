using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxNetSample
{
    class Program15
    {
        private static void Log(object onNextValue)
        {
            Console.WriteLine("Logging OnNext({0}) @ {1}", onNextValue, DateTime.Now);
        }
        private static void Log(Exception onErrorValue)
        {
            Console.WriteLine("Logging OnError({0}) @ {1}", onErrorValue, DateTime.Now);
        }
        private static void Log()
        {
            Console.WriteLine("Logging OnCompleted()@ {0}", DateTime.Now);
        }
        static void Main(string[] args)
        {
            var source = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Take(3);
            var result = source.Do(
            i => Log(i),
            ex => Log(ex),
            () => Log());
            result.Subscribe(
            Console.WriteLine,
            () => Console.WriteLine("completed"));
            Console.Read();
        }
    }
}
