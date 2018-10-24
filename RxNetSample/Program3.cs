using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxNetSample
{
    class Program3
    {
        static void Main(string[] args)
        {
            Demo();
            Console.WriteLine("Press any Key to Exit the Program.....");
            Console.ReadKey();
        }
        static void Demo()
        {
            var subject = new Subject<string>();

            var o1 = new[] { "Hello", "World" }.ToObservable();

            var s4 = o1.Subscribe(subject);
        }
    }
}
