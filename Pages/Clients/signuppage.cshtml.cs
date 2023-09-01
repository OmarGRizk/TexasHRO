//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Data.SqlClient;

//namespace DotSQL.Pages.Clients
//{
//    public class SignupModel : PageModel
//    {
//        public NewUser newuser= new NewUser();
//        public String errorMessage = "";
//        public String successMessage = "";
//        public void OnGet()
//        {
//        }

//        public void OnPost()
//        {
//            newuser.email3 = Request.Form["email3"];
//            newuser.password3 = Request.Form["password3"];
           

//            if (newuser.email3.Length == 0 || newuser.password3.Length == 0 )
                
//            {
//                errorMessage = "All the fields are required";
//                return;
//            }

//            //save the new client into the database
//            try
//            {
//                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    String sql = "INSERT INTO newuser " +
//                                 "(email3, password3) VALUES " +
//                                 "(@email3, @password3);";

//                    using (SqlCommand command = new SqlCommand(sql, connection))
//                    {
//                        command.Parameters.AddWithValue("@email3", newuser.email3);
//                        command.Parameters.AddWithValue("@password3", newuser.password3);

//                        command.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                errorMessage = ex.Message;
//                return;
//            }

//            newuser.email3 = ""; 
//            successMessage = "New Client Added Correctly";

//            Response.Redirect("/Clients/Application");
//        }
//    }
//}
