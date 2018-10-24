using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RxNetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            Console.WriteLine($"Program started on main thread withId {threadId}......");

            var observable = Observable.Range(5,8);

            var subscription = observable.Subscribe(new Observer());

            Console.ReadKey();

            subscription.Dispose();
        }
    }
}
