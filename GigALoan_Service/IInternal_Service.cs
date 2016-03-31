using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GigALoan_Model;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInternal_Service" in both code and config file together.
    [ServiceContract]
    public interface IInternal_Service
    {
        [OperationContract]
        string GetStudentsBySkillID(string json);

        [OperationContract]
        List<DTO_CORE_Student> AlertLocalStudents(DTO_CORE_GigAlert alert, int range);

        [OperationContract]
        bool isLocal(double lat1, double lon1, double lat2, double lon2, int range);
    }
}
