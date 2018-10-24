using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxNetSample
{
    class Program10
    {
        static void Main(string[] args)
        {
            
            GetEnumerableItemsPeriodically();
        }

         static void GetEnumerableItemsPeriodically()
        {
            var period = TimeSpan.FromMilliseconds(500);
            var enumerable = new List<string> { "One", "Two", "Three" };

            var observable = Observable.Interval(period)
                .Zip(enumerable.ToObservable(), 
                (n, s) =>s);          

            var subscription = observable.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("Observation Completed."));

            Console.WriteLine("Press any key to exit the program......");
            Console.ReadKey();
            subscription.Dispose();
        }
    }
}
