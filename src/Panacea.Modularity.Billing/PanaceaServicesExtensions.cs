using Panacea.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    public static class PanaceaServicesExtensions
    {
        public static bool TryGetBilling(this PanaceaServices core, out IBillingManager manager)
        {
            manager = core.PluginLoader.GetPlugins<IBillingPlugin>().FirstOrDefault()?.GetBillingManager();
            return manager != null;
        }
    }
}
