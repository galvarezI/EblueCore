using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using EblueWorkPlan.Models;
using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class UserController : Controller
    {
        private readonly WorkplandbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private List<SelectListItem> _rosterItems;
        private List<SelectListItem> _departmentsItems;
        private List<SelectListItem> _porganizationsItems;

        private List<SelectListItem> _fundtypeItems;
        private List<SelectListItem> _roleItems;
        private List<SelectListItem> _fiscalYearItems;
        private List<SelectListItem> _substationItems;
        private List<SelectListItem> _programAreaItems;
        private List<SelectListItem> _locationsItems;
        private List<SelectListItem> _userItems;
        public UserController(WorkplandbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.Users.Include(u => u.Roster);


            return View(await workplandbContext.ToListAsync());


        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Roster)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }

            var roles = roleManager.Roles.ToList();
            var _roleItems = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            }).ToList();
            ViewBag.rolesItems = _roleItems;
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        #region depreciated
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(/*[Bind("UserId,Email,Password,RosterId,IsEnabled")]*/UserVM Users )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string[] roles = new string[Users.SelectedRolesArray.Length];
        //        int index = 0;
        //        foreach (var items in Users.SelectedRolesArray) {
        //            var consult = (from u in _context.Roles
        //                           where u.RolesId == items
        //                           select u).FirstOrDefault();

        //            roles[index] = consult.Rname;
        //            index++;
        //        }
        //        string rolesString = string.Join(",", roles);

        //        User users = new User() { 
        //            Email = Users.Email,
        //            Password = Users.Password,
        //            RosterId = Users.RosterId,
        //            RolesId = Users.RolesId,
        //            IsEnabled = Users.IsEnabled,
        //            Roles = rolesString,





        //        };

        //        _context.Add(Users);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", Users.RosterId);
        //    return View(Users);
        //}

        //// GET: User/Edit/5
        //public async Task<IActionResult> Edit(int? id)


        //{

        //    var rosters = _context.Rosters.ToList();
        //    _rosterItems = new List<SelectListItem>();
        //    foreach (var item in rosters)
        //    {
        //        _rosterItems.Add(new SelectListItem
        //        {
        //            Text = item.RosterName,
        //            Value = item.RosterId.ToString()
        //        });
        //    }
        //    ViewBag.rosterItems = _rosterItems;

        //    var roles = _context.Roles.ToList();
        //    _roleItems = new List<SelectListItem>();
        //    foreach (var item in roles)
        //    {
        //        _roleItems.Add(new SelectListItem
        //        {
        //            Text = item.Rname,
        //            Value = item.RolesId.ToString()
        //        });

        //    }
        //    ViewBag.rolesItems = _roleItems;

        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users.FindAsync(id);
        //    UserVM UserVm = new UserVM()
        //    {
        //        UserId = user.UserId,
        //        RosterId= user.RosterId,
        //        Email= user.Email,
        //        Password= user.Password,
        //        Roles= user.Roles,
        //        RolesId= user.RolesId,




        //    };

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", user.RosterId);
        //    return View(UserVm);
        //}
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserVM model)
        {
            



            if (ModelState.IsValid)
            {

                //metodo para traer nombre del roster

                var consult = (from u in _context.Rosters
                               where u.RosterId == model.RosterId
                               select u).FirstOrDefault();

                var user = new IdentityUser
                {
                    UserName = consult.RosterName,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var emailExists = await userManager.FindByEmailAsync(model.Email);
                if (emailExists != null)
                {
                    ModelState.AddModelError("Email", "Ya existe un usuario con este correo.");
                    return View(model);
                }

                // Validar duplicado de UserName basado en RosterName
                var consulta = await _context.Rosters.FindAsync(model.RosterId);
                var rosterName = consult.RosterName;

                var usernameExists = await userManager.FindByNameAsync(rosterName);
                if (usernameExists != null)
                {
                    ModelState.AddModelError("RosterId", "Ya existe un usuario asignado a este roster.");
                    return View(model);
                }






                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    

                    // Guardar información adicional como RosterId en una tabla auxiliar
                    var customUser = new Models.User
                    {
                        Email = model.Email,
                        Password = model.Password, // ⚠️ Puedes omitir guardar el password plano por seguridad
                        RosterId = model.RosterId,
                        //IsEnabled = model.IsEnabled,
                        //Roles = string.Join(",", model.SelectedRolesArray),
                        //RolesId = 0 // si aplica, o elimina este campo si ya no se usa
                    };

                    _context.Users.Add(customUser);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("UserInfo","User");
                }

                // Mostrar errores de Identity
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterName", model.RosterId);
            return View(model);
        }






        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Email,Password,RosterId,IsEnabled,SelectedRolesArray")] UserVM user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {




                try
                {
                    string[] roles = new string[user.SelectedRolesArray.Length];
                    int index = 0;
                    foreach (var items in user.SelectedRolesArray)
                    {
                        var consult = (from u in _context.Roles
                                       where u.RolesId == items
                                       select u).FirstOrDefault();

                        roles[index] = consult.Rname;
                        index++;
                    }
                    string rolesString = string.Join(",", roles);




                    var query = (from u in _context.Users
                                where u.UserId == user.UserId
                                select u).FirstOrDefault();

                    query.Email= user.Email;
                    query.Password= user.Password;
                    query.RolesId= user.RolesId;
                    query.RosterId= user.RosterId;
                    query.Roles = rolesString;













                    _context.Update(query);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", user.RosterId);
            return View(user);
        }

        // GET: User/Delete/5
        //public async Task<IActionResult> Delete(string UserId,  int? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .Include(u => u.Roster)
        //        .FirstOrDefaultAsync(m => m.UserId == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            // Buscar el usuario de Identity
            var identityUser = await userManager.FindByIdAsync(id);
            if (identityUser == null)
                return NotFound();

            // Buscar el usuario custom usando el email
            var customUser = await _context.Users
                .Include(u => u.Roster)
                .FirstOrDefaultAsync(u => u.Email == identityUser.Email);

            return View(customUser);
        }






        #region depreciated
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    // Buscar registro en tu tabla Users
        //    var customUser = await _context.Users.FindAsync(id);
        //    if (customUser == null)
        //        return NotFound();

        //    // Buscar el IdentityUser por email
        //    var identityUser = await userManager.FindByEmailAsync(customUser.Email);

        //    // 1. Eliminar de IdentityUser (AspNetUsers, AspNetUserRoles, Claims, Tokens)
        //    if (identityUser != null)
        //    {
        //        var result = await userManager.DeleteAsync(identityUser);

        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", "No se pudo eliminar el usuario de Identity.");
        //            return View(customUser);
        //        }
        //    }

        //    // 2. Eliminar registro en tabla Users
        //    _context.Users.Remove(customUser);
        //    await _context.SaveChangesAsync();

        //    TempData["Success"] = "Usuario eliminado correctamente.";
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            // 1. Buscar IdentityUser
            var identityUser = await userManager.FindByIdAsync(id);
            if (identityUser == null)
                return NotFound();

            // 2. Buscar CustomUser asociado (por Email)
            var customUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == identityUser.Email);

            // A. Eliminar roles del IdentityUser
            var roles = await userManager.GetRolesAsync(identityUser);
            foreach (var role in roles)
                await userManager.RemoveFromRoleAsync(identityUser, role);

            // B. Eliminar claims
            var claims = await userManager.GetClaimsAsync(identityUser);
            foreach (var claim in claims)
                await userManager.RemoveClaimAsync(identityUser, claim);

            // C. Eliminar tokens
            await userManager.RemoveAuthenticationTokenAsync(identityUser, "Default", "RefreshToken");

            // D. Eliminar usuario Identity
            var result = await userManager.DeleteAsync(identityUser);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Error eliminando el usuario de Identity.");
                return View(customUser);
            }

            // E. Eliminar usuario custom (si existe)
            if (customUser != null)
            {
                _context.Users.Remove(customUser);
                await _context.SaveChangesAsync();
            }

            TempData["Success"] = "Usuario eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }









        public async Task<IActionResult> UserIdentity() {

            var users = userManager.Users.ToList();

            return View();
        }


        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }



        public async Task<IActionResult> UserInfo()
        {




            var users = await userManager.Users.ToListAsync();

            var userRolesList = new List<IdentityUserRoleVM>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);

                userRolesList.Add(new IdentityUserRoleVM
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    UserRole = roles.ToList()
                });


                //IdentityUserRoleVM model = new IdentityUserRoleVM()
                //{

                //    Users = userManager.Users.ToList(),
                //    UserRole = await userManager.GetRolesAsync(usuarios)
                //    Roles = roleManager.Roles.ToList()

                //};


                
            }
            return View(userRolesList);
        }

        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> AddRole(string Id ) {
            var user = await userManager.FindByIdAsync(Id);
            
            IdentityUserRoleVM model = new IdentityUserRoleVM()
            {
                Id= Id,
                Username = user.UserName,
                Roles = roleManager.Roles.ToList(),
                UserRoles = roleManager.Roles.Select(x => new SelectListItem (x.Name, x.Id ))
                
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddRole(string Id, IdentityUserRoleVM identityUser) {

            var user = await userManager.FindByIdAsync(Id);
            var roleQuery = (from r in roleManager.Roles
                            where r.Id == identityUser.role
                            select r).FirstOrDefault();

            identityUser.role = roleQuery.Name;
            await userManager.AddToRoleAsync(user, identityUser.role);


            return RedirectToAction("UserInfo");
        }


        [HttpGet]
        public async Task<IActionResult> UserRoles(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("El ID del usuario es requerido.");

            var user = await userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("Usuario no encontrado.");

            var roles = await userManager.GetRolesAsync(user);

            var model = new IdentityUserRoleVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                UserRole = roles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUserRole(string userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var result = await userManager.RemoveFromRoleAsync(user, roleName);

            if (!result.Succeeded)
            {
                TempData["Error"] = "No se pudo eliminar el rol.";
                return RedirectToAction(nameof(UserRoles), new { id = userId });
            }

            TempData["Success"] = $"El rol '{roleName}' fue eliminado.";
            return RedirectToAction(nameof(UserInfo), new { id = userId });
        }




    }
}
