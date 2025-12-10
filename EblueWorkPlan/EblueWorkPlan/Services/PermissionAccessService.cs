using EblueWorkPlan.Models;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Services
{
    public class PermissionAccessService
    {
        private readonly WorkplandbContext _context;
        private readonly PermissionService _permissionService;

        public PermissionAccessService(
            WorkplandbContext context,
            PermissionService permissionService)
        {
            _context = context;
            _permissionService = permissionService;
        }

        // Usuario puede ver este proyecto? (wrapper a PermissionService)
        public bool CanViewProject(int projectId, ClaimsPrincipal user)
        {
            return _permissionService.CanViewProject(projectId, user);
        }

        // Devuelve SOLO los proyectos visibles para el usuario
        public IQueryable<Project> FilterProjectsForUser(ClaimsPrincipal user)
        {
            var roleId = _permissionService.GetCurrentUserRoleId(user);
            var perms = _permissionService.GetPermissionsForRole(roleId);

            // Si tiene permiso global, no filtramos
            if (perms.PuedeVer)
                return _context.Projects;

            var rosterId = _permissionService.GetRosterIdForIdentity(user);
            if (rosterId == null)
                return Enumerable.Empty<Project>().AsQueryable();

            // 1) Proyectos donde es PI
            var asPI = _context.Projects.Where(p => p.RosterId == rosterId);

            // 2) Proyectos donde aparece en SciProjects (Page5)
            var asSciRole = _context.SciProjects
                .Where(sp => sp.RosterId == rosterId)
                .Include(sp => sp.Project)
                .Select(sp => sp.Project);

            return asPI.Union(asSciRole).Distinct();
        }
    }
}
