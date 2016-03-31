using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Newtonsoft.Json;
using GigALoan_DAL;
using GigALoan_Model;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Gig_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Gig_Service.svc or Gig_Service.svc.cs at the Solution Explorer and start debugging.
    public class Gig_Service : IGig_Service
    {
        public string CreateGig(string gigFromAlert)
        {
            var gig = JsonConvert.DeserializeObject<DTO_CORE_Gig>(gigFromAlert);

            GigALoan_DAL.DB_42039_gigEntities1 context = new GigALoan_DAL.DB_42039_gigEntities1();
            
            CORE_Gigs newgig = new CORE_Gigs
           {
               AlertID = gig.AlertID,
               DateAccepted = gig.DateAccepted,
               StudentID = gig.StudentID,
               ClientComments = gig.ClientComments,
               StudentRating = 0,
               ClientRating = 0
           };

           if(context.CORE_GigAlerts.Where(ga => ga.AlertID == gig.AlertID).Single().Active == true)
           {
               context.CORE_Gigs.Add(newgig);

               CORE_GigAlerts alert = (from a in context.CORE_GigAlerts
                                       where a.AlertID == gig.AlertID
                                       select a).Single();

               alert.Active = false;
               context.SaveChanges();
           }
            string resultString = JsonConvert.SerializeObject(newgig);

            return resultString ;
        }
        // removed Raw SQL query to replace with linq statement
        /*
            string insertString = "IF ((SELECT Active FROM CORE_GigAlerts WHERE AlertID = " + gig.AlertID + ") = 1) " +
                "INSERT INTO CORE_Gigs(AlertID, DateAccepted, StudentID, ClientComments, StudentRating, ClientRating) VALUES(" +
                gig.AlertID + ", " + gig.DateAccepted.ToString("yyyy-mm-dd") + ", " + gig.StudentID + ", '" + gig.ClientComments + "', 0, 0) " +
                "UPDATE CORE_GigAlerts SET Active = 0 FROM CORE_GigAlerts WHERE AlertID = " + gig.AlertID;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=tcp:s05.winhost.com;Database=DB_42039_gig;User ID=DB_42039_gig_user;Password=gigaloan";

            SqlCommand cmd = new SqlCommand(insertString, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            var result = context.CORE_Gigs.Where(g => g.AlertID == gig.AlertID).Single();

            DTO_CORE_Gig gigToBeReturned = new DTO_CORE_Gig
            {
                AlertID = result.AlertID,
                ClientComments = result.ClientComments,
                ClientRating = 0.0,
                DateAccepted = result.DateAccepted,
                DateClosed = Convert.ToDateTime(null),
                GigID = result.GigID,
                StudentComments = "",
                StudentID = result.StudentID,
                StudentRating = 0.0
            };
            */
    }
}
