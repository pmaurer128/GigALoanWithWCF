using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
        
using GigALoan_DAL;
using GigALoan_Model;
using Newtonsoft.Json;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SPRT_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SPRT_Service.svc or SPRT_Service.svc.cs at the Solution Explorer and start debugging.
    public class SPRT_Service : ISPRT_Service
    {
        public string GetCollegeByID(string json)
        {
            var requestObject = JsonConvert.DeserializeObject<DTO_SPRT_College>(json);

            DTO_SPRT_College returnCollege = new DTO_SPRT_College();

            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var college = context.proc_GetColleges().Where(col => col.CollegeID == requestObject.CollegeID).Single();
            DTO_SPRT_College result = new DTO_SPRT_College(college.CollegeID, college.CollegeName);

            return JsonConvert.SerializeObject(result);
        }

        public string GetColleges()
        {
            List<DTO_SPRT_College> results = new List<DTO_SPRT_College>();
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var list = context.proc_GetColleges().ToList();
            foreach (var entity in list)
            {
                results.Add(new DTO_SPRT_College(entity.CollegeID, entity.CollegeName));
            }

            return JsonConvert.SerializeObject(results);
        }

        public string GetMajorByID(string json)
        {
            var requestObject = JsonConvert.DeserializeObject<DTO_SPRT_Major>(json);

            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var major = context.proc_GetMajors().Where(m => m.MajorID == requestObject.MajorID).Single();
            DTO_SPRT_Major result = new DTO_SPRT_Major(major.MajorID, major.MajorName);

            return JsonConvert.SerializeObject(result);
        }

        public string GetMajors()
        {
            List<DTO_SPRT_Major> results = new List<DTO_SPRT_Major>();
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var list = context.proc_GetMajors().ToList();
            foreach (var entity in list)
            {
                results.Add(new DTO_SPRT_Major(entity.MajorID, entity.MajorName));
            }

            return JsonConvert.SerializeObject(results);
        }

        public string GetGigTypeByID(string json)
        {
            var requestObject = JsonConvert.DeserializeObject<DTO_SPRT_GigType>(json);

            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var gigType = context.proc_GetGigTypes().Where(gt => gt.typeid == requestObject.TypeID).Single();
            DTO_SPRT_GigType result = new DTO_SPRT_GigType(gigType.typeid, gigType.TypeName);

            return JsonConvert.SerializeObject(result);
        }

        public string GetGigTypes()
        {
            List<DTO_SPRT_GigType> results = new List<DTO_SPRT_GigType>();
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var list = context.proc_GetGigTypes().ToList();
            foreach (var entity in list)
            {
                results.Add(new DTO_SPRT_GigType(entity.typeid, entity.TypeName));
            }

            return JsonConvert.SerializeObject(results);
        }

        public string GetGigTypeByCategoryID(string json)
        {
            var requestObject = JsonConvert.DeserializeObject<DTO_SPRT_GigType>(json);

            List<DTO_SPRT_GigType> results = new List<DTO_SPRT_GigType>();
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var list = context.proc_GetGigTypes().Where(gt => gt.CategoryID == requestObject.CategoryID).ToList();

            foreach (var entity in list)
            {
                results.Add(new DTO_SPRT_GigType(entity.typeid, entity.TypeName));
            }

            return JsonConvert.SerializeObject(results);
        }

        public string GetGigCategoryByID(string json)
        {
            var requestObject = JsonConvert.DeserializeObject<DTO_SPRT_GigCategory>(json);

            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var gigCategory = context.SPRT_GigCategories.Where(gc => gc.CategoryID == requestObject.CategoryID).Single();
            DTO_SPRT_GigCategory result = new DTO_SPRT_GigCategory(gigCategory.CategoryID, gigCategory.Category);

            return JsonConvert.SerializeObject(result);
        }

        public string GetGigCategories()
        {
            List<DTO_SPRT_GigCategory> results = new List<DTO_SPRT_GigCategory>();
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var list = context.SPRT_GigCategories.ToList();
            foreach (var entity in list)
            {
                results.Add(new DTO_SPRT_GigCategory(entity.CategoryID, entity.Category));
            }

            return JsonConvert.SerializeObject(results);
        }

        public string GetLoanCompanyByID(string json)
        {
            var requestObject = JsonConvert.DeserializeObject<DTO_SPRT_LoanCompany>(json);

            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var loanCompany = context.SPRT_LoanCompanies.Where(lc => lc.CompanyID == requestObject.CompanyID).Single();
            DTO_SPRT_LoanCompany result = new DTO_SPRT_LoanCompany
            {
                CompanyID = loanCompany.CompanyID,
                CompanyName = loanCompany.CompanyName,
                CompanyState = loanCompany.CompanyState
            };

            return JsonConvert.SerializeObject(result);
        }

        public string GetGigLoanCompanies()
        {
            List<DTO_SPRT_LoanCompany> results = new List<DTO_SPRT_LoanCompany>();
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var list = context.SPRT_LoanCompanies.ToList();
            foreach (var entity in list)
            {
                results.Add(new DTO_SPRT_LoanCompany
                {
                    CompanyID = entity.CompanyID,
                    CompanyName = entity.CompanyName,
                    CompanyState = entity.CompanyState
                });
            }

            return JsonConvert.SerializeObject(results);
        }
    }
}
