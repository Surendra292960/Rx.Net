using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RxNetSample
{
    class MySlowOserver<T> : MyObserver<T>
    { 
        public MySlowOserver(string subscriberName = "Subscriber 1")
        :base(subscriberName)
    {
    }
        public override void OnNext(T value)
        {
            Thread.Sleep(1000);

            base.OnNext(value);
        }
    }
}
