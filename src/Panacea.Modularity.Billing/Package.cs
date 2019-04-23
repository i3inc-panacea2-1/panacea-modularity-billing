using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    [DataContract]
    public class Package : Service
    {
        [DataMember(Name = "featured")]
        public bool Featured { get; set; }

        [DataMember(Name = "services")]
        public List<ServicePriority> Services { get; set; }

    }
}
