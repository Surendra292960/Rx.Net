using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace RxNetSample
{
    class Program4
    {
        static void Main(string[] args)
        {
            Demo();
            Console.WriteLine("Press any Key to Exit the Program.....");
            Console.ReadKey();
        }
        static void Demo()
        {
            var subject = new Subject<string>();

            var o1 = new[] { "Hello", "World" }.ToObservable();


            var s1 = subject.Subscribe(v => Program4.PrintToConsole("Sub 1", v));
            var s2 = subject.Subscribe(v => Program4.PrintToConsoleSlowly("Sub 2", v));
            var s3 = subject.Subscribe(v => Program4.PrintToDebugWindow("Sub 3", v));

            var s4 = o1.Subscribe(subject);

            Console.WriteLine("\nPress any Key to dispose all subscriptions.");
            s1.Dispose();
            s2.Dispose();
            s3.Dispose();
            s4.Dispose();
        }

        static void PrintToConsole<T>(string subscriberName, T value)
        {
            Console.WriteLine($"{ subscriberName}:{ value.ToString()}");
        }

        static void PrintToConsoleSlowly<T>(string subscriberName, T value)
        {
            Thread.Sleep(500);
            Console.WriteLine($"{ subscriberName}:{ value.ToString()}slowly......");
        }

        static void PrintToDebugWindow<T>(string subscriberName, T value)
        {
           
            Debug.WriteLine(string.Format($"{ subscriberName}:{ value.ToString()}"));
        }

    }
}
