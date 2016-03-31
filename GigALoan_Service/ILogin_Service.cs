using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GigALoan_Model;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILogin_Service" in both code and config file together.
    [ServiceContract]
    public interface ILogin_Service
    {
        [OperationContract]
        string ValidateAccount(string loginRequest, string typeOfAccount);

        [OperationContract]
        DTO_CORE_Student GetStudentAccount(string loginRequest);

        [OperationContract]
        DTO_CORE_Client GetClientAccount(string loginRequest);
    }
}
