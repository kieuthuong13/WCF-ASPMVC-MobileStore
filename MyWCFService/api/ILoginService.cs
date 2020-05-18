using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        string LoginAdmin(string email, string password, out int id); // return token

        [OperationContract]
        string LoginUser(string username, string password, out int id); // return token
    }
}
