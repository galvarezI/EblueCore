namespace EblueWorkPlan.Models
{
    public class ProjectApprovalHistory
    {
        public int ProjectApprovalHistoryId {  get; set; }

        public int ProjectId { get; set; }

        public string IdentityUserId { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; } 

        public string RoleName { get; set; }

        public ApprovalAction Action { get; set; }

        public string? Comment { get; set; }

        public DateTime ActionDateUtc { get; set; }

        public int ProjectStatusId { get; set; }
        public int? RosterId { get; set; }
        public Roster Roster { get; set; }

        public Project Project { get; set; }



        public enum ApprovalAction {

            Submitted = 1,
            Approved = 2,
            Rejected = 3,
            Commented = 4

        }
    }
}
