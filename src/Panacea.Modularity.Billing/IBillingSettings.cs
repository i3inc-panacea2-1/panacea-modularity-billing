using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    public interface IBillingSettings
    {
        string Symbol { get; }

        bool AllowRefunds { get; }

        bool AllowAssistanceRequests { get; }

    }
}
