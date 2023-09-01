using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DotSQL.Pages.Clients
{
    public class ConfirmationModel : PageModel
    {
        public Application applicationInfo = new Application();

        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            
        }
    }
}
