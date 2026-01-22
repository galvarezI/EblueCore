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
        //public IQueryable<Project> FilterProjectsForUser(ClaimsPrincipal user)
        //{
        //    var rosterId = _permissionService.GetRosterIdForIdentity(user);

        //    // Usuario sin roster → no puede ver proyectos
        //    if (rosterId == null)
        //        return _context.Projects.Where(p => false);

        //    // 1. Proyectos donde es PI
        //    var asPI = _context.Projects
        //        .Where(p => p.RosterId == rosterId);

        //    // 2. Proyectos donde aparece en Page5
        //    var asSci = _context.SciProjects
        //        .Where(sp => sp.RosterId == rosterId)
        //        .Select(sp => sp.Project);

        //    // Unión final
        //    return asPI.Union(asSci).Distinct();
        //}

        public IQueryable<Project> FilterProjectsForUser(ClaimsPrincipal user)
        {
            var rosterId = _permissionService.GetRosterIdForIdentity(user);

            if (rosterId == null)
                return _context.Projects.Where(p => false);

            return _context.Projects
                .Where(p =>
                    p.RosterId == rosterId ||
                    p.SciProjects.Any(sp => sp.RosterId == rosterId)
                );
        }



    }
}
