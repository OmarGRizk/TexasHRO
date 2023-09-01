using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotSQL.Pages.Clients
{
    public class TestModel : PageModel
    {
        public TestInfo testInfo = new TestInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            testInfo.test = Request.Form["test"];
            testInfo.test1 = !string.IsNullOrEmpty(Request.Form["test1"]);
            //testInfo.test1 = Request.Form["test1"];
            //bool testValue = (Request.Form["test1"]);



            if (testInfo.test1 == false)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save the new client into the database
            try
            {
                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO test " +
                                 "(test,test1) VALUES " +
                                 "(@test,@test1);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@test1", testInfo.test1);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            testInfo.test = "";
            successMessage = "New Client Added Correctly";

            Response.Redirect("/Clients/Index");
        }
    }
}
