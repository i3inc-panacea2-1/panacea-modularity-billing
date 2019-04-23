using Panacea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Billing
{
    [DataContract]
    public class Ledger : ServerItem
    {
        [DataMember(Name = "transactionType")]
        public string TransactionType { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "packageItem")]
        public Package PackageItem { get; set; }

        [DataMember(Name = "services")]
        public List<Service> Services { get; set; }

        [DataMember(Name = "amountWithTaxes")]
        public double TotalAmount { get; set; }

        [DataMember(Name = "discountAmount")]
        public double DiscountAmount { get; set; }
    }
}
