using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RxNetSample
{
    class MyRangeObservable : IObservable<int>
    {
        private int _start;
        private int _count;
        private int _current;

        public MyRangeObservable(int start, int count)
        {
            _start = start;
            _count = count;
            _current = start;
        }
        public IDisposable Subscribe(IObserver<int> observer)
        {
            try
            {
                Task.Run(() =>
                { 
                //observer.OnError(new Exception("Oops!"));
                for ( _current = _start; _current < _start + _count; _current++)
                {
                        //observer.OnCompleted();
                      Thread.Sleep(1000);
                      observer.OnNext(_current);
                }

                observer.OnCompleted();
            });
                return new MyDisposable();
            }
            catch(Exception ex)
            {
                observer.OnError(ex);
               return new MyDisposable();
            }
        }
    }
}
