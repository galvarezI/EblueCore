using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

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

            var roles = _context.Roles.ToList();
            _roleItems = new List<SelectListItem>();
            foreach (var item in roles)
            {
                _roleItems.Add(new SelectListItem
                {
                    Text = item.Rname,
                    Value = item.RolesId.ToString()
                });
                
            }
            ViewBag.rolesItems = _roleItems;
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("UserId,Email,Password,RosterId,IsEnabled")]*/UserVM Users )
        {
            if (ModelState.IsValid)
            {
                string[] roles = new string[Users.SelectedRolesArray.Length];
                int index = 0;
                foreach (var items in Users.SelectedRolesArray) {
                    var consult = (from u in _context.Roles
                                   where u.RolesId == items
                                   select u).FirstOrDefault();

                    roles[index] = consult.Rname;
                    index++;
                }
                string rolesString = string.Join(",", roles);

                User users = new User() { 
                    Email = Users.Email,
                    Password = Users.Password,
                    RosterId = Users.RosterId,
                    RolesId = Users.RolesId,
                    IsEnabled = Users.IsEnabled,
                    Roles = rolesString,
                
                
                
                
                
                };

                _context.Add(Users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", Users.RosterId);
            return View(Users);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)


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
            ViewBag.rosterItems = _rosterItems;

            var roles = _context.Roles.ToList();
            _roleItems = new List<SelectListItem>();
            foreach (var item in roles)
            {
                _roleItems.Add(new SelectListItem
                {
                    Text = item.Rname,
                    Value = item.RolesId.ToString()
                });

            }
            ViewBag.rolesItems = _roleItems;

            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            UserVM UserVm = new UserVM()
            {
                UserId = user.UserId,
                RosterId= user.RosterId,
                Email= user.Email,
                Password= user.Password,
                Roles= user.Roles,
                RolesId= user.RolesId,




            };

            if (user == null)
            {
                return NotFound();
            }
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", user.RosterId);
            return View(UserVm);
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
        public async Task<IActionResult> Delete(int? id)
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

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'WorkplandbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
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



        public async Task<IActionResult> UserInfo() {

            


            IdentityUserRoleVM model = new IdentityUserRoleVM() {

                Users = userManager.Users.ToList(),
                Roles =  roleManager.Roles.ToList()

            };
            
            return View(model);
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
    }
}
