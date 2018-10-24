using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace RxNetSample
{
    class Program5
    {
        static void Main(string[] args)
        {
            Demo();

            Console.WriteLine("Press any Key to Exit the Program.....");
            Console.ReadKey();
        }
        static void Demo()
        {
            IObservable<int> observable = Observable.Create<int>(observer =>
            {
                Console.WriteLine("Something");
                return System.Reactive.Disposables.Disposable.Empty;
            });

            var subscription = observable.Subscribe(
                Console.WriteLine,
                Exception => Console.WriteLine(Exception.Message),
                () => Console.WriteLine("Completed"));
        }
    }
}
