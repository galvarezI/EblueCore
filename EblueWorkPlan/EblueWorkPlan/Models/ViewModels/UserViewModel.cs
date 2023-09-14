namespace EblueWorkPlan.Models.ViewModels
{
    public class UserViewModel
    {
        public List<User> UserList() { 
            
            return new List<User>();
        
        
        }



        public User ValidateUser(string _email, string _password) {

            return UserList().Where(item => item.Email == _email && item.Password == _password).FirstOrDefault();
        
        
        
        
        
        }
    }
}
