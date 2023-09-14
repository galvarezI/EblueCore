using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Routing;

namespace EblueWorkPlan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<User> _UserItems;
        private readonly WorkplandbContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Signin()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Signin(User user, UserViewModel _User)
        {

           
            //List<User> users = new List<User>();
            //List<User> validateuser = new List<User>();
            //foreach (var item in users)
            //{
                


            //}


            //User ValidateUser(string _email, string _password)
            //{

            //     user.Where(item => item.Email == _email && item.Password == _password).FirstOrDefault();





            //}

            //var _user = ValidateUser(user.Email, user.Password);

            if (_User.Email == user.Email && _User.Password == user.Password)
            {


                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();

            }

        }
    }
}