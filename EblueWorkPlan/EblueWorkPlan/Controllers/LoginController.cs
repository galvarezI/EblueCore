using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using EblueWorkPlan.Models;
using EblueWorkPlan.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EblueWorkPlan.Controllers
{

    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private List<User> _UserItems;
        private readonly WorkplandbContext _context;

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public LoginController(ILogger<LoginController> logger, WorkplandbContext context, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;

            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        //Login con Microsoft...

        

       

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Signin(string? mensaje = null)
        {
            if (mensaje is not null)
            {
                ViewData["mensaje"] = mensaje;
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ChallengeResult LoginExterno(string proveedor, string? urlRetorno = null)
        {
            var urlRedireccion = Url.Action("RegistrarUsuarioExterno", values: new { urlRetorno });
            var propiedades = signInManager.ConfigureExternalAuthenticationProperties(proveedor, urlRedireccion);
            return new ChallengeResult(proveedor, propiedades);
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegistrarUsuarioExterno(string? urlRetorno = null,
        string? remoteError = null)
        {
            urlRetorno = urlRetorno ?? Url.Content("~/Projects/Index");
            var mensaje = "";

            if (remoteError != null)
            {
                mensaje = $"Error from external provider: {remoteError}";
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                mensaje = "Error loading external login information.";
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var resultadoLoginExterno = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            // Ya la cuenta existe
            if (resultadoLoginExterno.Succeeded)
            {
                return LocalRedirect(urlRetorno);
            }

            string email = "";

            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                email = info.Principal.FindFirstValue(ClaimTypes.Email)!;
            }
            else
            {
                mensaje = "Error leyendo el email del usuario del proveedor.";
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var usuario = new IdentityUser() { Email = email, UserName = info.Principal.Identity.Name };

            var resultadoCrearUsuario = await userManager.CreateAsync(usuario);
            if (!resultadoCrearUsuario.Succeeded)
            {
                mensaje = resultadoCrearUsuario.Errors.First().Description;
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var resultadoAgregarLogin = await userManager.AddLoginAsync(usuario, info);

            if (resultadoAgregarLogin.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: false, info.LoginProvider);
                return LocalRedirect(urlRetorno);
            }
            var user = userManager.GetUserAsync(HttpContext.User);
            mensaje = "Ha ocurrido un error agregando el login.";
            return RedirectToAction("login", routeValues: new { mensaje });
        }

        //Login Normal


        //public IActionResult Signin()
        //{


        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Signin(UserViewModel _User)
        {
            Models.User us = new Models.User();
            List<User> Users = new List<User>();
            //var db = new WorkplandbContext();
            string Email = "";
            string Pass = "";
            bool isLogin = false;

            //var  Validacion = (from u in _context.Users

            //                  select u).ToList();


            if (_context.Users.Any(cd => cd.Email == _User.Email.Trim() && cd.Password == _User.Password.Trim()))
            {

                int id;
                var query1 = (from ui in _context.Users
                              where ui.Email == _User.Email
                              select ui).FirstOrDefault();


                id = query1.UserId;
                //foreach (var use in _context.Users) {
                //    if (_context.Users.Any(cd => cd.Email == _User.Email.Trim() && cd.Password == _User.Password.Trim())) {
                //       id = us.UserId;


                //    }

                //}
                var queryUs = (from u in _context.Users
                               where u.UserId == id
                               select u).FirstOrDefault();
                int rosId = (int)queryUs.RosterId;

                var QueryRosterU = (from r in _context.Rosters
                                    where r.RosterId == rosId
                                    select r).FirstOrDefault();

               

                


                String username = QueryRosterU.RosterName;
                var claims = new List<Claim> {


                    new Claim(ClaimTypes.Name , username),
                    new Claim("Email",queryUs.Email)




                };
                if (queryUs.Roles != null)
                {
                    String[] arrayRole = queryUs.Roles.Split(",");
                    foreach (string rol in arrayRole)
                    {

                        claims.Add(new Claim(ClaimTypes.Role, rol));




                    }
                }

                

                //PENDIENTE PREPARAR ESTRUCTURA DE MÁS DE UN ROL ACA ABAJO....


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));



                return RedirectToAction("Index", "Projects");
            }
            else
            {
                return View();
            }




        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Signin", "Login");
        }
    }
}

