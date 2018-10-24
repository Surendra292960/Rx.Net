using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace RxNetSample
{
    class Program9
    {
        static void Main(string[] args)
        {
            TimerExample();
        }

        static void TimerExample()
        {
         
            var period = TimeSpan.FromMilliseconds(500);
            var observable = Observable.Timer(period, period)
            .Skip(0)
            .Take(3);

            var subscription = observable.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("Observation Completed."));

            Console.WriteLine("Press any key to exit the program......");
            Console.ReadKey();
            subscription.Dispose();
        }
    }
}
