using System.Collections.Generic;

namespace Domain.Model
{
    public class ClientWrapper
    {
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string id { get; set; }
    }

    public class ClientsWrapper
    {
        public List<ClientWrapper> Clients { get; set; }
    }
}