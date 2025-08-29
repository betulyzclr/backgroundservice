namespace backgroundservice.Models
{
    public class JobViewModel
    {
        public int ID { get; set; }
        public string JobName { get; set; }
        public string JobKey { get; set; }
        public string JobDescription { get; set; }

        public string Endpoint { get; set; }
        public string Schedule { get; set; }
        public bool IsActive { get; set; }
        public int RetryCount { get; set; }
        public int RetryMinutes { get; set; }
        public DateTime? LastRunDate { get; set; }
        public DateTime? LastSuccessDate { get; set; }
        public DateTime? LastErrorDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? LastCreatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
