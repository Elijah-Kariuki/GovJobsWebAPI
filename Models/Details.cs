namespace GovJobsWebAPI.Models
{
    public class Details
    {
      
        public string JobSummary { get; set; }
        public WhoMayApply WhoMayApplies { get; set; } = new WhoMayApply();
        public string LowGrade { get; set; }
        public string HighGrade { get; set; }
        public string PromotionPotential { get; set; }
        public string SubAgencyName { get; set; }
        public string OrganizationCodes { get; set; }
        public bool Relocation { get; set; } = new bool();
        public List<string> HiringPath { get; set; } = new List<string>();
        public List<string> MCOTags { get; set; } = new List<string>();
        public string TotalOpenings { get; set; }
        public string AgencyMarketingStatement { get; set; }
        public string TravelCode { get; set; } 
        public string ApplyOnlineUrl { get; set; }
        public string DetailStatusUrl { get; set; }
        public List<string> MajorDuties { get; set; } = new List<string>();
        public string Education { get; set; }
        public string Requirements { get; set; }
        public string Evaluations { get; set; }
        public string HowToApply { get; set; }
        public string WhatToExpectNext { get; set; }
        public string RequiredDocuments { get; set; }
        public string Benefits { get; set; }
        public string BenefitsUrl { get; set; }
        public bool BenefitsDisplayDefaultText { get; set; } = new bool();
        public string OtherInformation { get; set; }
        public List<string> KeyRequirements { get; set; } = new List<string>();
        public bool WithinArea { get; set; } = new bool();
        public string CommuteDistance { get; set; }
        public string ServiceType { get; set; }
        public string AnnouncementClosingType { get; set; }
        public string AgencyContactEmail { get; set; }
        public string AgencyContactPhone { get; set; }
        public string AgencyContactWebsite { get; set; }
        public string SecurityClearance { get; set; }
        public bool DrugTestRequired { get; set; } = new bool();
        public string PositionSensitivity { get; set; }
        public List<string> AdjudicationType { get; set; } = new List<string>();
        public bool TeleworkEligible { get; set; } = new bool();
        public bool RemoteIndicator { get; set; } = new bool();   
       
    }
}
