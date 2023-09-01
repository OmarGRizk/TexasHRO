using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotSQL.Pages.Clients
{
    public class hro_database_1 : PageModel
    {

        //Create a list of appliocants
        public List<Application> listApplications = new List<Application>();
        public List<NewUser> listnewUsers = new List<NewUser>();

        public void OnGet()
        {
            OnGetApplications();
            OnGetNewUsers();
        }



        public void OnGetApplications()
        {
            try
            {
                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM application3";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Application applicationInfo = new Application();
                                applicationInfo.id = reader.GetInt32(0);
                                applicationInfo.submitter1 = reader.GetString(1);
                                applicationInfo.firstname1 = reader.GetString(2);
                                applicationInfo.lastname1 = reader.GetString(3);
                                applicationInfo.phone1 = reader.GetString(4);
                                applicationInfo.email1 = reader.GetString(5);
                                applicationInfo.insurance = reader.GetString(6);
                                applicationInfo.created_at = reader.GetDateTime(7);
                                applicationInfo.username = reader.GetString(8);

                                listApplications.Add(applicationInfo);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
        public void OnGetNewUsers()
        {
            try
            {
                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM newuser1";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NewUser newuserInfo = new NewUser();
                                newuserInfo.username = reader.GetString(0);
                                newuserInfo.email3 = reader.GetString(1);
                                newuserInfo.password3 = reader.GetString(2);
                                newuserInfo.created_at = reader.GetDateTime(3);
                                

                                listnewUsers.Add(newuserInfo);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

    }





}
