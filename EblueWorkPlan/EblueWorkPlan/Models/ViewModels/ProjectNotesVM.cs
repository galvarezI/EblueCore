namespace EblueWorkPlan.Models.ViewModels
{
    public class ProjectNotesVM
    {
        public int ProjectNotesId { get; set; }

        public string Comment { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? UserId { get; set; }

        public int? ProjectId { get; set; }

        public int? RosterId { get; set; }

        public string Username { get; set; }

        public string DepartmentDirectorComments { get; set; }

        public string DeanComments { get; set; }

        public string DepartmentDirector { get; set; }

        public int commentId { get; set; }

        public virtual Project Project { get; set; }

        public virtual Roster Roster { get; set; }

        public virtual User User { get; set; }
    




   
    }
}
