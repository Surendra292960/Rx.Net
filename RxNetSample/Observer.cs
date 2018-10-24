using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RxNetSample
{
    class Observer : IObserver<int>
    {
        public void OnCompleted()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            Console.WriteLine($"Observation completed on thread {threadId}.");
        }

        //internal static IObservable<T> Create<T>(Action writeLine, Func<object, object> p1, Func<object> p2)
        //{
        //    throw new NotImplementedException();
        //}

        //internal static IObservable<T> Create<T>(object writeLine)
        //{
        //    throw new NotImplementedException();
        //}

        public void OnError(Exception error)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            Console.WriteLine($"Error reported on thread{threadId}:{error.Message}");
        }

        public void OnNext(int value)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            Console.WriteLine($"Value received on thread{threadId}:{value}");
        }
    }
}