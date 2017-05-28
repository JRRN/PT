using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CustomAuthorization
{
    public interface IAuthorization
    {
        bool GetAuthorizationByAction(string action, string role);

    }

    
}
