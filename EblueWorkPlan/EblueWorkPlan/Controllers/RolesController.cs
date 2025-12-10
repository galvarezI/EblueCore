using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class RolesController : Controller
    {
        private readonly WorkplandbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(WorkplandbContext context, UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.Roles;
            return View(await workplandbContext.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
               
                .FirstOrDefaultAsync(m => m.RolesId == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");

            //ViewBags

            ViewBag.RosterItem = new SelectList(_context.Rosters, "RosterId", "RosterName");

            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RolesId,Rname,IsResearchDirector,IsExecutiveOfficer,IsAdministrativeOfficer,IsExternalResources,RosterId")] Role role)
        {
            if (ModelState.IsValid)
            {
                await roleManager.CreateAsync(new IdentityRole(role.Rname));
                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");



            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RolesId,Rname,IsResearchDirector,IsExecutiveOfficer,IsAdministrativeOfficer,IsExternalResources,RosterId")] Role role)
        {
            if (id != role.RolesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var verificarRol = roleManager.RoleExistsAsync(role.Rname);

                    if (await verificarRol == false)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role.Rname));

                    }
                    
                    _context.Update(role);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.RolesId))
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
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                
                .FirstOrDefaultAsync(m => m.RolesId == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'WorkplandbContext.Roles'  is null.");
            }
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.RolesId == id)).GetValueOrDefault();
        }


        [HttpGet]
        //public async Task<IActionResult> EditPermissions(int id, string roleId)
        //{
        //    if (string.IsNullOrEmpty(roleId))
        //        return BadRequest("El ID del rol es requerido.");

        //    var role = await roleManager.FindByIdAsync(roleId);
        //    if (role == null)
        //        return NotFound("Rol no encontrado.");

        //    // Buscar permisos existentes
        //    var permisos = await _context.Permissions
        //        .Where(p => p.RoleId == roleId)
        //        .ToListAsync();

        //    // Si no hay permisos definidos, crear una plantilla base
        //    if (!permisos.Any())
        //    {
        //        permisos.Add(new Permissions
        //        {
        //            RoleId = roleId,
        //            PuedeVer = true
        //        });
        //    }

        //    ViewBag.RoleName = role.Name;
        //    return View(permisos);
        //}

        [HttpGet]
        public async Task<IActionResult> EditPermissions(int id)
        {
            // Buscar el rol en tu base local (tabla Role: RolesId, Rname, etc.)
            var roleLocal = await _context.Roles
                .FirstOrDefaultAsync(r => r.RolesId == id);

            if (roleLocal == null)
                return NotFound("El rol no existe en la base de datos interna.");

            // Buscar el rol REAL de Identity por nombre
            var roleIdentity = await roleManager.Roles
                .FirstOrDefaultAsync(r => r.Name == roleLocal.Rname);

            if (roleIdentity == null)
                return NotFound("El rol no existe en AspNetRoles.");

            string roleId = roleIdentity.Id;

            // Buscar permisos por RoleId (AspNet Identity)
            var permisos = await _context.Permissions
                .Where(p => p.RoleId == roleId)
                .ToListAsync();

            if (!permisos.Any())
            {
                permisos.Add(new Permissions
                {
                    RoleId = roleId,
                    PuedeVer = true
                });
            }

            ViewBag.RoleName = roleLocal.Rname;
            ViewBag.RoleIdentityId = roleId;

            return View(permisos);
        }








        // ---------------------------------------------------------
        // POST: Guardar o actualizar permisos de un rol
        // ---------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPermissions(List<Permissions> permisos)
        {
            if (permisos == null || !permisos.Any())
                return BadRequest("No se enviaron permisos válidos.");

            foreach (var permiso in permisos)
            {
                var existente = await _context.Permissions
                    .FirstOrDefaultAsync(p => p.RoleId == permiso.RoleId);

                if (existente != null)
                {
                    //  Actualizar los permisos existentes
                    existente.PuedeCrear = permiso.PuedeCrear;
                    existente.PuedeEditar = permiso.PuedeEditar;
                    existente.PuedeEliminar = permiso.PuedeEliminar;
                    existente.PuedeVer = permiso.PuedeVer;
                    existente.PuedeAprobar = permiso.PuedeAprobar;
                    existente.PuedeRechazar = permiso.PuedeRechazar;
                    existente.PuedeComentar = permiso.PuedeComentar;
                    existente.PuedeAsignarRoles = permiso.PuedeAsignarRoles;
                    existente.PuedeAdministrarTodo = permiso.PuedeAdministrarTodo;
                    existente.PuedeReenviar = permiso.PuedeReenviar;
                    existente.PuedeModificarTrasRechazo = permiso.PuedeModificarTrasRechazo;

                    _context.Permissions.Update(existente);
                }
                else
                {
                    //  Crear un nuevo registro de permisos
                    _context.Permissions.Add(permiso);
                }
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Permisos actualizados correctamente.";

            return RedirectToAction(nameof(Index));






        }

        }
}
