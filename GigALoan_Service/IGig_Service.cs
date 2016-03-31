using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGig_Service" in both code and config file together.
    [ServiceContract]
    public interface IGig_Service
    {
        [OperationContract]
        string CreateGig(string gigFromAlert);
    }
}
