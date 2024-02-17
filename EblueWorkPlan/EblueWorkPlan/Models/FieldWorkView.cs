namespace EblueWorkPlan.Models
{
    public class FieldWorkView
    {
        public int fieldWorkId { get; set; }
        public string projectId { get; set; }
        public string wfieldwork { get; set; }
        public string area { get; set; }
        public string dateStarted { get; set; }
        public string dateEnded { get; set; }
        public bool inProgress { get; set; }
        public bool toBeInitiated { get; set; }
        public int locaionId { get; set; }
    }
}
