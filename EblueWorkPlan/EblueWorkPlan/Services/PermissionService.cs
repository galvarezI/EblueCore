using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;

namespace EblueWorkPlan.Services
{
    public class PermissionService
    {
        private readonly WorkplandbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PermissionService(
            WorkplandbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // 1. RoleId del usuario Identity actual
        public string? GetCurrentUserRoleId(ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user);

            if (userId == null) return null;

            return _context.UserRoles
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .FirstOrDefault();
        }

        // 2. Permisos del rol (tabla Permissions)
        public Permissions GetPermissionsForRole(string? roleId)
        {
            if (string.IsNullOrEmpty(roleId))
                return new Permissions(); // vacío

            return _context.Permissions
                       .FirstOrDefault(p => p.RoleId == roleId)
                   ?? new Permissions();
        }

        // 3. RosterId asociado al usuario Identity (por Email)
        //public int? GetRosterIdForIdentity(ClaimsPrincipal user)
        //{
        //    var identityUser = _userManager.GetUserAsync(user).Result;
        //    if (identityUser == null) return null;

        //    var email = identityUser.Email;
        //    if (string.IsNullOrEmpty(email)) return null;

        //    return _context.Rosters
        //        .Where(r => r.Email == email)
        //        .Select(r => (int?)r.RosterId)
        //        .FirstOrDefault();
        //}
        public Permissions GetCurrentUserPermissions(ClaimsPrincipal user)
        {
            var roleId = GetCurrentUserRoleId(user);

            if (string.IsNullOrEmpty(roleId))
                return new Permissions(); // todo en false

            return GetPermissionsForRole(roleId) ?? new Permissions();
        }




        public int? GetRosterIdForIdentity(ClaimsPrincipal user)
        {
            var email = _userManager.GetEmailAsync(
                            _userManager.GetUserAsync(user).Result).Result;

            return _context.Rosters
                .Where(r => r.Email == email)
                .Select(r => (int?)r.RosterId)
                .FirstOrDefault();
        }


        // 4. Verifica si el usuario está en SciProjects (Page5)
        public bool HasSciAccess(int projectId, ClaimsPrincipal user)
        {
            var rosterId = GetRosterIdForIdentity(user);
            if (rosterId == null) return false;

            return _context.SciProjects
                .Any(sp => sp.ProjectId == projectId && sp.RosterId == rosterId);
        }

        // 5. Verifica si es PI del proyecto (Project.RosterId)
        public bool IsProjectPI(int projectId, ClaimsPrincipal user)
        {
            var rosterId = GetRosterIdForIdentity(user);
            if (rosterId == null) return false;

            var project = _context.Projects
                .FirstOrDefault(p => p.ProjectId == projectId);

            if (project == null) return false;

            return project.RosterId == rosterId;
        }

        // 6. Regla central de acceso para un proyecto
        public bool CanViewProject(int projectId, ClaimsPrincipal user)
        {
            // 1. Verificar si es PI del proyecto
            if (IsProjectPI(projectId, user))
                return true;

            // 2. Verificar si fue asignado en Page5 (SciProjects)
            if (HasSciAccess(projectId, user))
                return true;

            // 3. En cualquier otro caso, NO TIENE PERMISO
            return false;
        }
    }
}
