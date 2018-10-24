using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace RxNetSample
{
    class Program8
    {
        static void Main(string[] args)
        {
            Demo();

            Console.WriteLine("Press any Key to Exit the Program.....");
            Console.ReadKey();
        }
        static void Demo()
        {
            var observable = Observable.Create<long>(observer =>
            {
              
                try
                {
                    var innerObservable = Observable .Timer(

                        TimeSpan.FromMilliseconds(0),
                        TimeSpan.FromMilliseconds(500))
                        .Skip(1) //To skip the value 0 and start from 11 instead
                        .Take(3);// To Take the first thre values

                    return innerObservable.Subscribe(observer);
                }
                catch (Exception ex)
                {
                    observer.OnError(ex);
                }
                return Disposable.Empty;
            });

            var subscription = observable.Subscribe(
                Console.WriteLine,
                ex => Console.WriteLine(ex.Message),
                () => Console.WriteLine("Completed"));
            Console.WriteLine("Press any key Disposing subscription.");
            Console.ReadKey();
            subscription.Dispose();
        }
    }
}
