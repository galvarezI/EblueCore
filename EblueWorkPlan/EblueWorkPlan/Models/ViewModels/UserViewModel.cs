using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace EblueWorkPlan.Models.ViewModels
{
    public class UserViewModel
    {
        public int userId { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
    

      
    
}
