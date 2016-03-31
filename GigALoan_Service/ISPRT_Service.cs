using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISPRT_Service" in both code and config file together.
    [ServiceContract]
    public interface ISPRT_Service
    {
        [OperationContract]
        string GetCollegeByID(string json);

        [OperationContract]
        string GetColleges();

        [OperationContract]
        string GetMajorByID(string json);

        [OperationContract]
        string GetMajors();

        [OperationContract]
        string GetGigTypeByID(string json);

        [OperationContract]
        string GetGigTypes();

        [OperationContract]
        string GetGigTypeByCategoryID(string json);

        [OperationContract]
        string GetGigCategoryByID(string json);

        [OperationContract]
        string GetGigCategories();

        [OperationContract]
        string GetLoanCompanyByID(string json);

        [OperationContract]
        string GetGigLoanCompanies();
    }
}
