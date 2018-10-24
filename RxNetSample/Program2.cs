using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxNetSample
{
    class Program2
    {
        static void Main(string[] args)
        {
            Demo();
            Console.WriteLine("Press any Key to Exit the Program.....");
            Console.ReadKey();
        }
         static void Demo()
        {
           var subject = new Subject<int>();

            var subscription = subject.Subscribe(Console.WriteLine);
            subject.OnNext(1);
            subject.OnNext(2);
            subscription.Dispose();
            subject.OnNext(3);
        }
    }
}
