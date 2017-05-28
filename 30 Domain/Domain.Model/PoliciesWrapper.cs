using System.Collections.Generic;

namespace Domain.Model
{
    public class PolicieWrapper
    {
        public string amountInsured { get; set; }
        public string email { get; set; }
        public string inceptionDate { get; set; }
        public string installmentPayment { get; set; }
        public string clientId { get; set; }
        public string id { get; set; }
    }

    public class PoliciesWrapper
    {
        public List<PolicieWrapper> Policies { get; set; }
    }
}