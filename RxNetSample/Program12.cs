using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxNetSample
{
    class Program12
    {
        static void Main(string[] args)
        {
            var observable = Observable.Range(5, 8);

            var subscription = observable.Subscribe(
                Console.WriteLine,
                (error) => { Console.WriteLine($"Error:{error.Message}"); },
                () => { Console.WriteLine("Observation complete..."); }
                );

              Console.ReadKey();

            subscription.Dispose();
        }
    }
}
