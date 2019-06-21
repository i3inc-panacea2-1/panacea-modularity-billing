using Panacea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    public interface IServiceMonitor : IDisposable
    {
        event EventHandler<Service> ServiceExpired;
        Service CurrentService { get; }

        void Monitor(Service service, ServerItem item);

        void Monitor(Service service);

        void StopMonitor();

    }
}
