using System.ComponentModel.DataAnnotations.Schema;

namespace EblueWorkPlan.Models.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? RosterId { get; set; }

        public bool? IsEnabled { get; set; }

        public int? RolesId { get; set; }

        [NotMapped]
        public int[] SelectedRolesArray { get; set; }

        public string Roles { get; set; }

        public virtual ICollection<ProjectNote> ProjectNotes { get; set; } = new List<ProjectNote>();

        public virtual Role RolesNavigation { get; set; }

        public virtual Roster Roster { get; set; }


    }
}
