using Panacea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    public interface IBillingManager
    {
        Task<IBillingSettings> GetSettingsAsync();

        bool IsPluginFree(string plugnName);

        Task<Service> GetServiceForItemAsync(string message, string pluginName, ServerItem item);

        Task<Service> GetServiceForQuantityAsync(string message, string pluginName, int quantity);

        Task<Service> GetServiceAsync(string message, string pluginName);

        Task<List<Service>> GetActiveUserServicesAsync();

        List<Service> GetActiveUserServicesSilently();

        Task<List<Ledger>> GetUserPurchaseHistoryAsync();

        void NavigateToBuyServiceWizard();

    }
}
