using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace CustomAuthorization.Logic
{
    public class Authorization : IAuthorization
    {
        IDictionary<string, List<string>> GetRecusosByRoles()
        {
            IDictionary<string, List<string>> authorizacion = new Dictionary<string, List<string>>();

            List<string> all = new List<string> {"admin", "user"};
            List<string> admin = new List<string> { "admin", "user" };

            authorizacion.Add("GetClientById", all);
            authorizacion.Add("GetClientByUserName", all);
            authorizacion.Add("GetPolicesByClient", admin);
            authorizacion.Add("GetLinked", admin);

            return authorizacion;
        }

        public bool GetAuthorizationByAction(string action, string role)
        {
            var configAuthorization = GetRecusosByRoles().Where(authorization => authorization.Key.Equals(action));
            var hasAuthorization = configAuthorization.Select(roleAuthorization => roleAuthorization.Value.Contains(role)).Any();
            if (hasAuthorization)
            {
                return true;
            }
            return false;
        }
    }

}
