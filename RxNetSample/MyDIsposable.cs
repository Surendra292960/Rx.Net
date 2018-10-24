using System;
using System.Diagnostics;

namespace RxNetSample
{
    class MyDisposable : IDisposable
    {
        public void Dispose()
        {
            var callerName = new StackTrace().GetFrame(1)?.GetMethod()?.Name;
            Console.WriteLine($"Dispose called by {callerName}.");
        }
    }
}