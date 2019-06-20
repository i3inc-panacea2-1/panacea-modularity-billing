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

        /// <summary>
        /// Returns a service for a plugin for a specific item. Will ask the user to buy service if no active service is found.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="pluginName">The name of the plugin.</param>
        /// <param name="item">The item to be checked.</param>
        /// <returns>The service that matches or null</returns>
        Task<Service> GetOrRequestServiceForItemAsync(string message, string pluginName, ServerItem item);

        /// <summary>
        /// Returns a service for a plugin for a specific item.
        /// </summary>
        /// <param name="pluginName">The name of the plugin.</param>
        /// <param name="item">The item to be checked.</param>
        /// <returns>The service that matches or null</returns>
        Task<Service> GetServiceForItemAsync(string pluginName, ServerItem item);


        /// <summary>
        /// Returns a service with remaining quantity or asks users to buy service.
        /// </summary>
        /// <param name="message">The message to show.</param>
        /// <param name="pluginName">The name of the plugin.</param>
        /// <returns>The service or null</returns>
        Task<Service> GetOrRequestServiceForQuantityAsync(string message, string pluginName);

        /// <summary>
        /// Returns a service with remaining quantity.
        /// </summary>
        /// <param name="message">The message to show.</param>
        /// <param name="pluginName">The name of the plugin.</param>
        /// <returns>The service or null</returns>
        Task<Service> GetServiceForQuantityAsync(string pluginName);

        /// <summary>
        /// Returns any active service for a plugin name. Will ask users to buy service if none exists.
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="pluginName">The name of the plugin</param>
        /// <returns>The service or null</returns>
        Task<Service> GetOrRequestServiceAsync(string message, string pluginName);

        /// <summary>
        /// Returns any active service for a plugin name. Will ask users to buy service if none exists.
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="pluginName">The name of the plugin</param>
        /// <returns>The service or null</returns>
        Task<Service> GetServiceAsync(string pluginName);

        /// <summary>
        /// Refreshes current user's services and returns the active services
        /// </summary>
        /// <returns></returns>
        Task<List<Service>> GetActiveUserServicesAsync();

        /// <summary>
        /// Returns active services without refreshing
        /// </summary>
        /// <returns></returns>
        List<Service> GetActiveUserServices();

        /// <summary>
        /// Returns the purchase history.
        /// </summary>
        /// <returns></returns>
        Task<List<Ledger>> GetUserPurchaseHistoryAsync();

        /// <summary>
        /// Navigates to buy services wizard.
        /// </summary>
        void NavigateToBuyServiceWizard();

        /// <summary>
        /// Consumes quantity.
        /// </summary>
        /// <param name="pluginName">plugin name</param>
        /// <param name="quantity">quantity</param>
        /// <returns>true for success</returns>
        Task<bool> ConsumeQuantityAsync(string pluginName, int quantity);

        /// <summary>
        /// Consumes an item.
        /// </summary>
        /// <param name="pluginName">plugin name</param>
        /// <param name="item">The item to consume</param>
        /// <returns></returns>
        Task<bool> ConsumeItemAsync(string pluginName, ServerItem item);

        /// <summary>
        /// Consumes an item.
        /// </summary>
        /// <param name="pluginName">plugin name</param>
        /// <param name="item">The item to consume</param>
        /// <returns></returns>
        Task<bool> RequestServiceAndConsumeItemAsync(string text, string pluginName, ServerItem item);

        IServiceMonitor CreateServiceMonitor();

    }
}
