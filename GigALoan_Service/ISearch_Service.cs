using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using GigALoan_Model;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISearch_Service" in both code and config file together.
    [ServiceContract]
    public interface ISearch_Service
    {
        [OperationContract]
        string FindLocalAlerts(string request);

        [OperationContract]
        string FindAlertsByPay(string request);

        [OperationContract]
        string FindAlertsByType(string request);

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/FindAlertByID", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<DTO_CORE_GigAlert> FindAlertByID(DTO_CORE_GigAlert request);

        [OperationContract]
        string FindGigByAlertID(string request);

        [OperationContract]
        string FindGigsByStudentID(string request);

        [OperationContract]
        string FindGigsByClientID(string request);
    }
}
