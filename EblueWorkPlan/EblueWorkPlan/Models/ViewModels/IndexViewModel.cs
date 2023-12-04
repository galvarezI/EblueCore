namespace EblueWorkPlan.Models.ViewModels
{
    public class IndexViewModel
    {


        public int projectId { get; set; }
        public int projectNumber { get; set; }




        public string projectTitle { get; set; }

        public string contractNumber { get; set; }
        public string accountNumber { get; set; }


        public int ProjectstatusId { get; set; }
        public string StatusName { get; set; }


        public int RosterId { get; set; }



        public string RosterName { get; set; }
        public string projectPI { get; set; }



        
    }

    //public List<ProjectStatusViewModel> projectstatus { get; set; }
    //    public List<RosterViewModel> rosterPI { get; set; }
    
}
