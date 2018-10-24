using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RxNetSample
{
    class Program1
    {
        static void Main(string[] args)
        {
            Demo();
             //var observable = new MyRangeObservable(5, 8);
             //var subscription = observable.Subscribe();
             //ObserverBaseMitigatesContactViolation2();

            Console.WriteLine("Press any key to exit the program");
            Console.ReadKey();
        }

        static void Demo()
        {
            var observable = new MyRangeObservable(5, 8);
            var subscription1 = observable.Subscribe(new MySlowOserver<int>("Subscriber 1"));
            subscription1.Dispose();
            Console.WriteLine("The subscription has been dispose but we're still receiving values.");


            //var subscription1 = observable.Subscribe(new MySlowOserver<int>("Subscriber 1"));
            //var subscription2 = observable.Subscribe(new MyObserver<int>("Subscriber 2"));
            //Console.WriteLine("Press any key to exit the program");
            //Console.ReadKey();
            //subscription1.Dispose();
            //subscription2.Dispose();
            //var subscription1 = observable.Subscribe(new MyObserver<int>("Subscribe 1"));
            //subscription1.Dispose();

            //Console.WriteLine();


            //var subscription2 = observable.Subscribe(new MyObserver<int>("Subscribe 2"));
            //subscription1.Dispose();


            //var observer = new MyObserver<int>();

            //var subscription = observable.Subscribe(observer);

            // Console.WriteLine("Press any key to exit the Demo method program");
            //  Console.ReadKey();

        }

        //static void ObserverBaseMitigatesContactViolation2()
        //{
        //    var observable = new MyRangeObservable(5, 8);

        //    var observer = Observer.Create<int>(Console.WriteLine,
        //        ex => Console.WriteLine(ex.Message),
        //        () => Console.WriteLine("completed."));

        //    var subscription = observable.Subscribe(observer);

        //    Console.WriteLine("Press any key to exit the Demo method program");
        //    Console.ReadKey();

        //}
    }
}
