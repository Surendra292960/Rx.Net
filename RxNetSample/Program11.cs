using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RxNetSample
{
    class Program11
    {
        public static object CompletionHandler { get; private set; }
        public static IObserver<int> ValueHandler { get; private set; }

        static void Main(string[] args)
        {
            DefaultStubForOnError();
            ButIfYouProvideOnErrorHandlerItAllWorksNicely();
            Console.ReadKey();
        }

        private static void ButIfYouProvideOnErrorHandlerItAllWorksNicely()
        {
            try
            {
                var observable = Observable.Create<int>(observer =>
                {
                    observer.OnNext(1);
                    observer.OnError(new Exception("Oops! That's all we Know"));

                    return Disposable.Create(() =>
                    {
                        Console.WriteLine("Dispose called.");
                    });
                });

               // var subscription = observable.Subscribe(ValueHandler, ExceptionHandler, CompletionHandler);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught:{ex.Message}");
                Console.WriteLine($"But we do have the remote stack trace:{ex.StackTrace.ToString()}");
                Console.WriteLine($"But still, this is kind of shoddy, don't you think?");
                Console.WriteLine();

            }
        }

        private static void DefaultStubForOnError()
        {
            try
            {
                var observable = Observable.Create<int>(observer =>
                {
                    observer.OnNext(1);
                    observer.OnError(new Exception("Oops! That's all we Know"));

                    return Disposable.Create(() =>
                    {
                        Console.WriteLine("Dispose called.");
                    });
                });

              //  var subscription = observable.Subscribe(ValueHandler, CompletionHandler);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception caught:{ex.Message}");
                Console.WriteLine($"But we do have the remote stack trace:{ex.StackTrace.ToString()}");
                Console.WriteLine($"But still, this is kind of shoddy, don't you think?");
                Console.WriteLine();

            }
        }
    }
}
