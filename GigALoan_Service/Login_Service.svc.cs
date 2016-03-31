using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Newtonsoft.Json;
using GigALoan_Model;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Login_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Login_Service.svc or Login_Service.svc.cs at the Solution Explorer and start debugging.
    public class Login_Service : ILogin_Service
    {
        public string ValidateAccount(string loginRequest, string typeOfAccount)
        {
            if (typeOfAccount == "Student")
            {
                DTO_CORE_Student student;

                student = GetStudentAccount(loginRequest);

                string studentJsonObject = JsonConvert.SerializeObject(student);

                return studentJsonObject;
            }
            else if (typeOfAccount == "Client")
            {
                DTO_CORE_Client client;

                client = GetClientAccount(loginRequest);

                string clientJsonObject = JsonConvert.SerializeObject(client);

                return clientJsonObject;
            }
            else
            {
                return null;
            }

        }

        public DTO_CORE_Student GetStudentAccount(string loginRequest)
        {
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var requestedStudentAccess = JsonConvert.DeserializeObject<DTO_CORE_Student>(loginRequest);

            var studentList = context.CORE_Students.ToList();

            DTO_CORE_Student successfulMatchedStudent = null;

            foreach (var student in studentList)
            {
                if (requestedStudentAccess.Email.ToLower() == student.Email.ToLower())
                {
                    if (requestedStudentAccess.Pass == student.Pass)
                    {
                        successfulMatchedStudent = new DTO_CORE_Student();

                        successfulMatchedStudent.StudentID = student.StudentID;
                        successfulMatchedStudent.FirstName = student.FirstName;
                        successfulMatchedStudent.LastName = student.LastName;
                        successfulMatchedStudent.DateJoined = student.DateJoined;
                        successfulMatchedStudent.Email = student.Email;
                        successfulMatchedStudent.Pass = student.Pass;
                        successfulMatchedStudent.MajorID = student.MajorID;
                        successfulMatchedStudent.CollegeID = student.CollegeID;
                        successfulMatchedStudent.Gender = student.Gender;

                        if (student.Employed != null)
                        {
                            successfulMatchedStudent.Employed = (bool)student.Employed;
                        }

                        successfulMatchedStudent.Employer = student.Employer;
                        successfulMatchedStudent.PhoneNumber = student.PhoneNumber;

                        return successfulMatchedStudent;
                    }
                }
            }
            return null;
        }

        public DTO_CORE_Client GetClientAccount(string loginRequest)
        {
            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();

            var requestedClientAccess = JsonConvert.DeserializeObject<DTO_CORE_Client>(loginRequest);

            var clientList = context.CORE_Clients.ToList();

            DTO_CORE_Client successfulMatchedClient = null;

            foreach (var client in clientList)
            {
                if (requestedClientAccess.Email.ToLower() == client.Email.ToLower())
                {
                    if (requestedClientAccess.Pass == client.Pass)
                    {
                        successfulMatchedClient = new DTO_CORE_Client();

                        successfulMatchedClient.ClientID = client.ClientID;
                        successfulMatchedClient.FirstName = client.FirstName;
                        successfulMatchedClient.DateJoined = client.DateJoined;
                        successfulMatchedClient.Email = client.Email;
                        successfulMatchedClient.Pass = client.Pass;
                        successfulMatchedClient.Gender = client.Gender;
                        successfulMatchedClient.PhoneNumber = client.PhoneNumber;

                        if (client.Active != null)
                        {
                            successfulMatchedClient.Active = (bool)client.Active;
                        }

                        return successfulMatchedClient;
                    }
                }
            }

            return null;
        }
    }
}
