using EblueWorkPlan.Models;
using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AspNetCore.Reporting;

namespace EblueWorkPlan.Controllers
{
    [Authorize]
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






        public IActionResult Print()
        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var filepath = @"C:\\Users\\GGJEANZS\\Documents\\Projects.rdl";
            var local = new LocalReport(filepath);
            var rpt = local.Execute(RenderType.Pdf );

            return File(rpt.MainStream, "application/pdf");
        }


        //public IActionResult Signin()
        //{


        //    return View();
        //}

        //[HttpPost]
        //public async Task <IActionResult> Signin( UserViewModel _User)
        //{
        //    Models.User us = new Models.User();
        //    List<User> Users = new List<User>();
        //    //var db = new WorkplandbContext();
        //    string Email = "";
        //    string Pass = "";
        //    bool isLogin = false;

        //    //var  Validacion = (from u in _context.Users
                              
        //    //                  select u).ToList();


        //    if (_context.Users.Any(cd => cd.Email == _User.Email.Trim() && cd.Password == _User.Password.Trim()))
        //    {

        //        int id;
        //        var query1 = (from ui in _context.Users
        //                     where ui.Email == _User.Email
        //                     select ui).FirstOrDefault();


        //        id = query1.UserId;
        //        //foreach (var use in _context.Users) {
        //        //    if (_context.Users.Any(cd => cd.Email == _User.Email.Trim() && cd.Password == _User.Password.Trim())) {
        //        //       id = us.UserId;


        //        //    }

        //        //}
        //        var queryUs = (from u in _context.Users
        //                      where u.UserId == id
        //                      select u).FirstOrDefault();
        //        int rosId = (int)queryUs.RosterId;

        //        var QueryRosterU = (from r in _context.Rosters
        //                          where r.RosterId == rosId
        //                          select r).FirstOrDefault();

        //        String username = QueryRosterU.RosterName;
        //        var claims = new List<Claim> { 
                
                
        //            new Claim(ClaimTypes.Name , username),
        //            new Claim("Email",queryUs.Email)
                    
                
                
                
        //        };

        //        //PENDIENTE PREPARAR ESTRUCTURA DE MÁS DE UN ROL ACA ABAJO....


        //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));



        //        return RedirectToAction("Index", "Projects");
        //    }
        //    else
        //    {
        //        return View();
        //    }

            
         

        //}


        //public async Task <IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Signin", "Home");
        //}
    }
}