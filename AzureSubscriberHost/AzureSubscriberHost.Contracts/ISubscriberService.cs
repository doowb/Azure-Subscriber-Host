using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureSubscriberHost.Contracts
{
    public interface ISubscriberService : IDisposable
    {
        void Start();
        void Stop();
    }
}
