namespace GovJobsWebAPI.Models
{
    public class MatchedObjectDescriptor
    {
        public string PositionID { get; set; }
        public string PositionTitle { get; set; }
        public string PositionURI { get; set; }
        public List<string> ApplyURI { get; set; } = new List<string>();
        public string PositionLocationDisplay { get; set; }
        public List<PositionLocation> PositionLocation { get; set; } = new List<PositionLocation>();
        public string OrganizationName { get; set; }
        public string DepartmentName { get; set; }
        public string SubAgency { get; set; }
        public List<JobCategory> JobCategory { get; set; } = new List<JobCategory>();
        public List<JobGrade> JobGrade { get; set; } = new List<JobGrade>();
        public List<PositionSchedule> PositionSchedule { get; set; } = new List<PositionSchedule>();
        public List<PositionOfferingType> PositionOfferingType { get; set; } = new List<PositionOfferingType>();
        public string QualificationSummary { get; set; }
        public List<PositionRemuneration> PositionRemuneration { get; set; } = new List<PositionRemuneration>();
        public DateTime PositionStartDate { get; set; }
        public DateTime PositionEndDate { get; set; }
        public DateTime PublicationStartDate { get; set; }
        public DateTime ApplicationCloseDate { get; set; }
        public List<PositionFormattedDescription> PositionFormattedDescription { get; set; } = new List<PositionFormattedDescription>();
        public UserArea UserArea { get; set; }
    }
}
