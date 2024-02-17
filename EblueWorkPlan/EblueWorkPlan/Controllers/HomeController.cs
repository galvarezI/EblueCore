using EblueWorkPlan.Models;
using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace EblueWorkPlan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<User> _UserItems;
        private readonly WorkplandbContext _context;
        public HomeController(ILogger<HomeController> logger, WorkplandbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            ViewData["Logo"] = "../img/uprpng.png";
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
        public IActionResult Signin( UserViewModel _User)
        {
            List<User> Users = new List<User>();
            //var db = new WorkplandbContext();
            string Email = "";
            string Pass = "";
            bool isLogin = false;

            //var  Validacion = (from u in _context.Users
                              
            //                  select u).ToList();


            if (_context.Users.Any(cd => cd.Email == _User.Email.Trim() && cd.Password == _User.Password.Trim()))
            {
                return RedirectToAction("Index", "Projects");
            }
            else
            {
                return View();
            }

            
            //foreach (var item in Validacion)
            //{
            //    if (_User.Email == item.Email && _User.Password == item.Password)
            //    {

            //        Email = item.Email;
            //        Pass = item.Password;
            //        isLogin = true;
            //    }
            //    else
            //    {

            //        isLogin = false;
            //    }
            //}



            //List<User> users = new List<User>();
            //List<User> validateuser = new List<User>();
            //foreach (var item in users)
            //{



            //}


            //User ValidateUser(string _email, string _password)
            //{

            //     user.Where(item => item.Email == _email && item.Password == _password).FirstOrDefault();





            //}

            if (_User.Email == Email && _User.Password == Pass)
            {

               
                return RedirectToAction("Index", "Projects");
            }
            else
            {

                return View();
            }
            //if (isLogin == true)
            //{


            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{

            //    return View();

            //}

        }


        public IActionResult Logout()
        {
            return RedirectToAction("Signin", "Home");
        }
    }
}