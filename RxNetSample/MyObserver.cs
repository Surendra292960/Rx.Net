using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxNetSample
{
    internal class MyObserver<T> : IObserver<T>
    {

        private string _name = null;

        public MyObserver(string subscriberName = "Subscriber 1")
        {
            _name = subscriberName;
        }

        public virtual void OnCompleted()
        {
            Console.Write($"Observation completed by {_name}");
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine($"An Error occured while {_name} was observing:{error}");
        }

        public virtual void OnNext(T value)
        {
            Console.WriteLine($" {_name} received:{value.ToString()}");
        }
    }
}
