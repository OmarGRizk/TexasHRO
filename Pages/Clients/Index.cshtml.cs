using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotSQL.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:hroserver.database.windows.net,1433;Initial Catalog=HRODB;Persist Security Info=False;User ID=hrointernadmin;Password=mrlgRTkp23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.created_at = reader.GetDateTime(5).ToString();

                                listClients.Add(clientInfo);
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


    public class ClientInfo
    {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String address;
        public String created_at;
    }

    public class LoginInfo
    {
        public String email3;
        public String password3;
        public String username;
        public DateTime created_at;
    }

    public class Application
    {
        public int id;
        public String submitter1;
        public String firstname1;
        public String lastname1;
        public String phone1;
        public String email1;
        public String insurance;
        public DateTime created_at;
        public String username;

        //public Boolean insurance1_vehicle1;
        //public Boolean insurance1_vehicle2;
        //public Boolean insurance1_vehicle3;

    }

    public class TestInfo
    {
        public String test;
        public Boolean test1;
    }

    public class NewUser
    {
        public String email3;
        public String password3;
        public String username;
        public DateTime created_at;
    }


}
