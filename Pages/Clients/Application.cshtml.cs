using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotSQL.Pages.Clients
{
    public class ApplicationModel : PageModel
    {
        public Application applicationInfo = new Application();

        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            applicationInfo.username = Request.Form["username"];
            applicationInfo.submitter1 = Request.Form["submitter1"];
            applicationInfo.firstname1 = Request.Form["firstname1"];
            applicationInfo.lastname1 = Request.Form["lastname1"];
            applicationInfo.phone1 = Request.Form["phone1"];
            applicationInfo.email1 = Request.Form["email1"];
            applicationInfo.insurance = Request.Form["insurance"];


            //applicationInfo.insurance_bike = Request.Form["insurance_bike"].Count > 0;
            //applicationInfo.insurance_car = Request.Form["insurance_car"].Count > 0;
            //applicationInfo.insurance_boat = Request.Form["insurance_boat"].Count > 0;

            //applicationInfo.insurance1_vehicle1 = !string.IsNullOrEmpty(Request.Form["insurance1_vehicle1"]);
            //applicationInfo.insurance1_vehicle2 = !string.IsNullOrEmpty(Request.Form["insurance1_vehicle2"]);
            //applicationInfo.insurance1_vehicle3 = !string.IsNullOrEmpty(Request.Form["insurance1_vehicle3"]);


            if (applicationInfo.firstname1.Length == 0 ||
                applicationInfo.lastname1.Length == 0 || applicationInfo.phone1.Length == 0 ||
                applicationInfo.email1.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }



            //save into the database
            try
            {
                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
       

                    connection.Open();
                    String sql = "INSERT INTO application3 " +
                                 "(username,submitter1,firstname1, lastname1, phone1, email1, insurance ) VALUES " +
                                 "(@username,@submitter1, @firstname1, @lastname1, @phone1, @email1, @insurance);";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //command.Parameters.AddWithValue("@username", applicationInfo.username);
                        command.Parameters.AddWithValue("@username", applicationInfo.username);
                        command.Parameters.AddWithValue("@submitter1", applicationInfo.submitter1);
                        command.Parameters.AddWithValue("@firstname1", applicationInfo.firstname1);
                        command.Parameters.AddWithValue("@lastname1", applicationInfo.lastname1);
                        command.Parameters.AddWithValue("@phone1", applicationInfo.phone1);
                        command.Parameters.AddWithValue("@email1", applicationInfo.email1);
                        command.Parameters.AddWithValue("@insurance", applicationInfo.insurance);



                        //command.Parameters.AddWithValue("@insurance1_vehicle1", applicationInfo.insurance1_vehicle1);
                        //command.Parameters.AddWithValue("@insurance1_vehicle2", applicationInfo.insurance1_vehicle2);
                        //command.Parameters.AddWithValue("@insurance1_vehicle3", applicationInfo.insurance1_vehicle3);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            applicationInfo.submitter1 = ""; applicationInfo.firstname1 = ""; applicationInfo.lastname1 = ""; applicationInfo.phone1 = ""; applicationInfo.email1 = ""; 
            successMessage = "New Client Added Correctly";

            Response.Redirect("/Clients/Confirmation");
        }
    }
}
