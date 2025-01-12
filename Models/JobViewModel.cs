using GovJobsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class JobViewModel
{
    [Key]
    public string PositionID { get; set; } // Primary key
    public string PositionTitle { get; set; }
    public string PositionURI { get; set; }
    public List<string> ApplyURI { get; set; } = new List<string>();
    public string PositionLocationDisplay { get; set; }
    public List<PositionLocation> PositionLocations { get; set; } = new List<PositionLocation>();
    public string OrganizationName { get; set; }
    public string DepartmentName { get; set; }
    public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
    public List<JobGrade> JobGrades { get; set; } = new List<JobGrade>();
    public List<PositionSchedule> PositionSchedules { get; set; } = new List<PositionSchedule>();
    public List<PositionOfferingType> PositionOfferingTypes { get; set; } = new List<PositionOfferingType>();
    public string QualificationSummary { get; set; }
    public List<PositionRemuneration> PositionRemunerations { get; set; } = new List<PositionRemuneration>();
    public DateTime? PositionStartDate { get; set; }
    public DateTime? PositionEndDate { get; set; }
    public DateTime? PublicationStartDate { get; set; }
    public DateTime? ApplicationCloseDate { get; set; }
    public List<PositionFormattedDescription> PositionFormattedDescriptions { get; set; } = new List<PositionFormattedDescription>();
    
    //UserArea Details
    public string JobSummary { get; set; }
    public WhoMayApply WhoMayApplies { get; set; } = new WhoMayApply();
    public string LowGrade { get; set; }
    public string HighGrade { get; set; }
    public string PromotionPotential { get; set; }
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
    public string SecurityClearance { get; set; }
    public bool DrugTestRequired { get; set; } = new bool();
    public List<string> AdjudicationType { get; set; } = new List<string>();
    public bool TeleworkEligible { get; set; } = new bool();
    public bool RemoteIndicator { get; set; } = new bool();


    public JobViewModel() { }

    public JobViewModel(MatchedObjectDescriptor matchedObjectDescriptor, string location)
    {
        PositionID = matchedObjectDescriptor.PositionID;
        PositionTitle = matchedObjectDescriptor.PositionTitle;
        PositionURI = matchedObjectDescriptor.PositionURI;
        ApplyURI = matchedObjectDescriptor.ApplyURI ?? new List<string>();
        PositionLocationDisplay = matchedObjectDescriptor.PositionLocationDisplay;
        PositionLocations = matchedObjectDescriptor.PositionLocation?.Select(pl => new PositionLocation
        {
            LocationName = pl.LocationName,
            CountryCode = pl.CountryCode,
            CountrySubDivisionCode = pl.CountrySubDivisionCode,
            CityName = pl.CityName,
            AddressLine = pl.AddressLine,
            Longitude = pl.Longitude,
            Latitude = pl.Latitude
        }).ToList() ?? new List<PositionLocation>();

        OrganizationName = matchedObjectDescriptor.OrganizationName;
        DepartmentName = matchedObjectDescriptor.DepartmentName;
        JobCategories = matchedObjectDescriptor.JobCategory?.Select(jc => new JobCategory
        { 
            Name = jc.Name, 
            Code = jc.Code 
        }).ToList() ?? new List<JobCategory>();
        
        JobGrades = matchedObjectDescriptor.JobGrade ?.Select(jg => new JobGrade
        {
            Code = jg.Code
        }).ToList() ?? new List<JobGrade>();
        
        PositionSchedules = matchedObjectDescriptor.PositionSchedule?.Select(ps => new PositionSchedule
        {
            Name = ps.Name,
            Code = ps.Code
        }).ToList() ?? new List<PositionSchedule>();
        PositionOfferingTypes = matchedObjectDescriptor.PositionOfferingType?.Select(pot => new PositionOfferingType
        {
            Name = pot.Name,
            Code = pot.Code
        }).ToList() ?? new List<PositionOfferingType>();
        QualificationSummary = matchedObjectDescriptor.QualificationSummary;

        PositionRemunerations = matchedObjectDescriptor.PositionRemuneration?.Select(pr => new PositionRemuneration
        {
            MinimumRange = pr.MinimumRange,
            MaximumRange = pr.MaximumRange,
            RateIntervalCode = pr.RateIntervalCode,
            Description = pr.Description
        }).ToList() ?? new List<PositionRemuneration>();

        PositionStartDate = matchedObjectDescriptor.PositionStartDate;
        PositionEndDate = matchedObjectDescriptor.PositionEndDate;
        PublicationStartDate = matchedObjectDescriptor.PublicationStartDate;
        ApplicationCloseDate = matchedObjectDescriptor.ApplicationCloseDate;
        PositionFormattedDescriptions = matchedObjectDescriptor.PositionFormattedDescription?.Select(pfd => new PositionFormattedDescription
        {
            Label = pfd.Label,
            LabelDescription = pfd.LabelDescription
        }).ToList() ?? new List<PositionFormattedDescription>();

        if (matchedObjectDescriptor.UserArea?.Details != null)
        {
            SetDetails(matchedObjectDescriptor.UserArea.Details);
        }
    }

    public void SetDetails(Details details)
    {
        JobSummary = details.JobSummary;
        WhoMayApplies = details.WhoMayApplies ?? new WhoMayApply();
        LowGrade = details.LowGrade;
        HighGrade = details.HighGrade;
        PromotionPotential = details.PromotionPotential;
        OrganizationCodes = details.OrganizationCodes;
        Relocation = details.Relocation = false;
        HiringPath = details.HiringPath ?? new List<string>();
        MCOTags = details.MCOTags ?? new List<string>();
        TotalOpenings = details.TotalOpenings;
        AgencyMarketingStatement = details.AgencyMarketingStatement;
        TravelCode = details.TravelCode;
        ApplyOnlineUrl = details.ApplyOnlineUrl;
        DetailStatusUrl = details.DetailStatusUrl;
        MajorDuties = details.MajorDuties ?? new List<string>();
        Education = details.Education;
        Requirements = details.Requirements;
        Evaluations = details.Evaluations;
        HowToApply = details.HowToApply;
        WhatToExpectNext = details.WhatToExpectNext;
        RequiredDocuments = details.RequiredDocuments;
        Benefits = details.Benefits;
        BenefitsUrl = details.BenefitsUrl;
        OtherInformation = details.OtherInformation;
        BenefitsDisplayDefaultText = details.BenefitsDisplayDefaultText = false;
        KeyRequirements = details.KeyRequirements ?? new List<string>();
        WithinArea = details.WithinArea = false;
        CommuteDistance = details.CommuteDistance;
        ServiceType = details.ServiceType;
        AnnouncementClosingType = details.AnnouncementClosingType;

        SecurityClearance = details.SecurityClearance;
        DrugTestRequired = details.DrugTestRequired = false;
        AdjudicationType = details.AdjudicationType ?? new List<string>();
        TeleworkEligible = details.TeleworkEligible = false;
        RemoteIndicator = details.RemoteIndicator = false;
    }
}
