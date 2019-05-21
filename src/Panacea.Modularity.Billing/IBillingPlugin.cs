using Panacea.Models;
using Panacea.Modularity.UiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    public interface IBillingPlugin : ICallablePlugin
    {
        Task<bool> ConsumeItemAsync(string pluginName, ServerItem item);

        Task<bool> ConsumeQuantityAsync(string pluginName, int quantity);

        Task<bool> ConsumeItemOrRequestServiceAsync(string message, string pluginName, ServerItem item);

        Task<bool> ConsumeQuantityOrRequestServiceAsync(string pluginName, int quantity);

        Task<Service> GetServiceForItemAsync(string pluginName, ServerItem item);

        Task<Service> GetServiceForQuantityAsync(string pluginName);
    }
}
