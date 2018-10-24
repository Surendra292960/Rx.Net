using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace RxNetSample
{
    class Program7 
    {
        static void Main(string[] args)
        {
            Demo();

            Console.WriteLine("Press any Key to Exit the Program.....");
            Console.ReadKey();
        }
        static void Demo()
        {
            var observable = Observable.Create<int>(observer =>
            {
                Timer timer = null;
                int counter = 0;

                try
                {
                    timer = new Timer(o =>
                   {
                       if(counter == 3)
                       {
                           observer.OnCompleted();
                       }

                       observer.OnNext(counter);
                       Interlocked.Increment(ref counter);

                   },null, TimeSpan.Zero, TimeSpan.FromMilliseconds(500));

                }
                catch (Exception ex)
                {
                    observer.OnError(ex);
                }
                return timer;
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
