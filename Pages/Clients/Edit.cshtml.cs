using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotSQL.Pages.Clients
{
    public class EditModel : PageModel
    {
        public Application applicantInfo = new Application();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM application3 WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //applicantInfo.id = reader.GetInt32(0);
                                //applicantInfo.username = reader.GetString(1);
                                //applicantInfo.submitter1 = reader.GetString(2);
                                //applicantInfo.firstname1 = reader.GetString(3);
                                //applicantInfo.lastname1 = reader.GetString(4);
                                //applicantInfo.phone1 = reader.GetString(5);
                                //applicantInfo.email1 = reader.GetString(6);
                                //applicantInfo.insurance = reader.GetString(7);

                                applicantInfo.id = reader.GetInt32(0);
                                applicantInfo.username = reader.GetString(1);
                                applicantInfo.submitter1 = reader.IsDBNull(2) ? null : reader.GetString(2);
                                applicantInfo.firstname1 = reader.IsDBNull(3) ? null : reader.GetString(3);
                                applicantInfo.lastname1 = reader.IsDBNull(4) ? null : reader.GetString(4);
                                applicantInfo.phone1 = reader.IsDBNull(5) ? null : reader.GetString(5);
                                applicantInfo.email1 = reader.IsDBNull(6) ? null : reader.GetString(6);
                                applicantInfo.insurance = reader.IsDBNull(7) ? null : reader.GetString(7);
                                applicantInfo.created_at = reader.GetDateTime(8);


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            applicantInfo.username = Request.Form["username"];
            applicantInfo.submitter1 = Request.Form["submitter1"];
            applicantInfo.firstname1 = Request.Form["firstname1"];
            applicantInfo.lastname1 = Request.Form["lastname1"];
            applicantInfo.phone1 = Request.Form["phone1"];
            applicantInfo.email1 = Request.Form["email1"];
            applicantInfo.insurance = Request.Form["insurance"];



            if (applicantInfo.firstname1.Length >= 50)
            {
                errorMessage = "All fields are required";
                return;
            }

            try
            {
                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //String sql = "UPDATE applicant3 " +
                    //             "SET username=@username, submitter1=@submitter1, firstname1=@firstname1, lastname1=@lastname1,phone1=@phone1,  email1=@email1, insurance=@insurance" +
                    //             "WHERE id=@id";

                    String sql = "UPDATE applicant3 " +
                                "SET username=@username, submitter1=@submitter1, firstname1=@firstname1, lastname1=@lastname1, phone1=@phone1, email1=@email1, insurance=@insurance " +
                                "WHERE id=@id";



                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //command.Parameters.AddWithValue("@username", applicantInfo.username);
                        //command.Parameters.AddWithValue("@submitter1", applicantInfo.submitter1);
                        //command.Parameters.AddWithValue("@firstname1", applicantInfo.firstname1);
                        //command.Parameters.AddWithValue("@lastname1", applicantInfo.lastname1);
                        //command.Parameters.AddWithValue("@phone1", applicantInfo.phone1);
                        //command.Parameters.AddWithValue("@email1", applicantInfo.email1);
                        //command.Parameters.AddWithValue("@insurance", applicantInfo.insurance);

                        //command.ExecuteNonQuery();

                        command.Parameters.AddWithValue("@username", applicantInfo.username);
                        command.Parameters.AddWithValue("@submitter1", applicantInfo.submitter1);
                        command.Parameters.AddWithValue("@firstname1", applicantInfo.firstname1);
                        command.Parameters.AddWithValue("@lastname1", applicantInfo.lastname1);
                        command.Parameters.AddWithValue("@phone1", applicantInfo.phone1);
                        command.Parameters.AddWithValue("@email1", applicantInfo.email1);
                        command.Parameters.AddWithValue("@insurance", applicantInfo.insurance);
                        command.Parameters.AddWithValue("@id", applicantInfo.id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update was successful
                            Console.WriteLine("Update successful. Rows affected: " + rowsAffected);
                        }
                   
                        else
                        {
                        // Update failed
                        Console.WriteLine("No rows were updated or ID doesn't exist.");
                    }




                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage=ex.Message;
                return;
            }

            Response.Redirect("/Clients/Index");
        }
    }
}
