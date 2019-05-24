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
        IBillingManager GetBillingManager();
    }
}
