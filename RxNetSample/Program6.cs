using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace RxNetSample
{
    class Program6
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
                try
                {
                    observer.OnNext(1);
                    observer.OnNext(2);
                    observer.OnNext(3);

                   // throw new Exception("Oops!");

                    observer.OnCompleted();

                }
                catch(Exception ex)
                {
                    observer.OnError(ex);
                }
                return Disposable.Empty;
            });

            var subscription = observable.Subscribe(
                Console.WriteLine,
                Exception => Console.WriteLine(Exception.Message),
                () => Console.WriteLine("Completed"));
            Console.WriteLine("Disposing subscription.");
            subscription.Dispose();
        }
    }
}
