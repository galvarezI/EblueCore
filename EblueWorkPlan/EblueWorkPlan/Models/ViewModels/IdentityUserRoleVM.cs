using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace EblueWorkPlan.Models.ViewModels
{
    public class IdentityUserRoleVM: IdentityUser
    {

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string role { get; set; }

        [NotMapped]
        public int[] SelectedRolesArray { get; set; }

        public IEnumerable<SelectListItem> UserRoles { get; set; }


        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }


    }
}
