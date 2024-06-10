namespace EblueWorkPlan.Models
{
    public class FieldWorkView
    {
        public int id { get; set; }
        public int fieldWorkId { get; set; }
        public string projectId { get; set; }
        public string wfieldwork { get; set; }
        public string area { get; set; }
        public string dateStarted { get; set; }
        public string dateEnded { get; set; }
        public bool inProgress { get; set; }
        public bool toBeInitiated { get; set; }
        public int locaionId { get; set; }

        public int fieldoption { get; set; }
    }
}
